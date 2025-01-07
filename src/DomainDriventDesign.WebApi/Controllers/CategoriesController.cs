using DomainDriventDesign.Application.Features.Categories.CreateCategory;
using DomainDriventDesign.Application.Features.Categories.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriventDesign.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCategoryQuery command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
