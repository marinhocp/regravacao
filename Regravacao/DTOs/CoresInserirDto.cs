using System.Text.Json.Serialization;

namespace Regravacao.DTOs
{
    // DTO otimizado para o JSONB 'p_cores'
    public class CoresInserirDto
    {
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }

        [JsonPropertyName("largura")]
        public decimal Largura { get; set; }

        [JsonPropertyName("comprimento")]
        public decimal Comprimento { get; set; }

        [JsonPropertyName("custo_estimado")]
        public decimal CustoEstimado { get; set; }
    }
}