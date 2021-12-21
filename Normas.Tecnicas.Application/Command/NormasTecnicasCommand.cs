using MediatR;
using Normas.Tecnicas.Application.Domain.Enum;
using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
using System.Collections.Generic;

namespace Normas.Tecnicas.Application.Command
{
    public class NormasTecnicasCommand : IRequest<List<NormasTecnicas>>
    {
        public NormasTecnicasCommand(NormasTecnicas normasTecnicas, TipoRequisicao tipoRequisicao)
        {
            NormasTecnicas = normasTecnicas;
            TipoRequisicao = tipoRequisicao;
        }

        public NormasTecnicas NormasTecnicas { get; set; }
        public TipoRequisicao TipoRequisicao { get; set; }
    }
}
