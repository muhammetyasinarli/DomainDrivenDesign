using DomainDriventDesign.Application.Features.Orders.CreateOrder;
using DomainDriventDesign.Application.Features.Orders.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriventDesign.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
