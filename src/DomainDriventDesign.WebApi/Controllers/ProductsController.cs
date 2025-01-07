using DomainDriventDesign.Application.Features.Products.CreateProduct;
using DomainDriventDesign.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriventDesign.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductQuery command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
