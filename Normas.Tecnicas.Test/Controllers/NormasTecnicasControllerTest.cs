namespace Normas.Tecnicas.Test.Controllers
{
    using Microsoft.Extensions.Configuration;
    using MediatR;
    using Moq;
    using Normas.Tecnicas.Application.Command;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using Normas.Tecnicas.Test.Builder;
    using Normas.Tecnicas.WebApi.Controllers;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using FluentAssertions;

    [ExcludeFromCodeCoverage]
    public class NormasTecnicasControllerTest
    {
        NormasTecnicasEventHandler _handler;
        Mock<INotification> _notification;
        Mock<IMediator> _mediator;
        IConfiguration _configuration;

        public NormasTecnicasControllerTest()
        {
            _notification = new Mock<INotification>();
            _handler = new NormasTecnicasEventHandler();
            _mediator = new Mock<IMediator>();

            var inMemorySettings = new Dictionary<string, string> {
                {"AzureBusConnectionString", "AzureBusConnectionString"},
                {"QueueName", "QueueName"},
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Fact]
        public void DadoQueFacaPostDaNormaTecnica_DeveRetornarCreated()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas();

            _mediator.Setup(x => x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(normasTecnicas);

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.Post(It.IsAny<string>(), normasTecnicas.FirstOrDefault()).Result;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.CreatedResult>();
        }

        [Fact]
        public void DadoQueFacaPostDaNormaTecnica_DevePublicarNormasTecnicasEvent()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas();

            _mediator.Setup(x => x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(normasTecnicas);

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.Post(It.IsAny<string>(), normasTecnicas.FirstOrDefault()).Result;

            //Assert
            _mediator.Verify(x => x.Publish(It.IsAny<NormasTecnicasEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void DadoQueFacaGetDaNormaTecnicaMasNaoTenhaDados_DeveRetornarNotFoundObjectResult()
        {
            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()));

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.GetNormasTecnicas(It.IsAny<string>(), It.IsAny<string>()).Result;

            //Assert
            actionResult.Should().BeNull();
        }

        [Fact]
        public void DadoQueFacaGetDaNormaTecnica_DeveRetornarOkObjectResult()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas();

            _mediator.Setup(x=> x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(normasTecnicas);

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                { 
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.GetNormasTecnicas(It.IsAny<string>(), normasTecnicas.FirstOrDefault().Codigo).Result;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkObjectResult>();
        }

        [Fact]
        public void DadoQueFacaGetDeTodasNormaTecnicaMasNaoTenhaDados_DeveRetornarNotFoundObjectResult()
        {
            //Arrange
            _mediator.Setup(x => x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()));

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.GetTodasNormasTecnicas(It.IsAny<string>()).Result;

            //Assert
            actionResult.Should().BeNull();
        }

        [Fact]
        public void DadoQueFacaGetDeTodasNormaTecnica_DeveRetornarOkObjectResult()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas();

            _mediator.Setup(x => x.Send(It.IsAny<NormasTecnicasCommand>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(normasTecnicas);

            //Act
            var normasTecnicasController = new NormasTecnicasController(_mediator.Object, _configuration)
            {
                ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var actionResult = normasTecnicasController.GetTodasNormasTecnicas(It.IsAny<string>()).Result;

            //Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<Microsoft.AspNetCore.Mvc.OkObjectResult>();
        }
    }
}
