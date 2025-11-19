using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace Regravacao.DTOs
{
    [Table("TblFuncionarios")]
    public class FuncionariosDto : BaseModel
    {
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

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