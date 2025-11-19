namespace Regravacao.Models
{
    public class EstatisticasRegravacaoModel
    {
        public long TotalGeral { get; set; }
        public required List<FuncionarioQuantidade> PorFinalizado { get; set; }
        public required List<FuncionarioQuantidade> PorConferente { get; set; }
        public required List<FuncionarioQuantidade> PorSolicitante { get; set; }
        public required List<EmpresaQuantidade> PorEnviarPara { get; set; }
        public required List<FuncionarioQuantidade> PorCobrarDeQuem { get; set; }
        public required List<MaterialQuantidade> PorMaterial { get; set; }
    }

    public class FuncionarioQuantidade
    {
        public int IdFuncionario { get; set; }
        public required string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public class EmpresaQuantidade
    {
        public int IdEmpresa { get; set; }
        public required string NomeEmpresa { get; set; }
        public int Quantidade { get; set; }
    }

    public class MaterialQuantidade
    {
        public int IdMaterial { get; set; }
        public required string Material { get; set; }
        public int Quantidade { get; set; }
    }
}
