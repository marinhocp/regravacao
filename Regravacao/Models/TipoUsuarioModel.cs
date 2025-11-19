using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{
    [Table("TblTipoUsuario")]
    public class TipoUsuarioModel
    {
        [Column("id_tipo_usuario")]
        public int IdTipoUsuario { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }
    }
}