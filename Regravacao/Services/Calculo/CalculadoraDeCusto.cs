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
            decimal percentualMaoObra) // Recebe o valor como INTEIRO (ex: 10)
        {
            decimal medidaTotal = 0m;
            decimal custoTotal = 0m;

            // 🎯 CONVERSÃO DO PERCENTUAL: 10 -> 0.10
            // Isso deve ser feito APENAS UMA VEZ.
            decimal fatorPercentual = percentualMaoObra / 100m;

            var resultadosParciais = new List<ResultadoParcialDto>();

            foreach (var cor in coresParaCalcular)
            {
                decimal medidaParcial = 0m;
                decimal custoParcial = 0m;

                if (cor.EstaTotalmenteMarcada && cor.Largura > 0m && cor.Comprimento > 0m)
                {
                    medidaParcial = (cor.Largura + margemCorte) * (cor.Comprimento + margemCorte);

                    // 1. Calcula o custo SÓ do material
                    decimal custoMaterial = medidaParcial * fatorCalculo;

                    // 2. Calcula a Mão de Obra usando o fator percentual ajustado
                    decimal maoObraCalculada = custoMaterial * fatorPercentual;

                    // 3. O Custo Parcial é a soma do material com a mão de obra percentual
                    custoParcial = custoMaterial + maoObraCalculada;

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