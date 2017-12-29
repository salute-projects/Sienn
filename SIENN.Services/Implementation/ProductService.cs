using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Abstraction;
using SIENN.Domain.DTO.Product;
using SIENN.Domain.Entities;
using SIENN.Domain.Extensions;
using SIENN.Domain.Infrastructure;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ProductDetailsDto GetById(int id)
        {
            return _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id).ToDto();
        }

        public Page<ProductDetailsDto> GetPage(PagingReqest request)
        {
            var all = _unitOfWork.Products.GetAll().Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category);
            var slice = all.OrderBy(t => t.Id)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize).Select(t => t.ToDto());
            return new Page<ProductDetailsDto>
            {
                Items = slice,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                FoundItems = all.Count(),
                TotalItems = all.Count()
            };
        }

        public Page<ProductDetailsDto> Search(ProductFilterRequest request)
        {
            var all = _unitOfWork.Products.GetAll().Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category);
            Expression<Func<Product, bool>> filter = x => (string.IsNullOrEmpty(request.SearchCriteria)
                                                         || x.Description.ToLower()
                                                             .Contains(request.SearchCriteria.ToLower())
                                                         || x.Code.ToString().ToLower()
                                                             .Contains(request.SearchCriteria.ToLower()))
                                                         && (request.Availability == null ||
                                                             x.IsAvailable == request.Availability.Value)
                                                         && (request.TypeFilter == null || !request.TypeFilter.Any() ||
                                                             request.TypeFilter.Any(t => t == x.TypeId))
                                                         && (request.UnitFilter == null || !request.UnitFilter.Any() ||
                                                             request.UnitFilter.Any(t => t == x.UnitId))
                                                         && (request.CategoryFilter == null ||
                                                             !request.CategoryFilter.Any() ||
                                                             request.CategoryFilter.Any(t =>
                                                                 x.Categories.Any(e => e.CategoryId == t)));
            var filtered = all.Where(filter);
            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var slice = new List<Product>();
            if (request.OrderByCode)
            {
                slice = GetSlice(filtered, x => x.Code, request.Ascending, skip, take);
            } else if (request.OrderByCreated)
            {
                slice = GetSlice(filtered, x => x.Created, request.Ascending, skip, take);
            } else if (request.OrderByDeliveryDate)
            {
                slice = GetSlice(filtered, x => x.DeliveryDate, request.Ascending, skip, take);
            } else if (request.OrderByPrice)
            {
                slice = GetSlice(filtered, x => x.Price, request.Ascending, skip, take);
            } else if (request.OrderByUpdated)
            {
                slice = GetSlice(filtered, x => x.Updated, request.Ascending, skip, take);
            }
            else if (request.OrderById)
            {
                slice = GetSlice(filtered, x => x.Id, request.Ascending, skip, take);
            }
            return new Page<ProductDetailsDto>
            {
                Items = slice.Select(t => t.ToDto()),
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                FoundItems = filtered.Count(),
                TotalItems = all.Count()
            };
        }

        private static List<Product> GetSlice<TKey>(IEnumerable<Product> items,
            Expression<Func<Product, TKey>> orderBy, bool asc, int skip, int take)
        {
            return asc
                ? items.AsQueryable().OrderBy(orderBy).Skip(skip).Take(take).ToList()
                : items.AsQueryable().OrderByDescending(orderBy).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<ProductDetailsDto> GetAll()
        {
            return _unitOfWork.Products.GetAll().Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).OrderBy(t => t.Id).Select(t => t.ToDto());
        }

        public void Add(AddProductDto dto)
        {
            if (dto == null)
                throw new Exception("Arguments omitted");
            if (dto.CategoryIds == null || !dto.CategoryIds.Any())
                throw new Exception("Category list is empty");
            var newProduct = dto.ToEntity();
            var productType = _unitOfWork.ProductTypes.Get(dto.ProductTypeId);
            var unit = _unitOfWork.Units.Get(dto.UnitId);
            newProduct.Unit = unit ?? throw new Exception("Wrong unit");
            newProduct.Type = productType ?? throw new Exception("Wrong product type");
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = _unitOfWork.Categories.Get(categoryId);
                if (category == null)
                    throw new Exception("Wrong category");
                newProduct.Categories.Add(new ProductCategoryLink
                {
                    Category = category,
                    Product = newProduct
                });
            }
            newProduct.Created = DateTimeOffset.UtcNow;
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Save();
        }

        public void Update(UpdateProductDto dto)
        {
            if (dto == null)
                throw new Exception("Arguments omitted");
            if (dto.CategoryIds == null || !dto.CategoryIds.Any())
                throw new Exception("Category list is empty");
            var target = _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == dto.Id);
            if (target == null)
                throw new Exception("Prodcut not found");
            var productType = _unitOfWork.ProductTypes.Get(dto.ProductTypeId);
            var unit = _unitOfWork.Units.Get(dto.UnitId);
            target.Code = dto.Code;
            target.Description = dto.Description;
            target.DeliveryDate = dto.DeliveryDate;
            target.Price = dto.Price;
            target.IsAvailable = dto.IsAvailable;
            target.Type = productType ?? throw new Exception("Wrong product type");
            target.Unit = unit ?? throw new Exception("Wrong unit");
            foreach (var existingCategory in target.Categories.ToList())
            {
                target.Categories.Remove(existingCategory);
            }
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = _unitOfWork.Categories.Get(categoryId);
                if (category == null)
                    throw new Exception("Wrong category");
                target.Categories.Add(new ProductCategoryLink
                {
                    Category = category,
                    Product = target
                });
            }
            target.Updated = DateTimeOffset.UtcNow;
            _unitOfWork.Products.Update(target);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (product == null)
                throw new Exception("Product not found");
            foreach (var category in product.Categories.ToList())
            {
                product.Categories.Remove(category);
            }
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Save();
        }
    }
}
