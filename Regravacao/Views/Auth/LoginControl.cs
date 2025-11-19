using System;
using System.Drawing;
using System.Windows.Forms;
using Supabase;
using Regravacao.Helpers;  // ✅ ADICIONAR

namespace Regravacao.Views
{
    public partial class LoginControl : UserControl
    {
        private readonly Client _supabase;

        public event EventHandler CancelarLogin;
        public event EventHandler LoginSucesso;

        public LoginControl(Client supabase)
        {
            InitializeComponent();
            _supabase = supabase;
        }

        public LoginControl() => InitializeComponent();

        private void BtnSolicitarAcesso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicite o cadastro ao administrador do Sistema ou Responsável.",
                "NÃO É CADASTRADO?");
        }

        private async void BtnEntrarLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxbEmail.Text))
            {
                MostrarErro("Digite seu e-mail.");
                TxbEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxbSenha.Text))
            {
                MostrarErro("Digite sua senha.");
                TxbSenha.Focus();
                return;
            }

            BtnEntrarLogin.Enabled = false;
            lblStatus.Text = "Conectando...";
            lblStatus.ForeColor = Color.Black;

            try
            {
                var session = await _supabase.Auth.SignIn(
                    TxbEmail.Text.Trim(),
                    TxbSenha.Text
                );

                if (session?.User != null)
                {
                    lblStatus.Text = "Login realizado com sucesso!";
                    lblStatus.ForeColor = Color.Green;

                    // ✅ SALVAR A SESSÃO AQUI!
                    SessaoHelper.SalvarSessao(session);

                    await Task.Delay(500);

                    LoginSucesso?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MostrarErro("Usuário ou senha incorretos.");
                }
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {
                if (ex.Message.Contains("Invalid login credentials"))
                {
                    MostrarErro("Usuário ou senha incorretos.");
                }
                else
                {
                    MostrarErro($"Erro ao fazer login: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro inesperado: {ex.Message}");
            }
            finally
            {
                BtnEntrarLogin.Enabled = true;
            }
        }

        private void MostrarErro(string msg)
        {
            lblStatus.Text = msg;
            lblStatus.ForeColor = Color.Red;
        }

        private void BtnCancelarLogin_Click(object sender, EventArgs e)
        {
            CancelarLogin?.Invoke(this, EventArgs.Empty);
        }

        public void LimparCampos()
        {
            TxbEmail.Clear();
            TxbSenha.Clear();
            lblStatus.Text = string.Empty;
        }
    }
}