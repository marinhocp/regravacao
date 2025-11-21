using System;
using System.Windows.Forms;
using Regravacao.Services.Configuracoes; // Depende da Camada de Serviço
using Regravacao.Services.Regravacao;    // Dependência de exemplo
using Regravacao.DTOs;
using System.Globalization;

namespace Regravacao.Views
{
    public partial class FrmConfiguracoes : Form
    {
        private readonly IConfiguracoesCustoService _configuracoesCustoService;
        private readonly IRegravacaoService _regravacaoService; // Exemplo de outra dependência

        // Construtor com Injeção de Dependência
        public FrmConfiguracoes(
            IConfiguracoesCustoService configuracoesCustoService,
            IRegravacaoService regravacaoService)
        {
            InitializeComponent();
            _configuracoesCustoService = configuracoesCustoService;
            _regravacaoService = regravacaoService;

            this.Load += FrmConfiguracoes_Load;
        }

        private void BtnCancelarConfiguracoes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FrmConfiguracoes_Load(object sender, EventArgs e)
        {
            try
            {
                // Busca dados usando a camada de Serviço
                ConfiguracoesCustoDto? config = await _configuracoesCustoService.ObterConfiguracoesCustoAsync();

                CultureInfo culture = new CultureInfo("pt-BR");

                if (config != null)
                {
                    TxbMargem.Text = config.MargemCorte.ToString(culture);
                    TxbFatorCusto.Text = config.FatorCalculo.ToString(culture);
                    TxbMaoObraEOutros.Text = config.MaoObra?.ToString(culture) ?? "0";
                }
                else
                {
                    TxbMargem.Text = "0";
                    TxbFatorCusto.Text = "0";
                    TxbMaoObraEOutros.Text = "0";
                    MessageBox.Show("Nenhuma configuração de custo encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar configurações:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            // Define a cultura para garantir que o ponto e vírgula/vírgula seja tratado corretamente (pt-BR usa vírgula)
            CultureInfo culture = new CultureInfo("pt-BR");

            // Variáveis para armazenar os valores convertidos
            decimal margemCorte;
            decimal fatorCalculo;
            decimal? maoObra = null; // Inicializado como nulo para campos opcionais

            try
            {
                // 1. VALIDAÇÃO E PARSE DOS DADOS DE ENTRADA

                // Valida Margem de Corte (Campo Obrigatório)
                if (!decimal.TryParse(TxbMargem.Text, NumberStyles.Currency, culture, out margemCorte))
                {
                    MessageBox.Show("Margem de Corte inválida. Verifique o formato numérico.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxbMargem.Focus();
                    return;
                }

                // Valida Fator de Cálculo (Campo Obrigatório)
                if (!decimal.TryParse(TxbFatorCusto.Text, NumberStyles.Currency, culture, out fatorCalculo))
                {
                    MessageBox.Show("Fator de Cálculo inválido. Verifique o formato numérico.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxbFatorCusto.Focus();
                    return;
                }

                // Valida Mão de Obra e Outros (Campo Opcional)
                if (!string.IsNullOrWhiteSpace(TxbMaoObraEOutros.Text))
                {
                    if (decimal.TryParse(TxbMaoObraEOutros.Text, NumberStyles.Currency, culture, out decimal valorMaoObra))
                    {
                        maoObra = valorMaoObra;
                    }
                    else
                    {
                        MessageBox.Show("Valor de Mão de Obra e Outros inválido. Verifique o formato numérico.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxbMaoObraEOutros.Focus();
                        return;
                    }
                }
                // Se o campo for vazio, 'maoObra' permanece 'null', o que é esperado para um decimal?

                // 2. CRIAÇÃO DO DTO
                ConfiguracoesCustoDto configDto = new ConfiguracoesCustoDto
                {
                    // Importante: No seu repositório, assumimos que esta tabela tem um ID fixo (ex: 1).
                    // Você deve garantir que o ID seja o correto para que o Supabase realize o UPDATE.
                    IdConfigCusto = 1,
                    MargemCorte = margemCorte,
                    FatorCalculo = fatorCalculo,
                    MaoObra = maoObra
                };

                // 3. CHAMADA AO SERVIÇO
                await _configuracoesCustoService.AtualizarConfiguracoesCustoAsync(configDto);

                MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Opcional: fechar o formulário após salvar
            }
            catch (ArgumentException ex)
            {
                // Captura exceções de lógica de negócio lançadas no Service (ex: valor negativo)
                MessageBox.Show($"Não foi possível salvar a configuração (Regra de Negócio):\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Captura exceções de Repositório (banco de dados, Supabase) ou outras falhas
                MessageBox.Show($"Erro inesperado ao salvar configurações:\n{ex.Message}", "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}