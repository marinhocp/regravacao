using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{
    [Table("TblCargo")]
    public class CargoDto
    {
        [Column("id_cargo")]
        public int IdCargo { get; set; }

        [Column("descricao_cargo")]
        public required string DescricaoCargo { get; set; }
    }
}