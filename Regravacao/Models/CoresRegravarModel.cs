using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Regravacao.Models
{
    [Table("TblCargo")]
    public class CoresRegravarModel
    {
        [Column("id_regravacao")]
        public int IdRegravacao { get; set; }
        
        [Column("id_cor")]
        public int IdCor { get; set; }

        [Column("largura")]
        public decimal Largura { get; set; }

        [Column("comprimento")]
        public decimal Comprimento { get; set; }

        [Column("custo_estimado")]
        public decimal CustoEstimado { get; set; }

        [Column("margem_corte")]
        public decimal MargemCorte { get; set; }

        [Column("fator_calculo")]
        public decimal FatorCalculo { get; set; }

        [Column("mao_obra")]
        public decimal? MaoObra { get; set; }
    }
}