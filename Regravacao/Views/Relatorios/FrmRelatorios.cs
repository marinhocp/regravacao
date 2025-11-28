using System;
using System.Windows.Forms;
using Regravacao.Services.Regravacao;

namespace Regravacao.Views
{
    public partial class FrmRelatorios : Form
    {
        private readonly IRegravacaoService _regravacaoService;

        // Injeção de dependência
        public FrmRelatorios(IRegravacaoService regravacaoService)
        {
            InitializeComponent();
            _regravacaoService = regravacaoService;
        }

        // Construtor sem parâmetros para o Designer
        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void TxbBuscarRelatorio_TextChanged(object sender, EventArgs e)
        {
            BtnLimparCampoBuscar.Visible = !string.IsNullOrEmpty(TxbBuscarRelatorio.Text);
        }

        private void BtnLimparCampoBuscar_Click(object sender, EventArgs e)
        {
            TxbBuscarRelatorio.Clear();
        }

        private void BtnCancelarRelatorio_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
