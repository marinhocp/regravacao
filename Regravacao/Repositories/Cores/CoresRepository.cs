using Regravacao.DTOs;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Regravacao.Repositories
{
    public class CoresRepository : ICoresRepository
    {
        private readonly Client _supabase;

        public CoresRepository(Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<List<CoresDto>> ListarTodasAsync()
        {
            // Seleciona apenas as colunas que você usa para a UI (pode adicionar paleta, rgb, cmyk se quiser)
            string colunas = "id_cor, paleta, nome_cor, codigo_hexadecimal, codigo_rgb, codigo_cmyk";

            var resposta = await _supabase
                .From<CoresDto>()
                .Select(colunas)
                .Limit(4000) // limite seguro
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro na API Supabase (cores): {resposta.ResponseMessage.ReasonPhrase}");
            }

            return resposta.Models.ToList();
        }
    }
}
