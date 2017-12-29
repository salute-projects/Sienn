using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIENN.Domain.DTO.ProductType;
using SIENN.Domain.Extensions;
using SIENN.Domain.Infrastructure;
using SIENN.Services.Abstraction;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductType")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _service;
        private readonly ILogger _logger;

        public ProductTypeController(IProductTypeService service, ILogger<ProductTypeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while loading product types. Please try a bit later");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while loading product type. Please try a bit later");
            }
        }

        [HttpGet("page/{pageNumber:int}/pageSize/{pageSize:int}")]
        public IActionResult GetPage(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(_service.GetPage(new PagingReqest
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while loading product types. Please try a bit later");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductTypeDto request)
        {
            try
            {
                _service.Insert(request.ToEntity());
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while adding product type. Please try a bit later");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductTypeDto request)
        {
            try
            {
                _service.Update(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while updating product type. Please try a bit later");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while deleting product type. Please try a bit later");
            }
        }

    }
}