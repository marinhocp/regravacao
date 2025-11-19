using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{
    [Table("TblMotivosPrincipais")]
    public class MotivosPrincipaisModel
    {
        [Column("id_motivo_principal")]
        public int IdMotivoPrincipal { get; set; }

        [Column("motivo_principal")]
        public required string MotivoPrincipal { get; set; }
    }
}