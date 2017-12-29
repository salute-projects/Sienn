using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIENN.Domain.DTO.Product;
using SIENN.Domain.Infrastructure;
using SIENN.Services.Abstraction;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
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
                return BadRequest("Error while loading products. Please try a bit later");
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
                return BadRequest("Error while loading product. Please try a bit later");
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
                return BadRequest("Error while loading products. Please try a bit later");
            }
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] ProductFilterRequest request)
        {
            try
            {
                return Ok(_service.Search(request));
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while loading products. Please try a bit later");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductDto request)
        {
            try
            {
                _service.Add(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while adding product. Please try a bit later");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductDto request)
        {
            try
            {
                _service.Update(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while updating product. Please try a bit later");
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
                return BadRequest("Error while deleting product. Please try a bit later");
            }
        }
    }
}