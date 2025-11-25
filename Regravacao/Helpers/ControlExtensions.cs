using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Regravacao.Helpers
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Busca recursivamente todos os controles de um tipo específico no Form e seus sub-contêineres.
        /// </summary>
        public static IEnumerable<T> FindAllControls<T>(this Control.ControlCollection controls) where T : Control
        {
            foreach (Control control in controls)
            {
                if (control is T t)
                {
                    yield return t;
                }

                // Busca recursivamente nos controles internos
                foreach (T subControl in control.Controls.FindAllControls<T>())
                {
                    yield return subControl;
                }
            }
        }
    }
}
