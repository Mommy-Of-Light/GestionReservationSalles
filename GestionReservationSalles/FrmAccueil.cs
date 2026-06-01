using Prometheus;
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
        private UserManager userManager = UserManager.Instance;
        private ReservationManager reservationManager = new ReservationManager();

        private static FrmAccueil? _instance = null;
        public static FrmAccueil Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmAccueil();
                }
                return _instance;
            }
        }

        private FrmAccueil()
        {
            InitializeComponent();
            LoadMyReservations();
        }

        private void FrmAccueil_Shown(object sender, EventArgs e)
        {
            FrmAccueilAfterLogin();
        }

        private void FrmAccueilAfterLogin()
        {
            // show admin button only for admin users
            btnAdmin.Visible = userManager.CurrentUser?.Role == "admin";
            // refresh reservations when the form is shown
            if (userManager.CurrentUser != null)
            {
                if (userManager.CurrentUser.Role == "user")
                {
                    btnReservations.Text = "See Reservations";
                }
                else
                {
                    btnReservations.Text = "Manage Reservations";
                }
                LoadMyReservations();
            }
            else
            {
                this.Close();
            }
        }

        private void FrmAccueil_Activated(object sender, EventArgs e)
        {
            FrmAccueilAfterLogin();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            AppMetrics.ActiveUsers.Dec();

            userManager.Logout();

            FrmLogin frmLogin = FrmLogin.Instance;
            UIHelper.ShowAndHide(this, frmLogin);
        }

        private void FrmAccueil_Closed(object sender, EventArgs e)
        {
            userManager.Logout();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            var frm = FrmReservation.Instance;
            UIHelper.ShowAndHide(this, frm);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (userManager.CurrentUser?.Role == "admin")
            {
                var frm = FrmAdmin.Instance;
                UIHelper.ShowAndHide(this, frm);
            }
            else
            {
                MessageBox.Show("Admin access required");
            }
        }

        private void LoadMyReservations()
        {
            using (AppMetrics.ReservationLoadTime.NewTimer())
            {
                listBoxMyReservations.Items.Clear();

                if (userManager.CurrentUser == null)
                    return;

                var list =
                    reservationManager.GetReservationsForUser(
                        userManager.CurrentUser.IdUser);

                foreach (var r in list)
                {
                    listBoxMyReservations.Items.Add(r);
                }
            }
        }

        // public helper so other forms can request a refresh when they close
        public void RefreshReservations()
        {
            LoadMyReservations();
        }

        private void listBoxMyReservations_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxMyReservations.SelectedItem is Reservation r)
            {
                var confirm = MessageBox.Show("Cancel this reservation?","Confirm",MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    if (reservationManager.DeleteReservation(r))
                    {
                        AppMetrics.ReservationCancelled.Inc();

                        MessageBox.Show("Reservation cancelled");
                        LoadMyReservations();
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel reservation");
                    }
                }
            }
        }

        private void FrmAccueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            // arrêter la fermeture si l'utilisateur clique sur la croix ; masquer à la place
            e.Cancel = true;
            this.Hide();
        }
    }
}
