using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Supabase.Postgrest;

namespace Regravacao.DTOs
{
    // O DTO deve refletir a tabela
    [Table("TblEmpresa")]
    public class EmpresaDto : BaseModel // ✅ Herança obrigatória para Supabase
    {
        // ✅ Chave primária definida para o Postgrest
        [PrimaryKey("id_empresa", false)]
        public int IdEmpresa { get; set; }

        [Column("nome_empresa")]
        // ✅ Removido 'required' para compatibilidade com o construtor new() do Postgrest
        public string NomeEmpresa { get; set; }

        [Column("id_status")]
        public int IdStatus { get; set; }
    }
}