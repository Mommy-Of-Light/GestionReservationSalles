namespace GestionReservationSalles
{
    partial class FrmAccueil
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
            btnLogOut = new Button();
            btnReservations = new Button();
            btnAdmin = new Button();
            listBoxMyReservations = new ListBox();
            SuspendLayout();
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(494, 12);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(75, 23);
            btnLogOut.TabIndex = 0;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnReservations
            // 
            btnReservations.Location = new Point(12, 12);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(150, 23);
            btnReservations.TabIndex = 1;
            btnReservations.Text = "Manage Reservations";
            btnReservations.UseVisualStyleBackColor = true;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(168, 12);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(150, 23);
            btnAdmin.TabIndex = 2;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Visible = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // listBoxMyReservations
            // 
            listBoxMyReservations.Location = new Point(12, 50);
            listBoxMyReservations.Name = "listBoxMyReservations";
            listBoxMyReservations.Size = new Size(560, 289);
            listBoxMyReservations.TabIndex = 2;
            listBoxMyReservations.DoubleClick += listBoxMyReservations_DoubleClick;
            // 
            // FrmAccueil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 350);
            Controls.Add(btnAdmin);
            Controls.Add(listBoxMyReservations);
            Controls.Add(btnReservations);
            Controls.Add(btnLogOut);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmAccueil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAccueil";
            Closed += FrmAccueil_Closed;
            Shown += FrmAccueil_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogOut;
        private Button btnReservations;
        private Button btnAdmin;
        private ListBox listBoxMyReservations;
    }
}