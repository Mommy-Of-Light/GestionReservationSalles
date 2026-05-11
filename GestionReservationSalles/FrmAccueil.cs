using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionReservationSalles
{
    public partial class FrmAccueil : Form
    {
        public static FrmAccueil Instance { get; private set; } = new FrmAccueil();

        private UserManager userManager = UserManager.Instance;

        public FrmAccueil()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = FrmLogin.Instance;
            frmLogin.Show();
            this.Hide();
        }

        private void FrmAccueil_Closed(object sender, EventArgs e)
        {
            userManager.Logout();
            Instance = new FrmAccueil();
            FrmLogin frmLogin = FrmLogin.Instance;
            frmLogin.Show();
        }
    }
}
