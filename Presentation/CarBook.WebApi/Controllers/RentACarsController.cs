using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocaton(int LocationID, bool Available)
        {
            GetRentACarQuery getRentACArQuery = new GetRentACarQuery()
            {
                Available = Available,
                LocationId = LocationID
            };
            var values = await _mediator.Send(getRentACArQuery);
            return Ok(values);
        }
    }
}
