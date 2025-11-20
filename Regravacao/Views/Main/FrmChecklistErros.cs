using System.Runtime.InteropServices;
using Regravacao.Services.Regravacao;
using Regravacao.DTOs;
using Regravacao.Services.DetalhesDeErros;

namespace Regravacao.Views
{
    public partial class FrmChecklistErros : Form
    {
        private readonly IRegravacaoService _regravacaoService;
        private readonly IDetalhesDeErrosService _detalhesDeErrosService;
        public int[]? IdsErrosSelecionados { get; private set; }
        public List<int> IdsErrosSelecionadosAnteriores { get; set; } = [];

        // Armazena a lista completa do banco de dados
        private List<DetalhesDeErrosDto> _listaErrosCompleta = [];

        public FrmChecklistErros(
            IRegravacaoService regravacaoService,
            IDetalhesDeErrosService detalhesDeErrosService)
        {
            InitializeComponent();
            _regravacaoService = regravacaoService;
            _detalhesDeErrosService = detalhesDeErrosService;

            this.Load += FrmChecklistErros_Load;
            // ✅ NOVO: Vincula o método de filtro ao evento TextChanged
            TxbBuscarErro.TextChanged += TxbBuscarErro_TextChanged;
        }

        // Construtor sem parâmetros para o modo Designer
        public FrmChecklistErros() => InitializeComponent();

        private void Btn_fechar_Click(object sender, EventArgs e) => Close();
        private void button4_Click(object sender, EventArgs e) => Close();

        // O método BtnLimparCampoBuscar_Click será simplificado para apenas chamar o Clear,
        // o que por sua vez dispara o TextChanged e limpa o filtro.
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

        // ----------------------------------------------------------------------
        // MÉTODOS DE DADOS E EVENTOS
        // ----------------------------------------------------------------------

        private async void FrmChecklistErros_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Chamada assíncrona ao serviço para obter a lista de DTOs
                List<DetalhesDeErrosDto> listaErros = await _detalhesDeErrosService.ListarTodosErrosDtoAsync();

                if (listaErros.Count > 0)
                {
                    // 🛑 2. Armazena a lista completa para futuras operações de filtro
                    _listaErrosCompleta = listaErros;

                    // 3. Preenchimento do CheckedListBox
                    CxbListErros.DataSource = _listaErrosCompleta;
                    CxbListErros.DisplayMember = "DescricaoErro";
                    CxbListErros.ValueMember = "IdDetalhesErros";

                    // 🛑 4. Aplicar a seleção de itens que vieram do FrmMain
                    if (IdsErrosSelecionadosAnteriores.Count > 0)
                    {
                        for (int i = 0; i < CxbListErros.Items.Count; i++)
                        {
                            if (CxbListErros.Items[i] is DetalhesDeErrosDto dto)
                            {
                                if (IdsErrosSelecionadosAnteriores.Contains(dto.IdDetalhesErros))
                                {
                                    CxbListErros.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de erros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxbBuscarErro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            // Se a lista completa não foi carregada (erro no load), sai
            if (_listaErrosCompleta == null || !_listaErrosCompleta.Any()) return;

            // 🛑 1. Consolidar seleções feitas na view atual ANTES de mudar o DataSource
            ConsolidarSelecoes();

            string termoBusca = TxbBuscarErro.Text.Trim().ToLower();

            List<DetalhesDeErrosDto> listaFiltrada;

            if (string.IsNullOrEmpty(termoBusca))
            {
                // Sem filtro: usa a lista completa
                listaFiltrada = _listaErrosCompleta;
            }
            else
            {
                // Aplica o filtro na lista completa (busca por DescricaoErro)
                listaFiltrada = _listaErrosCompleta
                    .Where(e => e.DescricaoErro.ToLower().Contains(termoBusca))
                    .ToList();
            }

            // 2. Atualiza o DataSource com a lista filtrada/completa
            CxbListErros.DataSource = listaFiltrada;
            CxbListErros.DisplayMember = "DescricaoErro";
            CxbListErros.ValueMember = "IdDetalhesErros";

            // 3. Reaplicar a seleção APENAS com base no storage persistente (que agora está atualizado)
            for (int i = 0; i < CxbListErros.Items.Count; i++)
            {
                // Certifique-se de que o item é o DTO esperado
                if (CxbListErros.Items[i] is DetalhesDeErrosDto dto)
                {
                    // Verifica se este item (visível) está no storage persistente
                    if (IdsErrosSelecionadosAnteriores.Contains(dto.IdDetalhesErros))
                    {
                        CxbListErros.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void ConsolidarSelecoes()
        {
            // A lista atual do CheckedListBox pode estar filtrada, mas todos os itens
            // checados precisam ser refletidos no storage persistente.

            // 1. Identificar todos os DTOs atualmente visíveis
            var dtosAtuais = CxbListErros.Items.Cast<DetalhesDeErrosDto>().ToList();

            // 2. Identificar quais DTOs estão checados AGORA
            var idsChecadosAtuais = CxbListErros.CheckedItems
                .Cast<DetalhesDeErrosDto>()
                .Select(dto => dto.IdDetalhesErros)
                .ToHashSet();

            // 3. Identificar quais DTOs foram desmarcados (estavam checados, mas não estão mais)
            var idsDesmarcados = dtosAtuais
                .Where(dto => !idsChecadosAtuais.Contains(dto.IdDetalhesErros) && IdsErrosSelecionadosAnteriores.Contains(dto.IdDetalhesErros))
                .Select(dto => dto.IdDetalhesErros)
                .ToList();

            // 4. Remover os desmarcados do storage persistente
            IdsErrosSelecionadosAnteriores.RemoveAll(id => idsDesmarcados.Contains(id));

            // 5. Adicionar os recém-marcados ao storage persistente
            var idsNovos = idsChecadosAtuais.Where(id => !IdsErrosSelecionadosAnteriores.Contains(id));
            IdsErrosSelecionadosAnteriores.AddRange(idsNovos);
        }

        private void BtnOkErro_Click(object sender, EventArgs e)
        {
            // 🛑 NOVO: Consolidar uma última vez antes de fechar para pegar as últimas mudanças
            ConsolidarSelecoes();

            // 1. Coletar os IDs dos itens marcados FINALMENTE
            // Pega os IDs do storage persistente (que agora contém todos os IDs selecionados)
            var idsSelecionados = IdsErrosSelecionadosAnteriores.ToArray();

            // 2. Armazenar o array coletado na propriedade pública
            IdsErrosSelecionados = idsSelecionados;

            // 3. Sinalizar ao FrmMain que a operação foi um sucesso e fechar o formulário
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnLimparCheckbox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CxbListErros.Items.Count; i++)
            {
                CxbListErros.SetItemChecked(i, false);
            }

            // IMPORTANTE: Limpar o storage persistente
            // Como o usuário limpou visualmente todos os itens, 
            // precisamos garantir que nossa lista mestre de seleções também seja limpa.
            IdsErrosSelecionadosAnteriores.Clear();
        }
    }
}