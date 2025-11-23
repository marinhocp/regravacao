using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Supabase.Postgrest;

namespace Regravacao.DTOs
{
    [Table("TblMotivosPrincipais")]
    public class MotivosPrincipaisDto : BaseModel // Herança obrigatória
    {
        // Chave primária definida para o Postgrest
        [PrimaryKey("id_motivo_principal", false)]
        public int IdMotivoPrincipal { get; set; }

        [Column("motivo_principal")]
        // Removido 'required'
        public string MotivoPrincipal { get; set; }
    }
}