using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{

    [Table("TblPrioridade")]
    public class PrioridadeModel
    {
        [Column("id_prioridade")]
        public int IdPrioridade { get; set; }

        [Column("prioridade")]
        public required string DescricaoPrioridade { get; set; }
    }
}