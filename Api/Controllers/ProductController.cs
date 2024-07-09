using Core.DTOs;
using Core.Services;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace API.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetAllAsync();
            return CreateActionResult(result);
        }

        //[Authorize(Roles = "Admin, User")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProducts(int userId)
        {
            var result = await _service.GetUserProducts(userId);
            return CreateActionResult(result);
        }
         

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            var result = await _service.AddAsync(productDto);
            return CreateActionResult(result);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            var result = await _service.UpdateAsync(productDto);
            return CreateActionResult(result);
        }

        //[Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAll(List<ProductDto> productDtos)
        {
            var result = await _service.AddRangeAsync(productDtos);
            return CreateActionResult(result);
        }
    }
}
