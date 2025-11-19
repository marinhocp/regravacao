using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{
    [Table("TblDetalhesDeErros")]
    public class DetalhesDeErrosDto
    {
        [Column("id_detalhes_erros")]
        public int IdDetalhesErros { get; set; }

        [Column("descricao_erro")]
        public required string DescricaoErro { get; set; }
    }
}