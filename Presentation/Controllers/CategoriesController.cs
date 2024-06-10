using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _manager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute] int id)
        {
            var category = await _manager.CategoryService.GetOneCategoryByIdAsync(id, false);
            if (category == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCategoryAsync([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category object is null"); // 400 Bad Request
            }

            await _manager.CategoryService.CreateOneCategoryAsync(category);
            return StatusCode(201); // 201 Created
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategoryAsync(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category object is null"); // 400 Bad Request
            }

            var categoryEntity = await _manager.CategoryService.GetOneCategoryByIdAsync(id, true);
            if (categoryEntity == null)
            {
                return NotFound(); // 404 Not Found
            }

            await _manager.CategoryService.UpdateOneCategoryAsync(category);
            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute] int id)
        {
            var category = await _manager.CategoryService.GetOneCategoryByIdAsync(id, false);
            if (category == null)
            {
                return NotFound(); // 404 Not Found
            }

            await _manager.CategoryService.DeleteOneCategoryAsync(category);
            return NoContent(); // 204 No Content
        }
    }
}
