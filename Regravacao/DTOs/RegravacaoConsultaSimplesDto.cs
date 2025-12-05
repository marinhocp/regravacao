using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;

namespace Regravacao.DTOs
{
    public class RegravacaoConsultaSimplesDto
    {
        // Campos de TblRegravacao
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

        // Campos de JOINs desnormalizados
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

        // 🌟 CAMPOS MODIFICADOS (STRING_AGG do SQL)
        // Mapeia o campo 'nomes_cores' retornado pela função SQL
        [JsonPropertyName("nomes_cores")]
        public string NomesDasCores { get; set; } = string.Empty;

        // Mapeia o campo 'descricao_erros' retornado pela função SQL
        [JsonPropertyName("descricao_erros")]
        public string DescricaoErros { get; set; } = string.Empty;
    }
}