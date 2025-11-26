using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Text.Json.Serialization;

namespace Regravacao.Models
{
    [Table("TblCores")]
    public class CoresModel : BaseModel // Ou Model, dependendo do seu projeto
    {
        [PrimaryKey("id_cor", false)]
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }

        [Column("paleta")]
        [JsonPropertyName("paleta")]
        public string Paleta { get; set; } = string.Empty;

        [Column("nome_cor")]
        [JsonPropertyName("nome_cor")]
        public string NomeCor { get; set; } = string.Empty;

        [Column("codigo_hexadecimal")]
        [JsonPropertyName("codigo_hexadecimal")]
        public string CodigoHexadecimal { get; set; } = string.Empty;

        [Column("codigo_rgb")] // ✅ NOVO CAMPO
        [JsonPropertyName("codigo_rgb")]
        public string CodigoRgb { get; set; } = string.Empty;

        [Column("codigo_cmyk")] // ✅ NOVO CAMPO
        [JsonPropertyName("codigo_cmyk")]
        public string CodigoCmyk { get; set; } = string.Empty;
    }
}