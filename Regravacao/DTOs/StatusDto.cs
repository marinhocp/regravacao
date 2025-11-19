using Supabase.Postgrest.Attributes;

namespace Regravacao.DTOs
{
    [Table("TblStatus")]
    public class StatusDto
    {
        [Column("id_status")]
        public int IdStatus { get; set; }

        [Column("descricao_status")]
        public required string DescricaoStatus { get; set; }
    }
}