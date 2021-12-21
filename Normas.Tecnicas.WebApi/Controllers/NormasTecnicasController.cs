namespace Normas.Tecnicas.WebApi.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Normas.Tecnicas.Application.Command;
    using Normas.Tecnicas.Application.Domain.Enum;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class NormasTecnicasController : ControllerBase
    {
        readonly IMediator _mediator;
        private readonly string serviceBusConnectionString;
        private readonly string queueName;

        public NormasTecnicasController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            serviceBusConnectionString = config.GetValue<string>("AzureServiceBus:ConnectionString");
            queueName = config.GetValue<string>("AzureServiceBus:QueueName");
        }

        [HttpPost(Name = "PostNormasTecnicas")]
        public async Task<ActionResult> Post([FromRoute(Name = "codigoAcesso")] string codigoAcesso, 
                                             [FromBody] NormasTecnicas normasTecnicas)
        {
            var result = await _mediator.Send(new NormasTecnicasCommand(normasTecnicas, TipoRequisicao.Incluir));

            if (result != null)
                await _mediator.Publish(new NormasTecnicasEvent(normasTecnicas, queueName, serviceBusConnectionString));

            return Created("api/normasTenicas", result);
        }

        [HttpGet("{codigoNormaTecnica}", Name = "GetNormasTecnicas")]
        public async Task<ActionResult> GetNormasTecnicas([FromRoute(Name = "codigoAcesso")] string codigoAcesso,
                                                          [FromRoute(Name = "codigoNormaTecnica")] string codigoNormaTecnica)
        {
            var normasTecnicas = new NormasTecnicas() { Codigo = codigoNormaTecnica };
            var result = await _mediator.Send(new NormasTecnicasCommand(normasTecnicas, TipoRequisicao.Consultar));

            if (result == null)
                return await Task.FromResult<NotFoundObjectResult>(null);

            return await Task.FromResult(Ok(result));

        }

        [HttpGet(Name = "GetTodasNormasTecnicas")]
        public async Task<ActionResult> GetTodasNormasTecnicas([FromRoute(Name = "codigoAcesso")] string codigoAcesso)
        {
            var result = await _mediator.Send(new NormasTecnicasCommand(new NormasTecnicas(), TipoRequisicao.ConsultarTudo));

            if (result == null)
                return await Task.FromResult<NotFoundObjectResult>(null);

            return await Task.FromResult(Ok(result));

        }
    }
}
