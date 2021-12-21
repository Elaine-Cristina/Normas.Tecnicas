using System.Collections.Generic;

namespace Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate
{
    public interface INormasTecnicasRepository
    {
        NormasTecnicas ObterNormaTecnicaPorCodigo(string codigo);
        List<NormasTecnicas> ObterTodasNormaTecnica();
        void IncluirNormaTecnica(NormasTecnicas normaTecnica);
        void AlterarNormaTecnica(NormasTecnicas normaTecnica);
    }
}
