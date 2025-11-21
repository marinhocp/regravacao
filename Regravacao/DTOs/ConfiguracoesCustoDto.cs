using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
// Adicione este using
using Supabase.Postgrest;

namespace Regravacao.DTOs
{
    [Table("TblConfiguracoesCusto")]
    // ✅ CORREÇÃO 1: Deve herdar de BaseModel
    public class ConfiguracoesCustoDto : BaseModel
    {
        // ✅ CORREÇÃO 2: Define a chave primária da tabela. O 'false' indica que não é auto-incremento.
        [PrimaryKey("id_config_custo", false)]
        public int IdConfigCusto { get; set; }

        [Column("margem_corte")]
        // ✅ CORREÇÃO 3: Removido 'required' para satisfazer a restrição new() do Postgrest
        public decimal MargemCorte { get; set; }

        [Column("fator_calculo")]
        // ✅ CORREÇÃO 3: Removido 'required'
        public decimal FatorCalculo { get; set; }

        [Column("mao_obra")]
        public decimal? MaoObra { get; set; }
    }
}