using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regravacao.Utils
{
    public static class Helpers
    {
        public static void ApenasNumeros(KeyPressEventArgs e, bool permitirDecimal = false)
        {
            // Permite tecla Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Permite dígitos
            if (char.IsDigit(e.KeyChar))
                return;

            // Permite separador decimal, se habilitado
            if (permitirDecimal && (e.KeyChar == ',' || e.KeyChar == '.'))
                return;

            // Bloqueia qualquer outra tecla
            e.Handled = true;
        }
        
        
            public static bool VerificaSeEstaVazio(params Control[] controles)
            {
                foreach (var controle in controles)
                {
                    if (controle is TextBox txt)
                    {
                        if (string.IsNullOrWhiteSpace(txt.Text))
                            return false;
                    }
                    else if (controle is ComboBox cmb)
                    {
                        if (cmb.SelectedIndex < 0 && string.IsNullOrWhiteSpace(cmb.Text))
                            return false;
                    }
                    else
                    {
                        // fallback: usa Text de qualquer outro controle
                        if (string.IsNullOrWhiteSpace(controle.Text))
                            return false;
                    }
                }
                return true;
            }


            public static bool VerificarLinhasCores(Control container, int linhas = 8, bool destacar = true)
            {
                if (container == null)
                    throw new ArgumentNullException(nameof(container));

                bool tudoOk = true;
                Control primeiroInvalido = null;

                // Função auxiliar que busca controle pelo nome no container (recursiva)
                Control FindByName(string name)
                {
                    var arr = container.Controls.Find(name, true);
                    return arr != null && arr.Length > 0 ? arr[0] : null;
                }

                // Resetar cores antes
                if (destacar)
                {
                    // opcional: resetar apenas as possíveis cores, procurar todos e resetar
                    for (int i = 1; i <= linhas; i++)
                    {
                        var names = new[]
                        {
                        $"CkBCor{i}", $"CBxNomeCor{i}", $"TxbLarguraCor{i}", $"TxbComprimentoCor{i}"
                    };
                        foreach (var n in names)
                        {
                            var c = FindByName(n);
                            if (c != null)
                                c.BackColor = SystemColors.Window;
                        }
                    }
                }

                for (int i = 1; i <= linhas; i++)
                {
                    var ck = FindByName($"CkBCor{i}") as CheckBox;
                    if (ck == null)
                        continue; // se checkbox não existir, pula

                    if (!ck.Checked)
                        continue; // linha desmarcada, ignora

                    // Se marcado, precisamos validar os 3 controles
                    var cbxNome = FindByName($"CBxNomeCor{i}") as ComboBox;
                    var txbLarg = FindByName($"TxbLarguraCor{i}") as TextBox;
                    var txbComp = FindByName($"TxbComprimentoCor{i}") as TextBox;

                    // validações individuais, se algum controle não existir também considera erro
                    if (cbxNome == null || (cbxNome.SelectedIndex < 0 && string.IsNullOrWhiteSpace(cbxNome?.Text)))
                    {
                        tudoOk = false;
                        if (destacar && cbxNome != null) cbxNome.BackColor = Color.LightYellow;
                        if (primeiroInvalido == null) primeiroInvalido = cbxNome;
                    }

                    if (txbLarg == null || string.IsNullOrWhiteSpace(txbLarg?.Text))
                    {
                        tudoOk = false;
                        if (destacar && txbLarg != null) txbLarg.BackColor = Color.LightYellow;
                        if (primeiroInvalido == null) primeiroInvalido = txbLarg;
                    }

                    if (txbComp == null || string.IsNullOrWhiteSpace(txbComp?.Text))
                    {
                        tudoOk = false;
                        if (destacar && txbComp != null) txbComp.BackColor = Color.LightYellow;
                        if (primeiroInvalido == null) primeiroInvalido = txbComp;
                    }
                }

                // Focar no primeiro inválido encontrado
                if (!tudoOk && primeiroInvalido != null)
                {
                    try
                    {
                        primeiroInvalido.Focus();
                    }
                    catch { /* ignore */ }
                }

                return tudoOk;
            }
        
    }
}

