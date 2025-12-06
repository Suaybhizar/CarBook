using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewListByCarId(int id)
        {
            var result = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            CreateReviewValidator validator=new CreateReviewValidator();
            var validationResult=validator.Validate(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Gerçekleşti");
        }
    }
}
