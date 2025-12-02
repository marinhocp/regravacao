using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regravacao.Utils
{
    internal class VerificaSeEstaVazio
    {
        public static bool NaoVazio(TextBox txt)
        {
            return !string.IsNullOrWhiteSpace(txt.Text);
        }

    }
}
