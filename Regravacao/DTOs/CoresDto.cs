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

        [Column("codigo_hexadecimal")] // ✅ CORRIGIDO: Nome da coluna
        public required string CodigoHexadecimal { get; set; }

        [Column("codigo_rgb")] // ✅ NOVO CAMPO
        public required string CodigoRgb { get; set; }

        [Column("codigo_cmyk")] // ✅ NOVO CAMPO
        public required string CodigoCmyk { get; set; }
    }
}