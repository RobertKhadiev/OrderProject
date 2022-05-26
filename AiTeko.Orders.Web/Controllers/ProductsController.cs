using AiTeko.Orders.Domain.Interfaces;
using AiTeko.Orders.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiTeko.Orders.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{productId}")]

        public IActionResult GetById(long productId)
        {
            var product = _productService.GetById(productId);

            return Ok(product);
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            var id = await _productService.Create(productModel);

            return Ok(id);
        }
    }
}
