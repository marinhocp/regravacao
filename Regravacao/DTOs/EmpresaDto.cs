using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{
    [Table("TblEmpresa")]
    public class EmpresaDto
    {
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }

        [Column("nome_empresa")]
        public required string NomeEmpresa { get; set; }

        [Column("id_status")]
        public int IdStatus { get; set; }
    }
}