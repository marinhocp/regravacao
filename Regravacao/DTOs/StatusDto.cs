using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Supabase.Postgrest;

namespace Regravacao.DTOs
{
    [Table("TblStatus")]
    public class StatusDto : BaseModel 
    {
        // Chave primária definida
        [PrimaryKey("id_status", false)]
        public int IdStatus { get; set; }

        [Column("descricao_status")]
        // Removido 'required'
        public string DescricaoStatus { get; set; }
    }
}