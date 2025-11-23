using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Supabase.Postgrest;

namespace Regravacao.DTOs
{
    [Table("TblPrioridade")]
    public class PrioridadeDto : BaseModel // ✅ Herança obrigatória
    {
        // Chave primária definida para o Postgrest
        [PrimaryKey("id_prioridade", false)]
        public int IdPrioridade { get; set; }

        [Column("prioridade")]
        // Removido 'required'
        public string DescricaoPrioridade { get; set; }
    }
}