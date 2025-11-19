using Supabase.Postgrest.Attributes;

namespace Regravacao.DTOs
{

    [Table("TblTipoUsuario")]
    public class TipoUsuarioDto
    {
        [Column("id_tipo_usuario")]
        public int IdTipoUsuario { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }
    }
}