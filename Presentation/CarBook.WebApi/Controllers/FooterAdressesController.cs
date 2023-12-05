using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var values = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var values = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Alt Adres Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Güncellendi");
        }

    }
}
