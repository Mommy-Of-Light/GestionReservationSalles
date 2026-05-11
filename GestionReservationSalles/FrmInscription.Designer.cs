namespace GestionReservationSalles
{
    partial class FrmInscription
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnInscription = new Button();
            btnLogin = new Button();
            tbxPassword = new TextBox();
            lblPassword = new Label();
            tbxEmail = new TextBox();
            lblEmail = new Label();
            tbxName = new TextBox();
            lblName = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Rockwell", 30F);
            lblTitle.Location = new Point(99, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(276, 58);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "INSCRIPTION";
            // 
            // btnInscription
            // 
            btnInscription.Location = new Point(12, 369);
            btnInscription.Name = "btnInscription";
            btnInscription.Size = new Size(437, 50);
            btnInscription.TabIndex = 3;
            btnInscription.Text = "Inscription";
            btnInscription.UseVisualStyleBackColor = true;
            btnInscription.Click += btnInscription_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 425);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(437, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Segoe UI", 12F);
            tbxPassword.Location = new Point(12, 307);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(437, 29);
            tbxPassword.TabIndex = 2;
            tbxPassword.UseSystemPasswordChar = true;
            tbxPassword.TextChanged += tbxPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(12, 280);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(88, 24);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password:";
            // 
            // tbxEmail
            // 
            tbxEmail.Font = new Font("Segoe UI", 12F);
            tbxEmail.Location = new Point(12, 225);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(437, 29);
            tbxEmail.TabIndex = 1;
            tbxEmail.TextChanged += tbxEmail_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(12, 198);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(88, 24);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail:";
            // 
            // tbxName
            // 
            tbxName.Font = new Font("Segoe UI", 12F);
            tbxName.Location = new Point(12, 140);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(437, 29);
            tbxName.TabIndex = 0;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.Location = new Point(12, 113);
            lblName.Name = "lblName";
            lblName.Size = new Size(88, 24);
            lblName.TabIndex = 14;
            lblName.Text = "Name:";
            // 
            // FrmInscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 487);
            Controls.Add(tbxName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Controls.Add(btnInscription);
            Controls.Add(btnLogin);
            Controls.Add(tbxPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbxEmail);
            Controls.Add(lblEmail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmInscription";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inscription";
            Closed += FrmInscription_Closed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnInscription;
        private Button btnLogin;
        private TextBox tbxPassword;
        private Label lblPassword;
        private TextBox tbxEmail;
        private Label lblEmail;
        private TextBox tbxName;
        private Label lblName;
    }
}