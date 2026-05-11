namespace GestionReservationSalles
{
    public partial class FrmInscription : Form
    {
        public static FrmInscription Instance { get; private set; } = new FrmInscription();

        private UserManager userManager = UserManager.Instance;

        public FrmInscription()
        {
            InitializeComponent();

            tbxPassword.UseSystemPasswordChar = true;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            string name = tbxName.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string password = tbxPassword.Text.Trim();

            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                MessageBox.Show("Please enter a valid email address!");
                return;
            }

            Regex passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one letter and one number!");
                return;
            }

            bool created = userManager.Register(name, email, password);

            if (!created)
            {
                MessageBox.Show("This email already exists!");
                return;
            }

            MessageBox.Show("Registration successful!");

            tbxName.Clear();
            tbxEmail.Clear();
            tbxPassword.Clear();

            FrmLogin frmLogin = FrmLogin.Instance;
            frmLogin.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = FrmLogin.Instance;
            frmLogin.Show();
            this.Hide();
        }

        private void FrmInscription_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
