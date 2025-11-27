using System;
using System.Collections.Generic;

namespace Regravacao.DTOs
{
    public class RegravacaoInserirDto
    {
        public string RequerimentoAtual { get; set; } = string.Empty;
        public string RequerimentoNovo { get; set; } = string.Empty;
        public string DescricaoArte { get; set; } = string.Empty;
        public short Versao { get; set; }

        public int IdQuemFinalizou { get; set; }
        public int IdConferente { get; set; }
        public int IdSolicitante { get; set; }
        public int IdEnviarPara { get; set; }

        public int? IdCustoDeQuem { get; set; }
        public int IdMotivoPrincipal { get; set; }

        public short QtdePlacas { get; set; }
        public int IdPrioridade { get; set; }
        public int IdStatus { get; set; }

        public DateTime DataCadastro { get; set; }
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;

        public short? IdMaterial { get; set; }

        public List<int>? IdsErrosSelecionados { get; set; }
        public List<CoresInserirDto> Cores { get; set; } = new();
    }
}
