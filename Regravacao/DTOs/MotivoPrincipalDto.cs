using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{

    [Table("TblMotivosPrincipais")]
    public class MotivosPrincipaisDto
    {
        [Column("id_motivo_principal")]
        public int IdMotivoPrincipal { get; set; }
        
        [Column("motivo_principal")]
        public required string MotivoPrincipal { get; set; }
    }
}