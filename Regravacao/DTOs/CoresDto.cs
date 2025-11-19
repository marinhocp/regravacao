using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{
    [Table("TblCores")]
    public class CoresDto
    {
        [Column("id_cor")]
        public int IdCor { get; set; }

        [Column("nome_cor")]
        public required string NomeCor { get; set; }

        [Column("codigo_exadecimal")]
        public required string CodigoExadecimal { get; set; }
    }
}