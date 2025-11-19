using System;
using System.Windows.Forms;
using Regravacao.Services.Regravacao;

namespace Regravacao.Views
{
    public partial class FrmConfiguracoes : Form
    {
        private readonly IRegravacaoService _regravacaoService;

        // ✅ Agora com injeção de dependência
        public FrmConfiguracoes(IRegravacaoService regravacaoService)
        {
            InitializeComponent();
            _regravacaoService = regravacaoService;
        }

        private void BtnCancelarConfiguracoes_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ✅ Exemplo: salvar uma configuração (pode ser um usuário, parâmetro, etc.)
        private async void BtnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            try
            {
                // Exemplo fictício — aqui você chamaria o seu serviço
                // await _regravacaoService.AtualizarConfiguracoes(configDto);

                MessageBox.Show("Configurações salvas com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configurações:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
