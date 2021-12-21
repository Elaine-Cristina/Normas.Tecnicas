using Normas.Tecnicas.Application.Domain.Enum;
using System;

namespace Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate
{
    public class NormasTecnicas
    {
        public string Codigo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public string Titulo { get; set; }
        public string TituloIdiomaSec { get; set; }
        public string NotaTitulo { get; set; }
        public string Comite { get; set; }
        public int? NumeroPaginas { get; set; }
        public Status? Status { get; set; }
        public string Idioma { get; set; }
        public string Organismo { get; set; }
        public string Objetivo { get; set; }
    }
}
