namespace Normas.Tecnicas.Test.Builder
{
    using Normas.Tecnicas.Application.Domain.Enum;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class NormasTecnicasFaker
    {
        internal static List<NormasTecnicas> NormasTecnicas()
        {
            return new List<NormasTecnicas>()
            {
                new NormasTecnicas()
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
                },
                new NormasTecnicas()
                {
                    Codigo = "ABNT NBR 13481:2009",
                    DataPublicacao = new DateTime(2009, 01, 15),
                    DataInicio = new DateTime(2009, 02, 15),
                    Titulo = "Nãotecido - Determinação do tempo de penetração de líquido",
                    TituloIdiomaSec = "Nonwoven - Determination of liquid strike-through-time",
                    NotaTitulo = "Confirmada em 07.02.2019",
                    Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                    NumeroPaginas = 6,
                    Status = Status.EmVigor,
                    Idioma = "Português",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma prescreve o método para determinação do tempo de penetração de líquido (urina sintética) para véu de superfície (cobertura) de nãotecidos."
                },
                new NormasTecnicas()
                {
                    Codigo = "ABNT NBR 13841:2009",
                    DataPublicacao = new DateTime(2009, 02, 06),
                    DataInicio = new DateTime(2009, 03, 06),
                    Titulo = "Artigos têxteis hospitalares - Tecido de gaze hidrófila purificada - Requisitos e métodos de ensaio em artigos têxteis hospitalares - Tecido de gaze hidrófila purificada - Requisitos e métodos de ensaio",
                    TituloIdiomaSec = "Hospitals textile articles - Purified phydrophila gauze cloth - Requirements and test methods",
                    NotaTitulo = "Confirmada em 28.07.2014",
                    Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                    NumeroPaginas = 7,
                    Status = Status.Cancelada,
                    Idioma = "Português",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma fixa os requisitos e métodos de ensaio para o tecido de gaze hidrófila purificada."
                },
                new NormasTecnicas()
                {
                    Codigo = "ABNT NBR 13843:2009",
                    DataPublicacao = new DateTime(2009, 02, 06),
                    DataInicio = new DateTime(2009, 03, 06),
                    Titulo = "Artigo têxtil hospitalar - Compressa de gaze - Requisitos e métodos de ensaio",
                    TituloIdiomaSec = "Hospital textile article - Gauze compress - Requirements and test methods",
                    NotaTitulo = "Confirmada em 08.02.2019",
                    Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                    NumeroPaginas = 5,
                    Status = Status.EmVigor,
                    Idioma = "Português",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos e métodos de ensaio da compressa de gaze, confeccionada a partir do tecido classificado em tipo I e tipo II e especificado na NBR 13841."
                },
                new NormasTecnicas()
                {
                    Codigo = "ABNT NBR 14767:2009",
                    DataPublicacao = new DateTime(2009, 07, 16),
                    DataInicio = new DateTime(2009, 08, 16),
                    Titulo = "Artigo têxteis hospitalares - Compressa campo operatório-Requisitos e métodos de ensaio",
                    TituloIdiomaSec = "Hospital textile articles - Surgical compress - Requirements and test methods",
                    NotaTitulo = "Confirmada em 08.02.2019",
                    Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                    NumeroPaginas = 6,
                    Status = Status.EmVigor,
                    Idioma = "Português",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica as características da qualidade da compressa campo operatório, quando confeccionada a partir de tecido hidrófilo 100% algodão ou tecido misto derivado de celulose em até 50%."
                }
                ,
                new NormasTecnicas()
                {
                    Codigo = "ABNT NBR 14990-6:2009",
                    DataPublicacao = new DateTime(2009, 03, 05),
                    DataInicio = new DateTime(2009, 04, 05),
                    Titulo = "Sistemas e materiais de embalagem para esterilização de produtos para saúde. Parte 6: Nãotecido",
                    TituloIdiomaSec = "Packaging for terminally sterilized medical devices - Part 6: Nonwoven",
                    NotaTitulo = "Confirmada em 08.02.2019",
                    Comite = "ABNT/CB-017 Têxteis e do Vestuário",
                    NumeroPaginas = 3,
                    Status = Status.EmVigor,
                    Idioma = "Português",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos para sistemas e materiais de embalagem para esterilização de produtos para saúde de uso único em nãotecidos."
                }
            };
        }
    }
}
