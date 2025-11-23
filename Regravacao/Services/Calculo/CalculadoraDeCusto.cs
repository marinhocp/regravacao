using Regravacao.DTOs.Calculo;
using System.Collections.Generic;
using System.Linq;

namespace Regravacao.Services.Calculo
{
    public class CalculadoraDeCusto
    {
        public CalculoResultadoDto Calcular(
            List<CorCalculoDto> coresParaCalcular,
            decimal margemCorte,
            decimal fatorCalculo,
            decimal maoObra)
        {
            decimal medidaTotal = 0m;
            decimal custoTotal = 0m;

            List<CorCalculoDto> coresAtivas = coresParaCalcular
                .Where(c => c.EstaTotalmenteMarcada)
                .ToList();

            int quantidadeCoresAtivas = coresAtivas.Count;

            decimal maoObraParcial = 0m;
            if (quantidadeCoresAtivas > 0 && maoObra > 0m)
            {
                maoObraParcial = maoObra / quantidadeCoresAtivas;
            }

            var resultadosParciais = new List<ResultadoParcialDto>();

            foreach (var cor in coresParaCalcular)
            {
                decimal medidaParcial = 0m;
                decimal custoParcial = 0m;

                // Regra: Só calcula se estiver marcado E Largura/Comprimento > 0
                if (cor.EstaTotalmenteMarcada && cor.Largura > 0m && cor.Comprimento > 0m)
                {
                    medidaParcial = (cor.Largura + margemCorte) * (cor.Comprimento + margemCorte);
                    custoParcial = (medidaParcial * fatorCalculo) + maoObraParcial;

                    medidaTotal += medidaParcial;
                    custoTotal += custoParcial;
                }

                resultadosParciais.Add(new ResultadoParcialDto
                {
                    NumeroCor = cor.NumeroCor,
                    MedidaParcial = medidaParcial,
                    CustoParcial = custoParcial
                });
            }

            return new CalculoResultadoDto
            {
                MedidaTotal = medidaTotal,
                CustoTotal = custoTotal,
                ResultadosParciais = resultadosParciais
            };
        }
    }
}