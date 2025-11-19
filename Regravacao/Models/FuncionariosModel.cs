using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{
    [Table("TblFuncionarios")]
    public class FuncionariosModel
    {
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("id_tipo_usuario")]
        public int IdTipoUsuario { get; set; }

        [Column("id_status")]
        public int IdStatus { get; set; }

        [Column("id_cargo")]
        public int IdCargo { get; set; }

        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        [Column("uuid")]
        public Guid? Uuid { get; set; }
    }
}