using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Regravacao.Services.Regravacao;

namespace Regravacao.Views
{
    public partial class FrmGraficosEstatistica : Form
    {
        private readonly IRegravacaoService _regravacaoService;

        public FrmGraficosEstatistica(IRegravacaoService regravacaoService)
        {
            InitializeComponent();
            _regravacaoService = regravacaoService;
        }

        // Construtor sem parâmetros — apenas para o modo Design
        public FrmGraficosEstatistica()
        {
            InitializeComponent();
        }

        #region MÉTODO PARA ARRASTAR O FORMULÁRIO
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
