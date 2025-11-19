using System;
using System.Collections.Generic;
using Supabase.Postgrest.Attributes;

namespace Regravacao.DTOs
{
    [Table("TblRegravacao")]
    public class InserirRegravacaoDto
    {
        [Column("requerimento_atual")]
        public required string RequerimentoAtual { get; set; }

        [Column("requerimento_novo")]
        public string? RequerimentoNovo { get; set; }

        [Column("descricao_arte")]
        public required string DescricaoArte { get; set; }

        [Column("versao")]
        public required short Versao { get; set; }         // smallint

        [Column("id_quem_finalizou")]
        public required int IdQuemFinalizou { get; set; }

        [Column("id_conferente")]
        public required int IdConferente { get; set; }

        [Column("id_solicitante")]
        public required int IdSolicitante { get; set; }

        [Column("id_enviar_para")]
        public required int IdEnviarPara { get; set; }

        [Column("id_cobrar_de_quem")]
        public int? IdCobrarDeQuem { get; set; }           // pode ser nulo no DB

        [Column("id_motivo_principal")]
        public required int IdMotivoPrincipal { get; set; }
        
        [Column("qtde_placas")]
        public required short QtdePlacas { get; set; }     // smallint

        [Column("id_prioridade")]
        public required int IdPrioridade { get; set; }

        [Column("id_status")]
        public required int IdStatus { get; set; }

        [Column("data_cadastro")]
        public DateTime? DataCadastro { get; set; }        // pode ser enviado ou usar default no BD

        [Column("thumbnail")]
        public string? Thumbnail { get; set; }

        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Column("id_material")]
        public required short IdMaterial { get; set; }     // smallint — agora exigido pela sua query

        public List<int>? MotivosErrosIds { get; set; }   // lista de ids de TblDetalhesDeErros
        public required List<CoresInserirDto> Cores { get; set; }
    }
}