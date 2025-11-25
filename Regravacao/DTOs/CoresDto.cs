// Em: Regravacao.DTOs
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Text.Json.Serialization;

namespace Regravacao.DTOs
{
    [Table("TblCores")]
    public class CoresDto : BaseModel
    {
        [PrimaryKey("id_cor", false)]
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }

        [Column("nome_cor")]
        [JsonPropertyName("nome_cor")]
        public string NomeCor { get; set; } = string.Empty;

        [Column("codigo_hexadecimal")]
        [JsonPropertyName("codigo_hexadecimal")]
        public string CodigoHexadecimal { get; set; } = string.Empty;

        [Column("codigo_rgb")]
        [JsonPropertyName("codigo_rgb")]
        public string CodigoRgb { get; set; } = string.Empty;

        [Column("codigo_cmyk")]
        [JsonPropertyName("codigo_cmyk")]
        public string CodigoCmyk { get; set; } = string.Empty;
    }
}