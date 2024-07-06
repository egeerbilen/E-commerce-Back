using Entity.DTOs;
using Entity.Model;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;

namespace API.Controllers
{
    public class ProductDetailsController : CustomBaseController
    {
        private readonly IProductDetailsService _service;

        public ProductDetailsController(IProductDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDetailsDto productDto)
        {
            var result = await _service.AddAsync(productDto);
            return CreateActionResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDetailsDto productDto)
        {
            var result = await _service.UpdateAsync(productDto);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<ProductDetails>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(id);
            return CreateActionResult(result);
        }
    }
}
