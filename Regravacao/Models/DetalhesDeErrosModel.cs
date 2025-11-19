using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{
    [Table("TblDetalhesDeErros")]
    public class DetalhesDeErrosModel : BaseModel
    {
        [PrimaryKey("id_detalhes_erros", false)]
        public int IdDetalhesErros { get; set; }

        // ✅ MAPEAMENTO CORRIGIDO: Propriedade C# -> Coluna DB
        [Column("descricao_erro")]
        public string DescricaoErro { get; set; } = string.Empty;
    }
}