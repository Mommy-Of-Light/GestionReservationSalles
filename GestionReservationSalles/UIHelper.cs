using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionReservationSalles
{
    public static class UIHelper
    {
        private static readonly HashSet<Form> handlerAttached = new HashSet<Form>();

        public static void ShowAndHide(Form current, Form next)
        {
            if (next != null)
            {
                if (next.IsDisposed)
                {
                    // recréer si possible via la propriété singleton conventionnelle :
                    var type = next.GetType();
                    next = (Form)Activator.CreateInstance(type)!; // ou utiliser la propriété Instance spécifique
                }

                next.StartPosition = FormStartPosition.CenterScreen;
                if (current != null && !handlerAttached.Contains(next))
                {
                    next.FormClosed += (s, e) => { try { current.Show(); } catch { } };
                    handlerAttached.Add(next);
                }
                next.Show();
            }

            current?.Hide();
        }
    }
}
