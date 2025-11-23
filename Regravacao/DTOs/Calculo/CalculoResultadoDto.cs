using System.Collections.Generic;

namespace Regravacao.DTOs.Calculo
{
    public class CalculoResultadoDto
    {
        public decimal MedidaTotal { get; set; }
        public decimal CustoTotal { get; set; }
        public List<ResultadoParcialDto> ResultadosParciais { get; set; } = new List<ResultadoParcialDto>();
    }
}