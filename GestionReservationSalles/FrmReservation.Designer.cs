namespace GestionReservationSalles
{
    partial class FrmReservation
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboRooms = new ComboBox();
            datePicker = new DateTimePicker();
            txtHours = new TextBox();
            txtClass = new TextBox();
            btnAdd = new Button();
            listBoxReservations = new ListBox();
            SuspendLayout();
            // 
            // comboRooms
            // 
            comboRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRooms.FormattingEnabled = true;
            comboRooms.Location = new Point(12, 12);
            comboRooms.Name = "comboRooms";
            comboRooms.Size = new Size(240, 23);
            comboRooms.TabIndex = 0;
            comboRooms.SelectedIndexChanged += comboRooms_SelectedIndexChanged;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(12, 41);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(240, 23);
            datePicker.TabIndex = 1;
            // 
            // txtHours
            // 
            txtHours.Location = new Point(12, 70);
            txtHours.Name = "txtHours";
            txtHours.PlaceholderText = "Hours (e.g. 08:00-10:00)";
            txtHours.Size = new Size(240, 23);
            txtHours.TabIndex = 2;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(12, 99);
            txtClass.Name = "txtClass";
            txtClass.PlaceholderText = "Class name";
            txtClass.Size = new Size(240, 23);
            txtClass.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 128);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(240, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Reservation";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // listBoxReservations
            // 
            listBoxReservations.FormattingEnabled = true;
            listBoxReservations.Location = new Point(12, 162);
            listBoxReservations.Name = "listBoxReservations";
            listBoxReservations.Size = new Size(560, 184);
            listBoxReservations.TabIndex = 5;
            // 
            // FrmReservation
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(listBoxReservations);
            Controls.Add(btnAdd);
            Controls.Add(txtClass);
            Controls.Add(txtHours);
            Controls.Add(datePicker);
            Controls.Add(comboRooms);
            Name = "FrmReservation";
            Text = "Reservations";
            Load += FrmReservation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboRooms;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBoxReservations;
    }
}
