namespace Normas.Tecnicas.Application.Command
{
    using MediatR;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class NormasTecnicasCommandHandler : IRequestHandler<NormasTecnicasCommand, List<NormasTecnicas>>
    {
        private readonly INormasTecnicasRepository _repository;

        public NormasTecnicasCommandHandler(INormasTecnicasRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<NormasTecnicas>> Handle(NormasTecnicasCommand request, CancellationToken cancellationToken)
        {
            var normasTecnicas = new List<NormasTecnicas>();

            if (request.TipoRequisicao == Domain.Enum.TipoRequisicao.ConsultarTudo)
            {
                normasTecnicas = _repository.ObterTodasNormaTecnica();
            }
            else
            { 
                var normas = _repository.ObterNormaTecnicaPorCodigo(request.NormasTecnicas.Codigo);

                if (request.TipoRequisicao == Domain.Enum.TipoRequisicao.Incluir)
                {
                    if (normas == null)
                        _repository.IncluirNormaTecnica(request.NormasTecnicas);
                    else
                        _repository.AlterarNormaTecnica(request.NormasTecnicas);

                    normasTecnicas.Add(request.NormasTecnicas);
                }
                else
                    normasTecnicas.Add(normas);
            }

            return Task.FromResult(normasTecnicas);
        }
    }
}
