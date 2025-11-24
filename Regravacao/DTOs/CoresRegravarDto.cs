using Supabase.Postgrest.Attributes;

namespace Regravacao.DTOs
{
     [Table("TblCoresRegravar")]

    public class CoresRegravarDto
    {
        [Column("id_regravacao")]
        public int IdRegravacao { get; set; }    // PK parte 1

        [Column("id_cor")]
        public int IdCor { get; set; }           // PK parte 2 / FK

        [Column("largura")]
        public required decimal Largura { get; set; }

        [Column("comprimento")]
        public required decimal Comprimento { get; set; }

        [Column("custo_estimado")]
        public required decimal CustoEstimado { get; set; }

        [Column("margem_corte")]
        public required decimal MargemCorte { get; set; }

        [Column("fator_calculo")]
        public required decimal FatorCalculo { get; set; }

        [Column("mao_obra")]
        public decimal? MaoObra { get; set; }
    }
}