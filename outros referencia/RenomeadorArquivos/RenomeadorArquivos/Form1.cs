using System;
using System.IO;
using System.Windows.Forms;

namespace RenomeadorArquivos
{
    public partial class Form1 : Form
    {
        // Variável para armazenar o caminho da pasta selecionada
        private string caminhoPastaSelecionada = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // O FolderBrowserDialog permite que o usuário selecione uma pasta
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    caminhoPastaSelecionada = fbd.SelectedPath;
                    // Atualiza o TextBox com o caminho
                    txtCaminhoPasta.Text = caminhoPastaSelecionada;
                    // Limpa o log
                    txtLog.Text = "";
                    txtLog.Text = ($"Pasta selecionada: {caminhoPastaSelecionada}{Environment.NewLine}");
                }
            }
        }

        private void BtnRenomear_Click_1(object sender, EventArgs e)
        {
            // 1. Verifica se uma pasta foi selecionada
            if (string.IsNullOrWhiteSpace(caminhoPastaSelecionada) || !Directory.Exists(caminhoPastaSelecionada))
            {
                MessageBox.Show("Por favor, selecione uma pasta válida primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtLog.Text = ($"Iniciando renomeação na pasta: {caminhoPastaSelecionada}{Environment.NewLine}");

            // Constante para o texto a ser removido
            const string textoBusca = "VERSAO_";
            int arquivosRenomeados = 0;
            int arquivosVerificados = 0;

            try
            {
                // 2. Obtém todos os arquivos no diretório
                // O *.* busca todos os arquivos; SearchOption.TopDirectoryOnly busca apenas na pasta principal.
                string[] arquivos = Directory.GetFiles(caminhoPastaSelecionada, "*.*", SearchOption.TopDirectoryOnly);

                // 3. Itera sobre cada arquivo
                foreach (string caminhoCompletoArquivo in arquivos)
                {
                    arquivosVerificados++;

                    // Obtém apenas o nome do arquivo (ex: 'meu_arquivo.txt')
                    string nomeArquivoAntigo = Path.GetFileName(caminhoCompletoArquivo);

                    // 4. Verifica se o nome do arquivo contém o texto
                    if (nomeArquivoAntigo.Contains(textoBusca))
                    {
                        // 5. Gera o novo nome do arquivo, removendo o texto
                        string nomeArquivoNovo = nomeArquivoAntigo.Replace(textoBusca, "");

                        // 6. Constrói o novo caminho completo do arquivo
                        string novoCaminhoCompleto = Path.Combine(caminhoPastaSelecionada, nomeArquivoNovo);

                        // 7. Renomeia o arquivo
                        // File.Move move o arquivo, se o destino for na mesma pasta, ele o renomeia.
                        File.Move(caminhoCompletoArquivo, novoCaminhoCompleto);
                        arquivosRenomeados++;

                        // 8. Registra no Log
                        txtLog.Text = ($"   -> Renomeado: '{nomeArquivoAntigo}' para '{nomeArquivoNovo}'{Environment.NewLine}");
                    }
                }

                // 9. Exibe o resumo
                txtLog.Text = ("---------------------------------------------------\n");
                txtLog.Text = ($"Processamento concluído!{Environment.NewLine}");
                txtLog.Text = ($"Total de arquivos verificados: {arquivosVerificados}{Environment.NewLine}");
                txtLog.Text = ($"Total de arquivos renomeados: {arquivosRenomeados}{Environment.NewLine}");

            }
            catch (Exception ex)
            {
                // Em caso de erro (ex: permissão negada, arquivo em uso)
                txtLog.Text = ($"ERRO DURANTE O PROCESSAMENTO: {ex.Message}{Environment.NewLine}");
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Processamento concluído! ", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLog.Text = string.Empty;
                txtCaminhoPasta.Text = string.Empty;
            }
        }
    }
}