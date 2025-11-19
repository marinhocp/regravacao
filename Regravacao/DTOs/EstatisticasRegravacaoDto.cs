namespace Regravacao.DTOs
{
    public class EstatisticasRegravacaoDto
    {
        public long TotalGeral { get; set; }
        public required List<FuncionarioQuantidadeDto> PorFinalizado { get; set; }
        public required List<FuncionarioQuantidadeDto> PorConferente { get; set; }
        public required List<FuncionarioQuantidadeDto> PorSolicitante { get; set; }
        public required List<EmpresaQuantidadeDto> PorEnviarPara { get; set; }
        public required List<FuncionarioQuantidadeDto> PorCobrarDeQuem { get; set; }
        public required List<MaterialQuantidadeDto> PorMaterial { get; set; }
    }

    public class FuncionarioQuantidadeDto
    {
        public int IdFuncionario { get; set; }
        public required string Nome { get; set; }
        public int Quantidade { get; set; }
    }

    public class EmpresaQuantidadeDto
    {
        public int IdEmpresa { get; set; }
        public required string NomeEmpresa { get; set; }
        public int Quantidade { get; set; }
    }

    public class MaterialQuantidadeDto
    {
        public int IdMaterial { get; set; }
        public required string Material { get; set; }
        public int Quantidade { get; set; }
    }
}