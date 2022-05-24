using Alefba.Application.Features.Exchange.Requests.Commands;
using Alefba.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alefba.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExchangeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AverageBetween/{startDateTime:DateTime}/{endDateTime:DateTime}")]
        public async Task<ActionResult<double>> GetAverage(DateTime startDateTime, DateTime endDateTime)
        {
            var request = new GetExchangeAverageInSpecificDateRequest();
            request.startDateTime = startDateTime;
            request.endDateTime = endDateTime;

            var average = await _mediator.Send(request);
            return Ok(average);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateExchangeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
