using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] //Base/api/Products
    public class ProductsController(IServiceManger _serviceManger) : ControllerBase
    {
        // Get All Products
        [HttpGet]
        public async Task< ActionResult<PaginatedResult<ProductDto>> > GetAllProducts([FromQuery] ProductQueryParams queryParams)
        {
            var Products = await _serviceManger.ProductService.GetAllProductsAsync(queryParams);
            return Ok(Products);
        }
        // Get Product By Id
        [HttpGet("{id}")]
        public async Task< ActionResult<ProductDto>> GetProduct(int id)
        {
            var Product = await _serviceManger.ProductService.GetProductAsync(id);
            return Ok(Product);

        }
        //Get All Types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable< TypeDto >>> GetTypes()
        {
            var Types = await _serviceManger.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable< BrandDto>>> GetBrands()
        {
            var Brands = await _serviceManger.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

    }
}
