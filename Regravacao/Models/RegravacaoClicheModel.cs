using Regravacao.DTOs;
using Supabase.Postgrest.Attributes;

namespace Regravacao.Models
{

    [Table("TblRegravacao")]
    public class RegravacaoClicheModel
    {
        [Column("id_regravacao")]
        public int IdRegravacao { get; set; }

        [Column("requerimento_atual")]
        public required string RequerimentoAtual { get; set; }

        [Column("requerimento_novo")]
        public string? RequerimentoNovo { get; set; }

        [Column("descricao_arte")]
        public required string DescricaoArte { get; set; }

        [Column("versao")]
        public short Versao { get; set; }                // smallint

        [Column("id_quem_finalizou")]
        public int IdQuemFinalizou { get; set; }

        [Column("id_conferente")]
        public int IdConferente { get; set; }

        [Column("id_solicitante")]
        public int IdSolicitante { get; set; }

        [Column("id_enviar_para")]
        public int IdEnviarPara { get; set; }

        [Column("id_cobrar_de_quem")]
        public int? IdCobrarDeQuem { get; set; }

        [Column("id_motivo_principal")]
        public int IdMotivoPrincipal { get; set; }

        [Column("qtde_placas")]
        public short QtdePlacas { get; set; }            // smallint

        [Column("id_prioridade")]
        public int IdPrioridade { get; set; }

        [Column("id_status")]
        public int IdStatus { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("thumbnail")]
        public string? Thumbnail { get; set; }

        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Column("id_material")]
        public short? IdMaterial { get; set; }           // smallint, nullable


        // relações agregadas (opcional, dependendo do SELECT)
        public List<CoresRegravarDto>? Cores { get; set; }
        public List<DetalhesDeErrosDto>? Erros { get; set; }
    }
}