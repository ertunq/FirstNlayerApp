using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core.DTOs;
using Nlayer.Core.Models;
using Nlayer.Core.Services;

namespace NLayer.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
            _productService = productService;
        }
        
        [HttpGet("[action]")]

        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTOs>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTOs>>.Success(200, productDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDTOs>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTOs>.Success(200, productDto));
        } 
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTOs productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTOs>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTOs>.Success(201, productDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTOs productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentDTO>.Fail(404, "Product not found"));
            }
            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        
        
    }
}
