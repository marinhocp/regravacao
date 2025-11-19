using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{

    [Table("TblConfiguracoesCusto")]
    public class ConfiguracoesCustoModel
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
