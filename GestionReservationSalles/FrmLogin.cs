using System;
using System.Collections.Generic;
namespace GestionReservationSalles
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin Instance { get; private set; } = new FrmLogin();

        private string email;
        private string password;
        private UserManager userManager = UserManager.Instance;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            email = tbxEmail.Text.Trim();
            UpdateLoginButtonState();
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            password = tbxPassword.Text.Trim();
            UpdateLoginButtonState();
        }

        private void UpdateLoginButtonState()
        {
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            Regex passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            btnLogin.Enabled = !string.IsNullOrEmpty(email) 
                && !string.IsNullOrEmpty(password) 
                && emailRegex.IsMatch(email) 
                && passwordRegex.IsMatch(password);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool connected = userManager.Authenticate(email, password);

            if (connected)
            {
                MessageBox.Show($"Login successful!");
                FrmAccueil frmAccueil = FrmAccueil.Instance;
                // clear login fields on successful login
                tbxPassword.Clear();
                tbxEmail.Clear();
                UIHelper.ShowAndHide(this, frmAccueil);
            }

            else
                MessageBox.Show($"Login failed! Please check your email and password.");
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            FrmInscription frmInscription = FrmInscription.Instance;
            UIHelper.ShowAndHide(this, frmInscription);
        }

        private void FrmLogin_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
