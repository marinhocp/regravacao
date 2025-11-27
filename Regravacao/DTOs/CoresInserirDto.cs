using System.Text.Json.Serialization;
using Supabase.Postgrest.Attributes;

namespace Regravacao.DTOs
{
    [Table("TblCoresRegravar")]
    public class CoresInserirDto
    {
        [Column("id_cor")]
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }

        [Column("largura")]
        [JsonPropertyName("largura")]
        public decimal Largura { get; set; }

        [Column("comprimento")]
        [JsonPropertyName("comprimento")]
        public decimal Comprimento { get; set; }

        [Column("custo_estimado")]
        [JsonPropertyName("custo_estimado")]
        public decimal CustoEstimado { get; set; }
    }
}
