using Core.DTOs;
using Entity.Model;
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

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            return CreateActionResult(await _service.AddAsync(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories(List<CategoryDto> categoryDto)
        {
            return CreateActionResult(await _service.AddRangeAsync(categoryDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var result = await _service.UpdateAsync(categoryDto);
            return CreateActionResult(result);
        }

        [HttpDelete]
        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> DelteCategory(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DelteCategories(List<int> ids)
        {
            return CreateActionResult(await _service.RemoveRangeAsync(ids));
        }
    }
}
