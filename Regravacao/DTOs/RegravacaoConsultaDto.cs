using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;

namespace Regravacao.DTOs
{
    // Não precisa herdar de BaseModel ou ter [Table]
    public class CorDetalheDto
    {
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }
        [JsonPropertyName("nome_cor")]
        public string NomeCor { get; set; } = string.Empty;
        [JsonPropertyName("codigo_hex")]
        public string CodigoHexadecimal { get; set; } = string.Empty;
        [JsonPropertyName("largura")]
        public decimal Largura { get; set; }
        [JsonPropertyName("comprimento")]
        public decimal Comprimento { get; set; }
        [JsonPropertyName("custo_estimado")]
        public decimal CustoEstimado { get; set; }
    }

    public class ErroDetalheDto
    {
        [JsonPropertyName("id_detalhes_erros")]
        public int IdDetalhesErros { get; set; }
        [JsonPropertyName("descricao_erro")]
        public string DescricaoErro { get; set; } = string.Empty;
    }


    public class RegravacaoConsultaDto
    {
        // Campos principais da TblRegravacao
        [JsonPropertyName("id_regravacao")]
        public int IdRegravacao { get; set; }
        [JsonPropertyName("requerimento_atual")]
        public string RequerimentoAtual { get; set; } = string.Empty;
        [JsonPropertyName("requerimento_novo")]
        public string? RequerimentoNovo { get; set; }
        [JsonPropertyName("descricao_arte")]
        public string DescricaoArte { get; set; } = string.Empty;
        [JsonPropertyName("versao")]
        public short Versao { get; set; }
        [JsonPropertyName("qtde_placas")]
        public short QtdePlacas { get; set; }

        // Campos retornados pelos JOINs
        [JsonPropertyName("prioridade")]
        public string Prioridade { get; set; } = string.Empty;
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        [JsonPropertyName("motivo_principal")]
        public string MotivoPrincipal { get; set; } = string.Empty;
        [JsonPropertyName("solicitante")]
        public string Solicitante { get; set; } = string.Empty;
        [JsonPropertyName("conferente")]
        public string Conferente { get; set; } = string.Empty;
        [JsonPropertyName("finalizado_por")]
        public string FinalizadoPor { get; set; } = string.Empty;
        [JsonPropertyName("enviar_para")]
        public string EnviarPara { get; set; } = string.Empty;
        [JsonPropertyName("material")]
        public string? Material { get; set; }

        // Metadados
        [JsonPropertyName("data_cadastro")]
        public DateTime DataCadastro { get; set; }
        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }
        [JsonPropertyName("observacoes")]
        public string? Observacoes { get; set; }

        // Campos agregados (JSONB)
        [JsonPropertyName("cores")]
        public List<CorDetalheDto> Cores { get; set; } = new List<CorDetalheDto>();
        [JsonPropertyName("erros")]
        public List<ErroDetalheDto> Erros { get; set; } = new List<ErroDetalheDto>();
    }
}