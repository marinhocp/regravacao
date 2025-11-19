using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.DTOs
{
    [Table("TblConfiguracoesCusto")]
    public class ConfiguracoesCustoDto
    {
        [Column("id_config_custo")]
        public int IdConfigCusto { get; set; }
        
        [Column("margem_corte")]
        public required decimal MargemCorte { get; set; }

        [Column("fator_calculo")]
        public required decimal FatorCalculo { get; set; }

        [Column("mao_obra")]
        public decimal? MaoObra { get; set; }
    }
}