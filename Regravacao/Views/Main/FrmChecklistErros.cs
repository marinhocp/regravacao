using System.Runtime.InteropServices;
using Regravacao.Services.Regravacao;
using Regravacao.DTOs;
using Regravacao.Services.DetalhesDeErros;

namespace Regravacao.Views
{
    public partial class FrmChecklistErros : Form
    {

        // 1. MANTER O SERVIÇO EXISTENTE
        private readonly IRegravacaoService _regravacaoService;

        // 2. ADICIONAR O NOVO SERVIÇO QUE VOCÊ PRECISA NO LOAD
        private readonly IDetalhesDeErrosService _detalhesDeErrosService;


        // 3. CONSTRUTOR PRINCIPAL MODIFICADO para receber AMBOS os serviços


        // 4. Propriedade para armazenar os IDs selecionados (pode ser null se o usuário cancelar)
        public int[]? IdsErrosSelecionados { get; private set; }
        public List<int> IdsErrosSelecionadosAnteriores { get; set; } = [];

        public FrmChecklistErros(
            IRegravacaoService regravacaoService,
            IDetalhesDeErrosService detalhesDeErrosService) // <-- Novo parâmetro
        {
            InitializeComponent();
            _regravacaoService = regravacaoService;
            _detalhesDeErrosService = detalhesDeErrosService; // <-- Inicialização!

            this.Load += FrmChecklistErros_Load; // Garante que o Load está ligado
        }

        // Construtor sem parâmetros para o modo Designer
        public FrmChecklistErros() => InitializeComponent();

        private void Btn_fechar_Click(object sender, EventArgs e) => Close();
        private void button4_Click(object sender, EventArgs e) => Close();
        private void BtnLimparCampoBuscar_Click(object sender, EventArgs e) => TxbBuscarErro.Clear();

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

        private async void FrmChecklistErros_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Chamada assíncrona ao serviço para obter a lista de DTOs
                List<DetalhesDeErrosDto> listaErros = await _detalhesDeErrosService.ListarTodosErrosDtoAsync();

                if (listaErros.Count > 0)
                {
                    // 2. Preenchimento do CheckedListBox
                    CxbListErros.DataSource = listaErros;
                    CxbListErros.DisplayMember = "DescricaoErro";
                    CxbListErros.ValueMember = "IdDetalhesErros";

                    // 🛑 CÓDIGO FALTANDO: Aplicar a seleção anterior
                    if (IdsErrosSelecionadosAnteriores.Count > 0)
                    {
                        // Percorre a lista de itens vinculados no CheckedListBox
                        for (int i = 0; i < CxbListErros.Items.Count; i++)
                        {
                            // O item no CheckedListBox é um objeto DetalhesDeErrosDto
                            if (CxbListErros.Items[i] is DetalhesDeErrosDto dto)
                            {
                                // Verifica se o ID do DTO atual está na lista de IDs a serem mantidos
                                if (IdsErrosSelecionadosAnteriores.Contains(dto.IdDetalhesErros))
                                {
                                    // Marca o item no índice 'i' como checado
                                    CxbListErros.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Tratamento de erro, caso a conexão ou o Supabase falhem
                MessageBox.Show($"Erro ao carregar lista de erros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOkErro_Click(object sender, EventArgs e)
        {
            // 1. Coletar os IDs dos itens marcados
            // O CheckedItems do CheckedListBox é uma coleção de objetos (os DTOs)
            var idsSelecionados = CxbListErros.CheckedItems
                // Converte o objeto genérico de volta para o DTO
                .Cast<DetalhesDeErrosDto>()

                // Seleciona a propriedade de ID de cada DTO
                .Select(dto => dto.IdDetalhesErros)

                // Converte para array de int[] (conforme a propriedade IdsErrosSelecionados espera)
                .ToArray();

            // 2. Armazenar o array coletado na propriedade pública
            IdsErrosSelecionados = idsSelecionados;

            // 3. Sinalizar ao FrmMain que a operação foi um sucesso e fechar o formulário
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
