using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIENN.Domain.DTO.Category;
using SIENN.Domain.Extensions;
using SIENN.Domain.Infrastructure;
using SIENN.Services.Abstraction;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly ILogger _logger;

        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
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
                return BadRequest("Error while loading categories. Please try a bit later");
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
                return BadRequest("Error while loading category. Please try a bit later");
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
                return BadRequest("Error while loading categories. Please try a bit later");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddCategoryDto request)
        {
            try
            {
                _service.Insert(request.ToEntity());
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while adding category. Please try a bit later");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryDto request)
        {
            try
            {
                _service.Update(request);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(-1, e, $"General exception occurred, exception message: {e.Message}!");
                return BadRequest("Error while updating category. Please try a bit later");
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
                return BadRequest("Error while deleting category. Please try a bit later");
            }
        }

    }
}