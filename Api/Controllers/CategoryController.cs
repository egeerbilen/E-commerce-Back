using Core.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.Services;

namespace API.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin, Read")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Admin, Create")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            return CreateActionResult(await _service.AddAsync(category));
        }

        [Authorize(Roles = "Admin, Create")]
        [HttpPost]
        public async Task<IActionResult> CreateCategories(List<CategoryDto> categoryDto)
        {
            return CreateActionResult(await _service.AddRangeAsync(categoryDto));
        }

        [Authorize(Roles = "Admin, Update")]
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var result = await _service.UpdateAsync(categoryDto);
            return CreateActionResult(result);
        }

        [Authorize(Roles = "Admin, Delete")]
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }

        [Authorize(Roles = "Admin, Delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(List<int> ids)
        {
            return CreateActionResult(await _service.RemoveRangeAsync(ids));
        }
    }
}
