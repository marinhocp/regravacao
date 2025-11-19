using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{
    [Table("TblStatus")]
    public class StatusModel
    {
        [Column("id_status")]
        public int IdStatus { get; set; }

        [Column("descricao_status")]
        public required string DescricaoStatus { get; set; }
    }
}