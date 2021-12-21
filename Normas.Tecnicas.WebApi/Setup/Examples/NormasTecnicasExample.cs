using Normas.Tecnicas.Application.Domain.Enum;
using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Normas.Tecnicas.WebApi.Setup.Examples
{
    public class NormasTecnicasExample : IExamplesProvider<NormasTecnicas>
    {
        public NormasTecnicas GetExamples()
        {
            return new NormasTecnicas()
            {
                Codigo = "ABNT NBR 12984:2009",
                DataPublicacao = new DateTime(2009, 01, 23),
                DataInicio = new DateTime(2009, 02, 23),
                Titulo = "Nãotecido - Determinação da massa por unidade de área",
                TituloIdiomaSec = "Nonwoven - Determination of mass per unit area",
                NotaTitulo = "Confirmada em 08.02.2019",
                Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                NumeroPaginas = 3,
                Status = Status.EmVigor,
                Idioma = "Português",
                Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                Objetivo = "Esta Norma estabelece o método de ensaio para a determinação da massa por unidade de área dos nãotecidos."
            };
        }
    }
}
