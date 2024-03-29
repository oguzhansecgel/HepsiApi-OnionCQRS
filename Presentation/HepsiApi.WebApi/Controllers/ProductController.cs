﻿using HepsiApi.Application.Features.Products.Command.CreateProduct;
using HepsiApi.Application.Features.Products.Command.DeleteProduct;
using HepsiApi.Application.Features.Products.Command.UpdateProduct;
using HepsiApi.Application.Features.Products.Queries.GettAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HepsiApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {

            var response = await mediator.Send(new GettAllProductQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {

            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {

            await mediator.Send(request);

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {

            await mediator.Send(request);

            return Ok();
        }
    }
}
