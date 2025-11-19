using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{
    [Table("TblCargo")]
    public class CargoModel
    {
        [Column("id_cargo")]
        public int IdCargo { get; set; }

        [Column("descricao_cargo")]
        public required string DescricaoCargo { get; set; }
    }
}