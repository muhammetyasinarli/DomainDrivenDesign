using DomainDriventDesign.Application.Features.Users.CreateUser;
using DomainDriventDesign.Application.Features.Users.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriventDesign.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllUserQuery command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
