using Microsoft.Extensions.DependencyInjection;
using Regravacao.DTOs;
using Regravacao.DTOs.Calculo;
using Regravacao.Helpers;
using Regravacao.Models;
using Regravacao.Services.Auth;
using Regravacao.Services.Calculo;
using Regravacao.Services.Conferente;
using Regravacao.Services.Configuracoes;
using Regravacao.Services.Cores;
using Regravacao.Services.CustoDeQuem;
using Regravacao.Services.DetalhesDeErros;
using Regravacao.Services.Empresa;
using Regravacao.Services.Finalizador;
using Regravacao.Services.MotivosPrincipais;
using Regravacao.Services.Prioridade;
using Regravacao.Services.Regravacao;
using Regravacao.Services.Solicitante;
using Regravacao.Services.Status;
using Regravacao.Views;
using Supabase;
using System.Globalization;
using System.IO;
using Regravacao.Services.Utils;

namespace Regravacao
{
    public partial class FrmMain : Form
    {
        private Panel? overlayPanel;
        private LoginControl? loginControl;
        private readonly int MaxCores = 8;
        private readonly IRegravacaoService _regravacaoService;
        private readonly IDetalhesDeErrosService _detalhesDeErrosService;
        private readonly Client _supabase;
        private System.Windows.Forms.Timer? sessaoTimer;
        private readonly IMaterialService _materialService;
        private readonly IFinalizadorService _finalizadorService;
        private readonly IConferenteService _conferenteService;
        private readonly ISolicitanteService _solicitanteService;
        private readonly IEmpresaService _empresaService;
        private readonly ICustoDeQuemService _custoDeQuemService;
        private readonly IMotivosPrincipaisService _motivosService;
        private readonly IPrioridadeService _prioridadeService;
        private readonly IStatusService _statusService;
        private readonly IConfiguracoesCustoService _configuracoesCustoService;
        private readonly CalculadoraDeCusto _calculadora;
        private readonly ICoresService _coresService;
        private List<DetalhesDeErrosDto> _errosSelecionados = [];
        private decimal _margemCorte = 0m;
        private decimal _fatorCalculo = 0m;
        private decimal? _maoObra = 0m;
        private Image? _thumbnailImage;
        private byte[]? _thumbnailBytes;

        private static readonly (string Chk, string NomeCor, string Largura, string Comprimento, string MedidaParcial, string CustoParcial, string Panel)[] _mapaCores =
     {
        ("CkBCor1", "TxbNomeCor1", "TxbLarguraCor1", "TxbComprimentoCor1", "TxbMedidaPlacaCor1", "TxbCustoParcialPlacaCor1", "PanelCor1"),
        ("CkBCor2", "TxbNomeCor2", "TxbLarguraCor2", "TxbComprimentoCor2", "TxbMedidaPlacaCor2", "TxbCustoParcialPlacaCor2", "PanelCor2"),
        ("CkBCor3", "TxbNomeCor3", "TxbLarguraCor3", "TxbComprimentoCor3", "TxbMedidaPlacaCor3", "TxbCustoParcialPlacaCor3", "PanelCor3"),
        ("CkBCor4", "TxbNomeCor4", "TxbLarguraCor4", "TxbComprimentoCor4", "TxbMedidaPlacaCor4", "TxbCustoParcialPlacaCor4", "PanelCor4"),
        ("CkBCor5", "TxbNomeCor5", "TxbLarguraCor5", "TxbComprimentoCor5", "TxbMedidaPlacaCor5", "TxbCustoParcialPlacaCor5", "PanelCor5"),
        ("CkBCor6", "TxbNomeCor6", "TxbLarguraCor6", "TxbComprimentoCor6", "TxbMedidaPlacaCor6", "TxbCustoParcialPlacaCor6", "PanelCor6"),
        ("CkBCor7", "TxbNomeCor7", "TxbLarguraCor7", "TxbComprimentoCor7", "TxbMedidaPlacaCor7", "TxbCustoParcialPlacaCor7", "PanelCor7"),
        ("CkBCor8", "TxbNomeCor8", "TxbLarguraCor8", "TxbComprimentoCor8", "TxbMedidaPlacaCor8", "TxbCustoParcialPlacaCor8", "PanelCor8"),
    };

        public FrmMain(

          IRegravacaoService regravacaoService,
          IDetalhesDeErrosService detalhesDeErrosService,
          IMaterialService materialService,
          IFinalizadorService finalizadorService,
          IConferenteService conferenteService,
          ISolicitanteService solicitanteService,
          IEmpresaService empresaService,
          ICustoDeQuemService custoDeQuemService,
          IPrioridadeService prioridadeService,
          IMotivosPrincipaisService motivosService,
          IConfiguracoesCustoService configuracoesCustoService,
          IStatusService statusService,
          CalculadoraDeCusto calculadora,
          ICoresService coresService,

          Client supabase)
        {
            InitializeComponent();

            NumUpDQtdePlacas.ValueChanged += NumUpDQtdePlacas_ValueChanged;

            // habilita a seleção do item do DropDownList para todos os ComboBoxes ao digitar uma letra
            CBxMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxFinalizadoPor.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxConferidoPor.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxSolicitante.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxEnviarPara.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxMotivoPrincipal.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxCustoDeQuem.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxSolicitante.DropDownStyle = ComboBoxStyle.DropDownList;

            _regravacaoService = regravacaoService;
            _detalhesDeErrosService = detalhesDeErrosService;
            _materialService = materialService;
            _finalizadorService = finalizadorService;
            _conferenteService = conferenteService;
            _solicitanteService = solicitanteService;
            _empresaService = empresaService;
            _custoDeQuemService = custoDeQuemService;
            _motivosService = motivosService;
            _prioridadeService = prioridadeService;
            _statusService = statusService;
            _configuracoesCustoService = configuracoesCustoService;
            _calculadora = calculadora;
            _coresService = coresService;

            _supabase = supabase;

            // TAMANHO FIXO DO LOGIN
            this.Size = new Size(541, 469);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Regravações - Login";
            NumUpDQtdePlacas.Maximum = 8;
            NumUpDQtdePlacas.Minimum = 1;
            NumUpDQtdePlacas.ValueChanged += NumUpDQtdePlacas_ValueChanged;
            this.Load += FrmMain_Load;
            ConectarEventosCalculo();
            ConectarEventosCores();

            ConfigurarBotoes();
            _ = InicializarSessaoAsync();

        }

        private void NumUpDQtdePlacas_ValueChanged(object sender, EventArgs e)
        {
            AtualizarControlesCores((int)NumUpDQtdePlacas.Value);
        }

        private void EstilizarDGWDetalhesErros()
        {
            // 1. Estilo Básico do DataGrid
            DGWDetalhesErros.BorderStyle = BorderStyle.None; // Remove a borda padrão
            DGWDetalhesErros.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // Fundo cinza claro para linhas alternadas
            DGWDetalhesErros.BackgroundColor = Color.White; // Fundo do controle como branco
            DGWDetalhesErros.GridColor = Color.LightGray; // Cor das linhas de grade

            // 2. Comportamento e Seleção
            DGWDetalhesErros.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Linhas horizontais mais limpas
            DGWDetalhesErros.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleção na linha inteira
            DGWDetalhesErros.MultiSelect = false; // Permite selecionar apenas uma linha por vez
            DGWDetalhesErros.RowHeadersVisible = false; // Oculta a coluna de seleção esquerda (seta)
            DGWDetalhesErros.EnableHeadersVisualStyles = false; // Permite aplicar estilo customizado ao cabeçalho
            DGWDetalhesErros.ColumnHeadersVisible = false;
            DGWDetalhesErros.EnableHeadersVisualStyles = false;

            // 3. Estilo do Cabeçalho (Header)
            DGWDetalhesErros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Configura o estilo padrão do cabeçalho
            DGWDetalhesErros.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64); // Fundo cinza escuro (quase preto)
            DGWDetalhesErros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Texto branco
            DGWDetalhesErros.ColumnHeadersDefaultCellStyle.Font = new Font(DGWDetalhesErros.Font, FontStyle.Bold); // Fonte em negrito
            DGWDetalhesErros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Texto centralizado
            DGWDetalhesErros.ColumnHeadersHeight = 30; // Altura do cabeçalho

            // 4. Estilo de Célula (Quando selecionada)
            DGWDetalhesErros.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 200); // Fundo ao selecionar
            DGWDetalhesErros.DefaultCellStyle.SelectionForeColor = Color.Black; // Texto branco ao selecionar
        }

        // FrmMain.cs

        private void ConectarEventosCalculo()
        {
            foreach (var mapa in _mapaCores)
            {
                TextBox txbLargura = this.Controls.Find(mapa.Largura, true).FirstOrDefault() as TextBox;
                TextBox txbComprimento = this.Controls.Find(mapa.Comprimento, true).FirstOrDefault() as TextBox;
                CheckBox ckBox = this.Controls.Find(mapa.Chk, true).FirstOrDefault() as CheckBox;

                // Conexão dos eventos de CÁLCULO (Apenas Largura, Comprimento, CheckBox)
                if (txbLargura != null) txbLargura.TextChanged += (sender, e) => CalcularCustoCores();
                if (txbComprimento != null) txbComprimento.TextChanged += (sender, e) => CalcularCustoCores();
                if (ckBox != null) ckBox.CheckedChanged += (sender, e) => CalcularCustoCores();
            }
        }

        // Conecta APENAS eventos que disparam a BUSCA DE COR
        private void ConectarEventosCores()
        {
            foreach (var mapa in _mapaCores)
            {
                TextBox txbNomeCor = this.Controls.Find(mapa.NomeCor, true).FirstOrDefault() as TextBox;

                if (txbNomeCor != null)
                {
                    // (Lógica para extrair o numeroCor 1-8)
                    // ...
                    int numeroCor = int.Parse(new string(mapa.NomeCor.Where(char.IsDigit).ToArray()));

                    // ✅ Esta é a função que é chamada quando o texto muda:
                    txbNomeCor.TextChanged += (sender, e) => BuscarEPreencherCorAsync(txbNomeCor.Text, numeroCor);
                }
            }
        }

        // Convertendo cores Hexadecimal para Color
        private System.Drawing.Color HexParaColor(string hexCode)
        {
            if (string.IsNullOrWhiteSpace(hexCode))
            {
                return System.Drawing.Color.Transparent;
            }

            // 1. Limpa o código (remove '#' e espaços)
            hexCode = hexCode.Replace("#", "").Trim();

            // 2. Garante o formato ARGB completo (8 caracteres) ou RGB (6 caracteres)
            if (hexCode.Length == 6)
            {
                // Se for 6 caracteres (RGB), prefixamos com FF (opacidade total) para obter ARGB
                hexCode = "FF" + hexCode;
            }

            if (hexCode.Length != 8)
            {
                // Formato inválido após limpeza
                return System.Drawing.Color.Transparent;
            }

            try
            {
                // 3. Converte a string hexadecimal (8 chars) em um inteiro ARGB
                int argb = int.Parse(hexCode, System.Globalization.NumberStyles.HexNumber);

                // 4. Cria a cor a partir do inteiro ARGB
                return System.Drawing.Color.FromArgb(argb);
            }
            catch
            {
                // Falha na conversão
                return System.Drawing.Color.Transparent;
            }
        }


        public async void BuscarEPreencherCorAsync(string termoDigitado, int numeroCor)
        {
            // 1. Condição de busca (pode estar impedindo a execução)
            if (termoDigitado.Length < 3)
            {
                // Se o termo for muito curto, garantimos que o painel esteja limpo.
                Panel? panel = this.Controls.Find($"PanelCor{numeroCor}", true).FirstOrDefault() as Panel;
                if (panel != null) panel.BackColor = System.Drawing.Color.Transparent;
                return;
            }

            // 2. Busca no Serviço (Assumimos que está retornando o modelo correto)
            Models.CoresModel? corEncontrada = await _coresService.BuscarCorPorNomeParcialAsync(termoDigitado);

            // 3. Busca e atribuição ao Painel
            Panel? panelCor = this.Controls.Find($"PanelCor{numeroCor}", true).FirstOrDefault() as Panel;

            if (panelCor != null)
            {
                if (corEncontrada != null)
                {
                    // ✅ Atribui a cor convertida do código Hexa do banco
                    panelCor.BackColor = HexParaColor(corEncontrada.CodigoHexadecimal);
                }
                else
                {
                    // Limpa se não encontrou (útil para feedback visual)
                    panelCor.BackColor = System.Drawing.Color.Transparent;
                }
            }
            // NOTA: Se o painel for nulo (PanelCor# não existe), nada acontece.
        }

        #region
        private void CalcularCustoCores()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            var coresParaCalcular = new List<CorCalculoDto>();

            // 1. Coleta e Validação dos Dados da UI
            for (int i = 0; i < _mapaCores.Length; i++)
            {
                var mapa = _mapaCores[i];

                // Busca os controles APENAS usando o nome fornecido
                CheckBox ckBox = this.Controls.Find(mapa.Chk, true).FirstOrDefault() as CheckBox;
                TextBox txbLargura = this.Controls.Find(mapa.Largura, true).FirstOrDefault() as TextBox;
                TextBox txbComprimento = this.Controls.Find(mapa.Comprimento, true).FirstOrDefault() as TextBox;

                if (ckBox == null || txbLargura == null || txbComprimento == null) continue;

                decimal largura = 0m;
                decimal comprimento = 0m;

                // Tenta fazer o Parse, assumindo 0m se falhar (texto vazio, inválido)
                decimal.TryParse(txbLargura.Text, NumberStyles.Number, culture, out largura);
                decimal.TryParse(txbComprimento.Text, NumberStyles.Number, culture, out comprimento);

                // Adiciona à lista de entrada para a calculadora
                coresParaCalcular.Add(new CorCalculoDto
                {
                    NumeroCor = i + 1,
                    Largura = largura,
                    Comprimento = comprimento,
                    EstaTotalmenteMarcada = ckBox.Checked
                });
            }

            // 2. Chama a Calculadora Externa (Lógica de Negócio Isolada)
            CalculoResultadoDto resultados = _calculadora.Calcular(
                coresParaCalcular,
                _margemCorte,
                _fatorCalculo,
                _maoObra ?? 0m
            );

            // 3. Atualiza a UI com os resultados

            // Atualiza parciais
            foreach (var resultadoParcial in resultados.ResultadosParciais)
            {
                var mapa = _mapaCores[resultadoParcial.NumeroCor - 1];

                TextBox txbMedidaParcial = this.Controls.Find(mapa.MedidaParcial, true).FirstOrDefault() as TextBox;
                TextBox txbCustoParcial = this.Controls.Find(mapa.CustoParcial, true).FirstOrDefault() as TextBox;

                if (txbMedidaParcial != null)
                {
                    txbMedidaParcial.Text = resultadoParcial.MedidaParcial.ToString("N0", culture);
                }
                if (txbCustoParcial != null)
                {
                    txbCustoParcial.Text = resultadoParcial.CustoParcial.ToString("N2", culture);
                }
            }

            // Atualiza totais
            TextBox txbMedidaTotal = this.Controls.Find("TxbMedidaTotal", true).FirstOrDefault() as TextBox;
            TextBox txbCustoTotal = this.Controls.Find("TxbCustoTotal", true).FirstOrDefault() as TextBox;

            if (txbMedidaTotal != null)
            {
                txbMedidaTotal.Text = resultados.MedidaTotal.ToString("F0", culture);
            }
            if (txbCustoTotal != null)
            {
                txbCustoTotal.Text = resultados.CustoTotal.ToString("N2", culture);
            }
        }

        private void AtualizarControlesCores(int quantidadeCores)
        {
            for (int i = 0; i < _mapaCores.Length; i++)
            {
                var mapa = _mapaCores[i];
                int numeroCor = i + 1;

                // Define se a cor deve estar ATIVA ou INATIVA
                bool deveEstarAtiva = numeroCor <= quantidadeCores;

                // 1. Busca os controles essenciais para esta linha
                CheckBox ckBox = this.Controls.Find(mapa.Chk, true).FirstOrDefault() as CheckBox;
                TextBox txbNome = this.Controls.Find(mapa.NomeCor, true).FirstOrDefault() as TextBox;
                TextBox txbLargura = this.Controls.Find(mapa.Largura, true).FirstOrDefault() as TextBox;
                TextBox txbComprimento = this.Controls.Find(mapa.Comprimento, true).FirstOrDefault() as TextBox;

                // Controles de Saída (também devem ser desativados/limpos)
                TextBox txbMedidaParcial = this.Controls.Find(mapa.MedidaParcial, true).FirstOrDefault() as TextBox;
                TextBox txbCustoParcial = this.Controls.Find(mapa.CustoParcial, true).FirstOrDefault() as TextBox;

                // Itera sobre todos os controles e aplica a lógica
                Control[] controlesDaLinha = { ckBox, txbNome, txbLargura, txbComprimento, txbMedidaParcial, txbCustoParcial };

                foreach (var ctrl in controlesDaLinha)
                {
                    if (ctrl == null) continue;

                    // Ativa/Desativa o controle
                    ctrl.Enabled = deveEstarAtiva;

                    if (deveEstarAtiva)
                    {
                        // Se a cor for ativada (Número <= QtdePlacas)
                        if (ctrl is CheckBox ckb)
                        {
                            // Ativa e Marca o CheckBox
                            ckb.Checked = true;
                            ckb.CheckState = CheckState.Checked; // Garante o estado totalmente marcado
                        }
                    }
                    else
                    {
                        // Se a cor for desativada (Número > QtdePlacas)
                        if (ctrl is TextBox txb)
                        {
                            // Limpa o TextBox e zera o cálculo
                            txb.Text = string.Empty;
                        }
                        else if (ctrl is CheckBox ckb)
                        {
                            // Desmarca o CheckBox e zera o estado
                            ckb.Checked = false;
                            ckb.CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }

            // IMPORTANTE: Recalcula o custo total e a medida total, pois cores foram desativadas/limpas.
            CalcularCustoCores();
        }

        #endregion

        #region CARREGAR OS COMBOBOXES COM INFORMAÇÕES DO BANCO

        private async Task CarregarMateriais()
        {
            try
            {
                List<MaterialDto> materiais = await _materialService.ListarMateriaisAsync();

                // Converter o texto para MAIÚSCULAS
                if (materiais.Count != 0)
                {
                    // Usando forEach para atualizar a lista
                    materiais.ForEach(m =>
                    {
                        // Acessa a propriedade que está sendo exibida
                        if (m.Material != null)
                        {
                            m.Material = m.Material.ToUpper();
                        }
                    });
                }

                var itemEmBranco = new MaterialDto
                {
                    IdMaterial = 0, // Um valor que não existe no DB
                    Material = ""
                    // As outras propriedades podem ficar com valores padrão
                };

                // 2. Insere o item em branco no início da lista
                materiais.Insert(0, itemEmBranco);

                // ... (lógica de limpeza) ...
                CBxMaterial.DataSource = null;
                CBxMaterial.DisplayMember = "";
                CBxMaterial.ValueMember = "";

                CBxMaterial.DataSource = materiais;

                CBxMaterial.DisplayMember = "Material";
                CBxMaterial.ValueMember = "IdMaterial";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar materiais: {ex.Message}", "Erro de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarFinalizadores()
        {
            try
            {
                List<FuncionariosDto> funcionario = await _finalizadorService.ListarFinalizadoresAsync();

                if (funcionario.Count != 0)
                {
                    // 1. Cria o DTO "placeholder" (Item Em Branco)
                    // Ele deve ter um ID inválido (como 0) para indicar que não é uma seleção real
                    var itemEmBranco = new FuncionariosDto
                    {
                        IdFuncionario = 0, // Um valor que não existe no DB
                        Nome = ""
                        // As outras propriedades podem ficar com valores padrão
                    };

                    // 2. Insere o item em branco no início da lista
                    funcionario.Insert(0, itemEmBranco);

                    // 3. Lógica de Data Binding finalizador
                    CBxFinalizadoPor.DataSource = null;
                    CBxFinalizadoPor.DisplayMember = "";
                    CBxFinalizadoPor.ValueMember = "";

                    CBxFinalizadoPor.DataSource = funcionario;
                    CBxFinalizadoPor.DisplayMember = "Nome".ToUpper();
                    CBxFinalizadoPor.ValueMember = "IdFuncionario";

                    // 4. O ComboBox selecionará automaticamente o índice 0 (o item em branco)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar funcionários finalizadores: {ex.Message}", "Erro de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarConferentes()
        {
            try
            {
                // 1. Chama o serviço. O serviço já sabe que deve buscar cargos 5 E 7.
                List<FuncionariosDto> funcionario = await _conferenteService.ListarConferentesAsync();

                if (funcionario.Count != 0)
                {
                    // Cria o DTO "placeholder" (Item Em Branco)
                    var itemEmBranco = new FuncionariosDto
                    {
                        IdFuncionario = 0, // Um valor que não existe no DB
                        Nome = ""
                    };

                    // Insere o item em branco no início da lista
                    funcionario.Insert(0, itemEmBranco);

                    // 3. Lógica de Data Binding conferente
                    CBxConferidoPor.DataSource = null;
                    CBxConferidoPor.DisplayMember = "";
                    CBxConferidoPor.ValueMember = "";

                    CBxConferidoPor.DataSource = funcionario;
                    CBxConferidoPor.DisplayMember = "Nome";
                    CBxConferidoPor.ValueMember = "IdFuncionario";

                    // O ComboBox selecionará automaticamente o índice 0 (o item em branco)
                }
            }
            catch (Exception ex)
            {
                // ⚠️ CORREÇÃO DE TEXTO: Mudar "finalizadores" para "conferentes"
                MessageBox.Show($"Erro ao buscar funcionários conferentes: {ex.Message}", "Erro de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarSolicitante()
        {
            try
            {
                // 1. Chama o serviço. O serviço já sabe que deve buscar cargos 5 E 7.
                List<FuncionariosDto> funcionario = await _solicitanteService.ListarSolicitanteAsync();

                if (funcionario.Count != 0)
                {
                    // Cria o DTO "placeholder" (Item Em Branco)
                    var itemEmBranco = new FuncionariosDto
                    {
                        IdFuncionario = 0, // Um valor que não existe no DB
                        Nome = ""
                    };

                    // Insere o item em branco no início da lista
                    funcionario.Insert(0, itemEmBranco);

                    // 3. Lógica de Data Binding conferente
                    CBxSolicitante.DataSource = null;
                    CBxSolicitante.DisplayMember = "";
                    CBxSolicitante.ValueMember = "";

                    CBxSolicitante.DataSource = funcionario;
                    CBxSolicitante.DisplayMember = "Nome";
                    CBxSolicitante.ValueMember = "IdFuncionario";

                    // O ComboBox selecionará automaticamente o índice 0 (o item em branco)
                }
            }
            catch (Exception ex)
            {
                // ⚠️ CORREÇÃO DE TEXTO: Mudar "finalizadores" para "conferentes"
                MessageBox.Show($"Erro ao buscar funcionários conferentes: {ex.Message}", "Erro de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarEnviarParaAsync()
        {
            try
            {
                List<EmpresaDto> empresas = await _empresaService.ObterEmpresasAtivasAsync();

                // 1. Cria e Insere o item em branco no início
                var itemEmBranco = new EmpresaDto
                {
                    IdEmpresa = 0,
                    NomeEmpresa = ""
                };
                empresas.Insert(0, itemEmBranco);

                // -----------------------------------------------------
                // ✅ CORREÇÃO: Converte o nome de todas as empresas para maiúsculas
                // -----------------------------------------------------
                var empresasMaiusculas = empresas
                    .Select(e => new EmpresaDto
                    {
                        IdEmpresa = e.IdEmpresa,
                        NomeEmpresa = e.NomeEmpresa?.ToUpper() // Converte para maiúsculo
                                                               // Não é necessário mapear IdStatus, pois não será usado no ComboBox
                    })
                    .ToList();

                // 1. Limpa o ComboBox
                CBxEnviarPara.DataSource = null;
                CBxEnviarPara.Items.Clear();

                // 2. Configura a lista
                CBxEnviarPara.DisplayMember = "NomeEmpresa"; // O que o usuário vê
                CBxEnviarPara.ValueMember = "IdEmpresa";    // O valor interno (ID)

                // 3. Define a fonte de dados usando a NOVA lista em maiúsculas
                CBxEnviarPara.DataSource = empresasMaiusculas;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de empresas:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarMotivosAsync()
        {
            try
            {
                List<MotivosPrincipaisDto> motivos = await _motivosService.ObterTodosMotivosAsync();

                // 1. Cria e Insere o item em branco no início
                var itemEmBranco = new MotivosPrincipaisDto
                {
                    IdMotivoPrincipal = 0,
                    MotivoPrincipal = ""
                };
                motivos.Insert(0, itemEmBranco);

                // 2. CONVERTE PARA MAIÚSCULAS antes de atribuir ao DataSource
                var motivosMaiusculos = motivos
                    .Select(m => new MotivosPrincipaisDto
                    {
                        IdMotivoPrincipal = m.IdMotivoPrincipal,
                        MotivoPrincipal = m.MotivoPrincipal?.ToUpper() // Converte para maiúsculo
                    })
                    .ToList();

                // 3. Limpa e configura o ComboBox
                CBxMotivoPrincipal.DataSource = null;
                CBxMotivoPrincipal.Items.Clear();

                CBxMotivoPrincipal.DisplayMember = "MotivoPrincipal";
                CBxMotivoPrincipal.ValueMember = "IdMotivoPrincipal";

                // 4. Atribuição da fonte de dados
                CBxMotivoPrincipal.DataSource = motivosMaiusculos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de Motivos Principais:\n{ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarPrioridadesAsync()
        {
            try
            {
                List<PrioridadeDto> prioridades = await _prioridadeService.ObterTodasPrioridadesAsync();

                // 1. Cria e Insere o item em branco no início
                var itemEmBranco = new PrioridadeDto
                {
                    IdPrioridade = 0,
                    DescricaoPrioridade = ""
                };
                prioridades.Insert(0, itemEmBranco);

                // 2. CONVERTE PARA MAIÚSCULAS antes de atribuir ao DataSource
                var prioridadesMaiusculas = prioridades
                    .Select(p => new PrioridadeDto
                    {
                        IdPrioridade = p.IdPrioridade,
                        DescricaoPrioridade = p.DescricaoPrioridade?.ToUpper() // Converte para maiúsculo
                    })
                    .ToList();

                // 3. Limpa e configura o ComboBox
                CBxPrioridade.DataSource = null;
                CBxPrioridade.Items.Clear();

                // Configuração dos membros
                CBxPrioridade.DisplayMember = "DescricaoPrioridade";
                CBxPrioridade.ValueMember = "IdPrioridade";

                // 4. Atribuição da fonte de dados
                CBxPrioridade.DataSource = prioridadesMaiusculas;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de Prioridades:\n{ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarCustoDeQuemAsync()
        {
            try
            {
                List<EmpresaDto> empresas = await _empresaService.ObterEmpresasAtivasAsync();

                // 1. Cria e Insere o item em branco no início
                var itemEmBranco = new EmpresaDto
                {
                    IdEmpresa = 0,
                    NomeEmpresa = ""
                };
                empresas.Insert(0, itemEmBranco);

                // -----------------------------------------------------
                // ✅ CORREÇÃO: Converte o nome de todas as empresas para maiúsculas
                // -----------------------------------------------------
                var empresasMaiusculas = empresas
                    .Select(e => new EmpresaDto
                    {
                        IdEmpresa = e.IdEmpresa,
                        NomeEmpresa = e.NomeEmpresa?.ToUpper() // Converte para maiúsculo
                                                               // Não é necessário mapear IdStatus, pois não será usado no ComboBox
                    })
                    .ToList();

                // 1. Limpa o ComboBox
                CBxCustoDeQuem.DataSource = null;
                CBxCustoDeQuem.Items.Clear();

                // 2. Configura a lista
                CBxCustoDeQuem.DisplayMember = "NomeEmpresa"; // O que o usuário vê
                CBxCustoDeQuem.ValueMember = "IdEmpresa";    // O valor interno (ID)

                // 3. Define a fonte de dados usando a NOVA lista em maiúsculas
                CBxCustoDeQuem.DataSource = empresasMaiusculas;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de empresas:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarStatusAsync()
        {
            try
            {
                List<StatusDto> statusList = await _statusService.ObterTodosStatusAsync();

                // 1. Cria e Insere o item em branco no início
                var itemEmBranco = new StatusDto
                {
                    IdStatus = 0,
                    DescricaoStatus = ""
                };
                statusList.Insert(0, itemEmBranco);

                // 2. CONVERTE PARA MAIÚSCULAS antes de atribuir ao DataSource
                var statusMaiusculos = statusList
                    .Select(s => new StatusDto
                    {
                        IdStatus = s.IdStatus,
                        DescricaoStatus = s.DescricaoStatus?.ToUpper() // Converte para maiúsculo
                    })
                    .ToList();

                // 3. Limpa e configura o ComboBox
                CBxStatus.DataSource = null;
                CBxStatus.Items.Clear();

                // Configuração dos membros
                CBxStatus.DisplayMember = "DescricaoStatus";
                CBxStatus.ValueMember = "IdStatus";

                // 4. Atribuição da fonte de dados
                CBxStatus.DataSource = statusMaiusculos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de Status:\n{ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarConfiguracoesCustoAsync()
        {
            try
            {
                // 1. Chame o serviço para obter as configurações (assumindo ID fixo 1)
                var config = await _configuracoesCustoService.ObterConfiguracoesCustoAsync();

                // Define valores default caso o registro de configuração não seja encontrado
                if (config == null)
                {
                    _margemCorte = 0m;
                    _fatorCalculo = 0m;
                    _maoObra = 0m; // Define 0m como default para o campo opcional

                    MessageBox.Show("Configurações de custo não encontradas no banco de dados. Usando valores zero.", "Configuração Ausente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _margemCorte = config.MargemCorte;
                    _fatorCalculo = config.FatorCalculo;
                    _maoObra = config.MaoObra ?? 0m;
                }

                CultureInfo culture = new CultureInfo("pt-BR");
                TxbMargem.Text = _margemCorte.ToString("N2", culture);
                TxbFatorCusto.Text = _fatorCalculo.ToString("N2", culture);
                // Observação: Usei "N2" para TxbMaoObra para consistência, já que é um valor monetário/percentual.
                TxbMaoObra.Text = _maoObra.Value.ToString("N2", culture);

                // 🎯 DISPARA O RECÁLCULO
                CalcularCustoCores();
            }
            catch (Exception ex)
            {
                // Captura tanto erros de carregamento (acesso a dados) quanto erros de cálculo.
                MessageBox.Show($"Erro ao carregar as configurações de custo ou ao recalcular:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private List<CoresInserirDto> ColetarDadosDasCoresDoFormulario()
        {
            var cores = new List<CoresInserirDto>();

            for (int i = 1; i <= MaxCores; i++)
            {
                // 1. Buscando controles (Presumindo ComboBox, TextBoxes)
                // Ex: CBxCor1
                var txbLargura = this.Controls.Find($"TxbLarguraCor{i}", true).FirstOrDefault() as TextBox;
                var txbComprimento = this.Controls.Find($"TxbComprimentoCor{i}", true).FirstOrDefault() as TextBox;
                var txbCustoEstimado = this.Controls.Find($"TxbCustoCor{i}", true).FirstOrDefault() as TextBox; // Novo campo de custo

                // Se a cor não foi selecionada ou campos numéricos estão vazios, ignora a linha.
                if (this.Controls.Find($"CBxCor{i}", true).FirstOrDefault() is not ComboBox cbxCor || cbxCor.SelectedValue == null || string.IsNullOrWhiteSpace(txbLargura?.Text))
                    continue;

                // 2. Conversão Segura de Dados

                // IdCor (Assumindo que SelectedValue é o Id)
                if (!int.TryParse(cbxCor.SelectedValue.ToString(), out int idCor))
                {
                    throw new ArgumentException($"O ID da Cor selecionada na linha {i} está em formato inválido.");
                }

                // Largura, Comprimento, Custo Estimado (Todos como decimal)
                if (!decimal.TryParse(txbLargura?.Text, out decimal largura))
                {
                    throw new ArgumentException($"Largura da Cor {i} ('{txbLargura?.Text}') está em formato inválido.");
                }

                if (!decimal.TryParse(txbComprimento?.Text, out decimal comprimento))
                {
                    throw new ArgumentException($"Comprimento da Cor {i} ('{txbComprimento?.Text}') está em formato inválido.");
                }

                if (!decimal.TryParse(txbCustoEstimado?.Text, out decimal custoEstimado))
                {
                    throw new ArgumentException($"Custo Estimado da Cor {i} ('{txbCustoEstimado?.Text}') está em formato inválido ou vazio.");
                }

                // 3. Adiciona a Cor ao DTO CORRETO (CoresInserirDto)
                cores.Add(new CoresInserirDto
                {
                    IdCor = idCor,
                    Largura = largura,
                    Comprimento = comprimento,
                    CustoEstimado = custoEstimado
                });
            }

            if (cores.Count == 0)
            {
                throw new ArgumentException("Pelo menos uma cor deve ser preenchida para o cadastro.");
            }

            // MUDANÇA 2: Retorna a lista correta
            return cores;
        }

        private async Task InicializarSessaoAsync()
        {
            var sessaoSalva = SessaoHelper.CarregarSessao();
            if (sessaoSalva != null &&
              !string.IsNullOrEmpty(sessaoSalva.AccessToken) &&
              !string.IsNullOrEmpty(sessaoSalva.RefreshToken))
            {
                try
                {
                    await _supabase.Auth.SetSession(sessaoSalva.AccessToken, sessaoSalva.RefreshToken);
                    var currentSession = _supabase.Auth.CurrentSession;

                    if (currentSession != null)
                    {
                        var expiresAt = currentSession.ExpiresAt();
                        if (expiresAt > DateTime.UtcNow)
                        {
                            MostrarUsuarioLogado();
                            IniciarVerificacaoDeSessao();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao restaurar sessão: {ex.Message}");
                }
            }

            MostrarTelaDeLogin();
        }

        private void MostrarTelaDeLogin()
        {
            // === CRIA O OVERLAY (bloqueia o fundo) ===
            overlayPanel = new Panel
            {
                BackColor = Color.FromArgb(255, 0, 0, 0), // Cinza escuro semi-transparente
                Dock = DockStyle.Fill,
                Enabled = true
            };
            this.Controls.Add(overlayPanel);
            this.Controls.SetChildIndex(overlayPanel, 0); // Fica atrás do login

            loginControl = new LoginControl(_supabase)
            {
                Size = new Size(541, 469),
                BackColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(0),
                Anchor = AnchorStyles.None
            };

            loginControl.Location = new Point(
              (this.ClientSize.Width - loginControl.Width) / 2,
              (this.ClientSize.Height - loginControl.Height) / 2
            );

            this.Controls.Add(loginControl);
            this.Controls.SetChildIndex(loginControl, 0);

            this.Resize += (s, e) =>
            {
                if (loginControl != null && this.Controls.Contains(loginControl))
                {
                    loginControl.Location = new Point(
                      (this.ClientSize.Width - loginControl.Width) / 2,
                      (this.ClientSize.Height - loginControl.Height) / 2
                    );
                }
            };

            loginControl.LoginSucesso += (s, e) =>
            {
                RemoverTelaDeLogin();
                MostrarUsuarioLogado();
                IniciarVerificacaoDeSessao();
            };

            loginControl.CancelarLogin += (s, e) =>
            {
                if (MessageBox.Show("Tem certeza que deseja sair do sistema?",
                  "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };
        }
        private void RemoverTelaDeLogin()
        {
            // Remove o login
            if (loginControl != null && this.Controls.Contains(loginControl))
            {
                this.Controls.Remove(loginControl);
                loginControl.Dispose();
                loginControl = null;
            }

            // Remove o overlay
            if (overlayPanel != null && this.Controls.Contains(overlayPanel))
            {
                this.Controls.Remove(overlayPanel);
                overlayPanel.Dispose();
                overlayPanel = null;
            }

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "Sistema de Regravações - Bem-vindo!";

        }
        private void MostrarUsuarioLogado()
        {
            try
            {
                var user = _supabase.Auth.CurrentUser;
                string nome = "Usuário: Logado";

                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    nome = user.Email;

                    if (user.UserMetadata != null)
                    {
                        if (user.UserMetadata.TryGetValue("full_name", out var fullName))
                            nome = fullName?.ToString() ?? nome;
                        else if (user.UserMetadata.TryGetValue("name", out var name))
                            nome = name?.ToString() ?? nome;
                        else if (user.UserMetadata.TryGetValue("display_name", out var display))
                            nome = display?.ToString() ?? nome;
                    }

                    if (string.IsNullOrWhiteSpace(nome) || nome == user.Email)
                    {
                        nome = user.Email.Split('@')[0];
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao mostrar usuário: {ex.Message}");
            }
        }
        private void ConfigurarBotoes()
        {
            // Remove eventos duplicados (Boa Prática)
            BtnRelatorios.Click -= BtnRelatorios_Click;
            BtnAddErros.Click -= BtnAddErros_Click;
            // 🛑 PASSO 2: CONECTAR O EVENTO DE SALVAR CADASTRO 
            BtnGraficos.Click -= BtnGraficos_Click;
            BtnConfiguracoes.Click -= BtnConfiguracoes_Click;
            BtnLogout.Click -= BtnLogout_Click;

            // Adiciona eventos
            BtnRelatorios.Click += BtnRelatorios_Click;
            BtnAddErros.Click += BtnAddErros_Click;
            // 🛑 PASSO 2: CONECTAR O EVENTO DE SALVAR CADASTRO 
            BtnGraficos.Click += BtnGraficos_Click;
            BtnConfiguracoes.Click += BtnConfiguracoes_Click;
            BtnLogout.Click += BtnLogout_Click;
        }
        private void BtnRelatorios_Click(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider is null)
            {
                MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frm = Program.ServiceProvider.GetRequiredService<FrmRelatorios>();
            frm.Show();
        }

        private async void BtnAddErros_Click(object? sender, EventArgs e)
        {
            await AbrirEAtualizarErrosAsync();
        }

        private async Task AbrirEAtualizarErrosAsync()
        {
            if (Program.ServiceProvider is null)
            {
                MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = Program.ServiceProvider.GetRequiredService<FrmChecklistErros>();

            // 1. ENVIAR SELEÇÕES ATUAIS PARA O CHECKLIST (Pré-seleção)
            if (_errosSelecionados != null && _errosSelecionados.Count > 0)
            {
                // Extrai apenas os IDs dos DTOs atualmente no grid
                var idsAtuais = _errosSelecionados.Select(e => e.IdDetalhesErros).ToList();

                // Passa a lista de IDs para o FrmChecklistErros para pré-seleção
                frm.IdsErrosSelecionadosAnteriores = idsAtuais;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var errosSelecionadosIds = frm.IdsErrosSelecionados;

                if (errosSelecionadosIds != null && errosSelecionadosIds.Length > 0)
                {
                    try
                    {
                        // 2. Buscar os DTOs completos com base nos IDs retornados
                        var listaDetalhada = await _detalhesDeErrosService.ListarErrosPorIdsDtoAsync(errosSelecionadosIds.ToList());

                        // 3. Armazenar a nova lista de DTOs no campo de estado
                        _errosSelecionados = listaDetalhada;

                        // 4. Exibir no DataGridView
                        DGWDetalhesErros.DataSource = null;
                        DGWDetalhesErros.DataSource = _errosSelecionados;

                        // 5. Reaplicar estilos e ocultar colunas
                        ConfigurarColunasErros();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar detalhes dos erros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Se o usuário desmarcou TUDO no checklist, limpa a lista e o Grid
                    _errosSelecionados.Clear();
                    DGWDetalhesErros.DataSource = null;
                }
            }
        }

        private void ConfigurarColunasErros()
        {
            // 1. Ocultar o ID
            if (DGWDetalhesErros.Columns.Contains("IdDetalhesErros"))
            {
                DGWDetalhesErros.Columns["IdDetalhesErros"].Visible = false;
            }

            // 2. Renomear e Otimizar a Coluna de Descrição
            if (DGWDetalhesErros.Columns.Contains("DescricaoErro"))
            {
                DGWDetalhesErros.Columns["DescricaoErro"].HeaderText = "Descrição do Erro"; // Título amigável
                DGWDetalhesErros.Columns["DescricaoErro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Preenche o espaço
            }
        }

        private void BtnGraficos_Click(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider is null)
            {
                MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frm = Program.ServiceProvider.GetRequiredService<FrmGraficosEstatistica>();
            frm.Show();
        }

        private void BtnConfiguracoes_Click(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider is null)
            {
                MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frmConfig = Program.ServiceProvider.GetRequiredService<FrmConfiguracoes>();
            frmConfig.OnConfigSaved = async () => await CarregarConfiguracoesCustoAsync();
            frmConfig.ShowDialog();
        }

        private async void BtnLogout_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do sistema?",
              "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sessaoTimer?.Stop();
                    if (Program.ServiceProvider is null)
                    {
                        MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var service = Program.ServiceProvider.GetRequiredService<IAuthService>();
                    await service.EfetuarLogoutAsync();
                    SessaoHelper.LimparSessao();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao fazer logout: {ex.Message}");
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private void IniciarVerificacaoDeSessao()
        {
            sessaoTimer?.Stop();
            sessaoTimer = new System.Windows.Forms.Timer { Interval = 60000 };
            sessaoTimer.Tick += async (s, e) => await VerificarExpiracaoAsync();
            sessaoTimer.Start();
        }

        private async Task VerificarExpiracaoAsync()
        {
            try
            {
                var session = _supabase.Auth.CurrentSession;
                if (session == null || session.User == null)
                {
                    await ForcarLogoutPorExpiracao();
                    return;
                }

                var expiresAt = session.ExpiresAt(); // ← DateTime (não nullable)

                // Verifica se expirou
                if (expiresAt <= DateTime.UtcNow)
                {
                    var refreshed = await _supabase.Auth.RefreshSession();
                    if (refreshed?.User == null)
                    {
                        await ForcarLogoutPorExpiracao();
                    }
                    else
                    {
                        SessaoHelper.SalvarSessao(refreshed);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar sessão: {ex.Message}");
                await ForcarLogoutPorExpiracao();
            }
        }

        private async Task ForcarLogoutPorExpiracao()
        {
            sessaoTimer?.Stop();
            SessaoHelper.LimparSessao();

            MessageBox.Show(
              "Sua sessão expirou. Por favor, faça login novamente.",
              "Sessão expirada",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

            MostrarTelaDeLogin();
            await Task.CompletedTask;
        }



        private async void BtnSalvarCadastro_Click_1(object sender, EventArgs e)
        {
            // 1. Obter o valor selecionado
            if (CBxFinalizadoPor.SelectedValue is not int idFinalizadorSelecionado)
            {
                MessageBox.Show("Por favor, selecione o funcionário que finalizou o registro.",
                                "Campo Obrigatório",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                CBxFinalizadoPor.Focus(); // Volta o foco para o campo
                return; // Aborta o processo de salvamento
            }

            // 3. Se a validação passou, continue com o salvamento
            // ... chame o serviço para salvar ...

            // Validação básica
            if (string.IsNullOrWhiteSpace(TxbRequerimentoAtual.Text))
            {
                MessageBox.Show("O campo 'Requerimento Atual' é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ⚠️ Coleta dos SelectedValues (Presumindo que são inteiros/shorts válidos)
            if (CBxMaterial.SelectedValue == null || CBxFinalizadoPor.SelectedValue == null || CBxConferidoPor.SelectedValue == null ||
        CBxSolicitante.SelectedValue == null || CBxEnviarPara.SelectedValue == null || CBxMotivoPrincipal.SelectedValue == null ||
        CBxPrioridade.SelectedValue == null || CBxStatus.SelectedValue == null)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios selecionados (Comboboxes).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Coleta dos dados
            List<CoresInserirDto> cores;
            short versao;
            short qtdePlacas;

            try
            {
                cores = ColetarDadosDasCoresDoFormulario(); // Agora retorna o tipo correto
                versao = short.Parse(TxbVersao.Text);
                qtdePlacas = (short)NumUpDQtdePlacas.Value; // Usando o valor do NumericUpDown
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Erro de Validação: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                MessageBox.Show($"Erro de formato: Certifique-se de que Versão e Quantidade de Placas são números válidos e pequenos. {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // =========================================================================
            // ✅ INICIALIZAÇÃO DO DTO com os Controles Reais
            // =========================================================================
            var dados = new InserirRegravacaoDto
            {
                // --- CAMPOS REQUIRED ---
                RequerimentoAtual = TxbRequerimentoAtual.Text,
                DescricaoArte = TxbDescricao.Text,
                Versao = versao,
                IdQuemFinalizou = (int)CBxFinalizadoPor.SelectedValue,
                IdConferente = (int)CBxConferidoPor.SelectedValue,
                IdSolicitante = (int)CBxSolicitante.SelectedValue,
                IdEnviarPara = (int)CBxEnviarPara.SelectedValue,
                IdMotivoPrincipal = (int)CBxMotivoPrincipal.SelectedValue,
                QtdePlacas = qtdePlacas,
                IdPrioridade = (int)CBxPrioridade.SelectedValue,
                IdStatus = (int)CBxStatus.SelectedValue,
                IdMaterial = (short)CBxMaterial.SelectedValue,
                Cores = cores, // Lista de DTOs de cores coletada

                // --- CAMPOS OPCIONAIS ---
                RequerimentoNovo = TxbReqNovo.Text, // Pode ser string.Empty se não houver TxbReqNovo
                IdCobrarDeQuem = CBxCustoDeQuem.SelectedValue as int?, // Assume que SelectedValue pode ser int ou null
                Observacoes = TxbObservacao.Text,
                Thumbnail = PictureBoxThumbnail.ImageLocation, // URL da imagem, se houver
                DataCadastro = DateTimeBoxCadastro.Value, // Valor do seu DateTimePicker/TextBox
            };

            // 1. Anexar os IDs de erro coletados (MotivosErrosIds é opcional no DTO)
            if (_errosSelecionados.Count != 0)
            {
                dados.MotivosErrosIds = _errosSelecionados.Select(e => e.IdDetalhesErros).ToList();
            }
            else
            {
                dados.MotivosErrosIds = null;
            }

            try
            {
                // 2. Chama o serviço para salvar TUDO
                int idNovaRegravacao = await _regravacaoService.CriarRegravacao(dados);

                MessageBox.Show($"Regravação salva com sucesso! ID: {idNovaRegravacao}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Limpa o estado e o formulário
                _errosSelecionados.Clear();
                DGWDetalhesErros.DataSource = null;
                // BtnLimparCamposCadastro_Click(null, null); // Chama a função de limpeza
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Erro de Validação: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar no banco: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            EstilizarDGWDetalhesErros();
            await CarregarMateriais();
            await CarregarFinalizadores();
            await CarregarConferentes();
            await CarregarSolicitante();
            await CarregarEnviarParaAsync();
            await CarregarMotivosAsync();
            await CarregarPrioridadesAsync();
            await CarregarCustoDeQuemAsync();
            await CarregarStatusAsync();
            await CarregarConfiguracoesCustoAsync();
            AtualizarControlesCores((int)NumUpDQtdePlacas.Value);
        }

        private async void DGWDetalhesErros_DoubleClick(object sender, EventArgs e)
        {
            await AbrirEAtualizarErrosAsync();
        }

        private void TxbLarguraCor1_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor1_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor2_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor2_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor3_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor3_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor4_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor4_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor5_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor5_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor6_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor6_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor7_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor7_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbLarguraCor8_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void TxbComprimentoCor8_TextChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor1_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor2_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor3_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor4_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor5_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor6_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor7_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void CkBCor8_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCustoCores();
        }

        private void BtnLimparCamposCadastro_Click(object sender, EventArgs e)
        {
            LimparControlesPersonalizado();
        }

        private void LimparControlesPersonalizado()
        {
            // ... (Seu código existente para os outros controles) ...
            TxbRequerimentoAtual.Text = string.Empty;
            TxbDescricao.Text = string.Empty;
            TxbReqNovo.Text = string.Empty;
            TxbObservacao.Text = string.Empty;

            PictureBoxThumbnail.Image = null;
            // 🎯 Limpar a referência da imagem (bytes) para o upload
            // Isso garante que nenhum dado de imagem antigo seja salvo.
            _thumbnailBytes = null;

            DateTimeBoxCadastro.Value = DateTime.Now;
            CBxConferidoPor.SelectedIndex = 0;
            CBxEnviarPara.SelectedIndex = 0;
            CBxFinalizadoPor.SelectedIndex = 0;
            CBxMaterial.SelectedIndex = 0;
            CBxMotivoPrincipal.SelectedIndex = 0;
            CBxPrioridade.SelectedIndex = 0;
            CBxSolicitante.SelectedIndex = 0;
            CBxStatus.SelectedIndex = 0;
            CBxCustoDeQuem.SelectedIndex = 0;
            NumUpDQtdePlacas.Value = NumUpDQtdePlacas.Minimum;
            CBxStatus.SelectedIndex = 0;

            // 🎯 CORREÇÃO DO DATA GRID VIEW:
            // 1. Limpa a lista privada que é a fonte de dados (DataSource)
            if (_errosSelecionados != null)
            {
                _errosSelecionados.Clear();
            }

            // 2. Força o DGW a se atualizar com a lista vazia.
            // O comando DGWDetalhesErros.Rows.Clear() deve ser removido!
            DGWDetalhesErros.DataSource = null;
            DGWDetalhesErros.DataSource = _errosSelecionados;

            // Limpeza dos Controles Dinâmicos (Cores)
            for (int i = 1; i <= MaxCores; i++)
            {
                var cbxCor = this.Controls.Find($"CBxCor{i}", true).FirstOrDefault() as ComboBox;
                var txbNomeCor = this.Controls.Find($"TxbNomeCor{i}", true).FirstOrDefault() as TextBox;
                var txbLargura = this.Controls.Find($"TxbLarguraCor{i}", true).FirstOrDefault() as TextBox;
                var txbComprimento = this.Controls.Find($"TxbComprimentoCor{i}", true).FirstOrDefault() as TextBox;
                var txbCustoEstimado = this.Controls.Find($"TxbCustoCor{i}", true).FirstOrDefault() as TextBox;

                if (cbxCor != null) cbxCor.SelectedIndex = 0;
                if (txbNomeCor != null) txbNomeCor.Text = string.Empty;
                if (txbLargura != null) txbLargura.Text = string.Empty;
                if (txbComprimento != null) txbComprimento.Text = string.Empty;
                if (txbCustoEstimado != null) txbCustoEstimado.Text = string.Empty;
            }
        }

        private void BtnAddThumbnail_Click(object sender, EventArgs e)
        {
            ProcessAndSetThumbnail();
        }

        private void ProcessAndSetThumbnail()
        {
            // Limpa a variável de bytes e a imagem visual em caso de falha ou cancelamento anterior
            _thumbnailBytes = null;
            PictureBoxThumbnail.Image = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Define o filtro para permitir apenas arquivos JPG
                openFileDialog.Filter = "Arquivos de Imagem JPG (*.jpg)|*.jpg";
                openFileDialog.Title = "Selecione a Imagem para a Thumbnail";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Carrega a imagem original do arquivo
                        // Usamos Image.FromFile para carregar o arquivo sem travar o caminho
                        using (Image originalImage = Image.FromFile(openFileDialog.FileName))
                        {
                            // 1. Processa a imagem para criar a thumbnail (Image)
                            using (Image thumbnail = ImageProcessor.CreateThumbnail(originalImage))
                            {
                                // 2. Converte a thumbnail para array de bytes com compressão JPG (baixa qualidade)
                                _thumbnailBytes = ImageProcessor.ImageToByteArray(thumbnail);

                                // 3. Exibe a imagem processada no PictureBoxThumbnail
                                using (var ms = new MemoryStream(_thumbnailBytes))
                                {
                                    // Cria uma nova Image a partir do array de bytes
                                    PictureBoxThumbnail.Image = Image.FromStream(ms);
                                }

                                // Configura o PictureBox para preencher a área proporcionalmente (Zoom)
                                PictureBoxThumbnail.SizeMode = PictureBoxSizeMode.Zoom;

                                // MessageBox.Show("Thumbnail criada e pronta para o salvamento.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar, processar ou converter a imagem:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _thumbnailBytes = null; // Limpa o estado
                        PictureBoxThumbnail.Image = null; // Limpa o visual
                    }
                }
                // Se o usuário cancelar (DialogResult.Cancel), não faz nada, 
                // pois o _thumbnailBytes e o PictureBox já foram limpos no início.
            }
        }

        private void BtnDelThumbnail_Click(object sender, EventArgs e)
        {
            PictureBoxThumbnail.Image = null;
            // 🎯 Limpar a referência da imagem (bytes) para o upload
            // Isso garante que nenhum dado de imagem antigo seja salvo.
            _thumbnailBytes = null;
        }

        private void PictureBoxThumbnail_DoubleClick(object sender, EventArgs e)
        {
            ProcessAndSetThumbnail();
        }
    }
}