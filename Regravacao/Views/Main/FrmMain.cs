using Microsoft.Extensions.DependencyInjection;
using Regravacao.DTOs;
using Regravacao.Helpers;
using Regravacao.Models;
using Regravacao.Services.Auth;
using Regravacao.Services.DetalhesDeErros;
using Regravacao.Services.Finalizador;
using Regravacao.Services.Conferente;
using Regravacao.Services.Regravacao;
using Regravacao.Views;
using Supabase;
using Supabase.Interfaces;
using Supabase.Postgrest.Extensions;
using System.Linq;

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

        private List<DetalhesDeErrosDto> _errosSelecionados = [];

        public FrmMain(
          IRegravacaoService regravacaoService,
          IDetalhesDeErrosService detalhesDeErrosService,         
          IMaterialService materialService,
          IFinalizadorService finalizadorService,
          IConferenteService conferenteService,

          Client supabase)
        {
            InitializeComponent();

            _regravacaoService = regravacaoService;
            _detalhesDeErrosService = detalhesDeErrosService;
            _materialService = materialService;
            _finalizadorService = finalizadorService;
            _conferenteService = conferenteService;
            
            _supabase = supabase;

            // TAMANHO FIXO DO LOGIN
            this.Size = new Size(541, 469);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Regravações - Login";

            ConfigurarBotoes();
            _ = InicializarSessaoAsync();

        }


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
                    CBxFinalizadoPor.DisplayMember = "Nome";
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

        // ======================================================
        // ✅ EVENTO: Adicionar Erros (BUSCA DTOs)
        // ======================================================
        private async void BtnAddErros_Click(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider is null)
            {
                MessageBox.Show("Serviço de dependências não está disponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = Program.ServiceProvider.GetRequiredService<FrmChecklistErros>();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var errosSelecionadosIds = frm.IdsErrosSelecionados;

                if (errosSelecionadosIds != null && errosSelecionadosIds.Length > 0)
                {
                    try
                    {
                        // 1. Buscar os DTOs completos com base nos IDs retornados
                        var listaDetalhada = await _detalhesDeErrosService.ListarErrosPorIdsDtoAsync(errosSelecionadosIds.ToList());

                        // 2. Armazenar no campo de estado do FrmMain
                        _errosSelecionados = listaDetalhada;

                        // 3. Exibir no DataGridView
                        DGWDetalhesErros.DataSource = null; // Limpa antes de atribuir
                        DGWDetalhesErros.DataSource = _errosSelecionados;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar detalhes dos erros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Se o usuário desmarcou tudo, limpa a lista e o Grid
                    _errosSelecionados.Clear();
                    DGWDetalhesErros.DataSource = null;
                }
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
            var frm = Program.ServiceProvider.GetRequiredService<FrmConfiguracoes>();
            frm.ShowDialog();
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
            await CarregarMateriais();
            await CarregarFinalizadores();
            await CarregarConferentes();
        }
    }
}