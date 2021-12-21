namespace Normas.Tecnicas.Test.Command
{
    using Moq;
    using Normas.Tecnicas.Application.Command;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using Normas.Tecnicas.Test.Builder;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class NormasTecnicasCommandHandlerTest
    {
        NormasTecnicasCommandHandler _handler;
        Mock<INormasTecnicasRepository> _repository;

        public NormasTecnicasCommandHandlerTest()
        {
            _repository = new Mock<INormasTecnicasRepository>();
            _handler = new NormasTecnicasCommandHandler(_repository.Object);
        }

        [Fact]
        public void DadoQueConsulteNormasTecnicas_DeveRetornarTodas()
        {
            //Arrange
            var command = new NormasTecnicasCommand(It.IsAny<NormasTecnicas>(), Application.Domain.Enum.TipoRequisicao.ConsultarTudo);
            _repository.Setup(x => x.ObterTodasNormaTecnica()).Returns(NormasTecnicasFaker.NormasTecnicas());

            //Act
            var result = _handler.Handle(command, default).Result;

            //Assert
            result.Count.Equals(6);
            _repository.Verify(x => x.ObterTodasNormaTecnica(), Times.Once);
        }

        [Fact]
        public void DadoQueConsulteNormasTecnicasPorCodigo_DeveRetornar()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas().FirstOrDefault();
            var command = new NormasTecnicasCommand(normasTecnicas, Application.Domain.Enum.TipoRequisicao.Consultar);
            _repository.Setup(x => x.ObterNormaTecnicaPorCodigo(normasTecnicas.Codigo)).Returns(normasTecnicas);

            //Act
            var result = _handler.Handle(command, default).Result;

            //Assert
            result.Count.Equals(1);
            _repository.Verify(x => x.ObterNormaTecnicaPorCodigo(normasTecnicas.Codigo), Times.Once);
        }

        [Fact]
        public void DadoQueNormaTecnicaNaoExista_DeveIncluirERetornarSucesso()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas().FirstOrDefault();
            var command = new NormasTecnicasCommand(normasTecnicas, Application.Domain.Enum.TipoRequisicao.Incluir);
            _repository.Setup(x => x.ObterNormaTecnicaPorCodigo(normasTecnicas.Codigo));
            _repository.Setup(x => x.IncluirNormaTecnica(It.IsAny<NormasTecnicas>()));

            //Act
            var result = _handler.Handle(command, default).Result;

            //Assert
            result.Count.Equals(1);
            _repository.Verify(x => x.IncluirNormaTecnica(It.IsAny<NormasTecnicas>()), Times.Once);
        }

        [Fact]
        public void DadoQueNormaTecnicaExista_DeveAlterarERetornarSucesso()
        {
            //Arrange
            var normasTecnicas = NormasTecnicasFaker.NormasTecnicas().FirstOrDefault();
            var command = new NormasTecnicasCommand(normasTecnicas, Application.Domain.Enum.TipoRequisicao.Incluir);
            _repository.Setup(x => x.ObterNormaTecnicaPorCodigo(normasTecnicas.Codigo)).Returns(normasTecnicas);
            _repository.Setup(x => x.AlterarNormaTecnica(It.IsAny<NormasTecnicas>()));

            //Act
            var result = _handler.Handle(command, default).Result;

            //Assert
            result.Count.Equals(1);
            _repository.Verify(x => x.AlterarNormaTecnica(It.IsAny<NormasTecnicas>()), Times.Once);
        }
    }
}
