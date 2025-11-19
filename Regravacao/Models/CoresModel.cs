using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{

    [Table("TblCores")]
    public class CoresModel
    {
        [Column("id_cor")]
        public int IdCor { get; set; }

        [Column("nome_cor")]
        public required string NomeCor { get; set; }

        [Column("codigo_exadecimal")]
        public required string CodigoExadecimal { get; set; }
    }
}