using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //public IActionResult Index()
        //{
          //  return View();
        //}
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var product = await _productService.GetProductList();
            return Ok(product);
        }
        [HttpPost]
        
        public async Task<ActionResult<Products>> AddProduct([FromForm]Products p)
        {
            
            var pr= await _productService.AddProduct(p);
            return CreatedAtAction("GetList",new { productId=pr.ProductId},pr);
            
        }
        
        [HttpPut("id")]
        public async Task<ActionResult<Products>> UpdateProduct([FromForm] Products p)
        {
          
            var product =await _productService.UpdateProduct(p);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{p.ProductName} could not be updated");

            }
            return Ok(product);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var pr = await _productService.GetproductById(id);
            return Ok(pr);
        }
        
    }
}
