using System.Net;
using Mail.Engine.Service.Application.Queries;
using Mail.Engine.Service.Application.Response;
using Mail.Engine.Service.Application.Response.Wati;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mail.Engine.Service.Api.Controllers
{
    public class Messaging(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("Inbound")]
        [ProducesResponseType(typeof(MailResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InboundMail()
        {
            var result = await _mediator.Send(new GetInboundQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("Outbound")]
        [ProducesResponseType(typeof(MailResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OutboundMail()
        {
            var result = await _mediator.Send(new GetOutboundQuery());

            return Ok(result);
        }

        [HttpGet]
        [Route("WatiService")]
        [ProducesResponseType(typeof(List<WatiApiResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> WatiService()
        {
            var result = await _mediator.Send(new GetWatiQuery());

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Ping")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public IActionResult Ping()
        {
            return Ok(new { message = "Pong", timestamp = DateTime.Now });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Env")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public IActionResult Env()
        {
            return Ok(new { message = $"This is a test: {Environment.GetEnvironmentVariable("TEST_VARIABLE")}", timestamp = DateTime.Now });
        }
    }
}
