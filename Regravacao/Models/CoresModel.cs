using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models; // Ou using NOME_DO_SEU_NAMESPACE.BaseModel, se for Base
using System.Text.Json.Serialization;

namespace Regravacao.Models
{
    [Table("TblCores")]
    public class CoresModel : BaseModel // Ou Model, dependendo do seu projeto
    {
        [PrimaryKey("id_cor", false)]
        [JsonPropertyName("id_cor")]
        public int IdCor { get; set; }

        [Column("nome_cor")]
        [JsonPropertyName("nome_cor")]
        // ✅ REMOVIDO: required. Inicializado com string.Empty para segurança.
        public string NomeCor { get; set; } = string.Empty;

        [Column("codigo_exadecimal")]
        [JsonPropertyName("codigo_exadecimal")]
        // ✅ REMOVIDO: required. 
        public string CodigoExadecimal { get; set; } = string.Empty;
    }
}