using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
using System.Collections.Generic;
using System.Linq;

namespace Normas.Tecnicas.Infrastructure.Repository
{
    public class NormasTecnicasRepository : INormasTecnicasRepository
    {
        protected List<NormasTecnicas> _normasTecnicas;

        public NormasTecnicasRepository()
        {
            _normasTecnicas = new MockPrototipo.MockPrototipo().PopularNormaTecnica();
        }

        public NormasTecnicas ObterNormaTecnicaPorCodigo(string codigo)
        {
            return _normasTecnicas.FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<NormasTecnicas> ObterTodasNormaTecnica()
        {
            return _normasTecnicas.ToList();
        }

        public void IncluirNormaTecnica(NormasTecnicas normaTecnica)
        {
            _normasTecnicas.Add(normaTecnica);
        }

        public void AlterarNormaTecnica(NormasTecnicas normaTecnica)
        {
            _normasTecnicas.RemoveAll(x => x.Codigo == normaTecnica.Codigo);
            _normasTecnicas.Add(normaTecnica);
        }
    }
}
