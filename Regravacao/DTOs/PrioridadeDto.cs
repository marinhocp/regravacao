using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{

    [Table("TblPrioridade")]
    public class PrioridadeDto
    {
        [Column("id_prioridade")]
        public int IdPrioridade { get; set; }

        [Column("prioridade")]
        public required string DescricaoPrioridade { get; set; }
    }
}