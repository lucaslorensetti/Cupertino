using System;
using System.Threading.Tasks;
using Cupertino.Application.Services.Product;
using Cupertino.Data.Entities;
using Cupertino.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Cupertino.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet, Route("api/Product/Search")]
        public async Task<IActionResult> SearchAsync(string productName)
        {
            var products = await this.productService.SearchAsync(productName);

            return Ok(products);
        }

        [HttpGet, Route("api/Product/{productId}")]
        public async Task<IActionResult> GetAsync(Guid productId)
        {
            var product = await this.productService.GetAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost, Route("api/Product/")]
        public async Task<IActionResult> PostAsync([FromBody]Product product)
        {
            var operationResult = await this.productService.InsertAsync(product);

            return this.GetActionResult(operationResult);
        }

        [HttpPut, Route("api/Product/")]
        public async Task<IActionResult> PutAsync([FromBody]Product product)
        {
            var operationResult = await this.productService.UpdateAsync(product);

            return this.GetActionResult(operationResult);
        }

        [HttpDelete, Route("api/Product/{productId}")]
        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            var operationResult = await this.productService.DeleteAsync(productId);

            return this.GetActionResult(operationResult);
        }

        [HttpGet, Route("Product/List"), Route("~/")]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet, Route("Product/AddEdit")]
        public IActionResult AddEdit()
        {
            return View();
        }
    }
}
