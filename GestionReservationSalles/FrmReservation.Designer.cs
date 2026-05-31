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
            this.comboRooms = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listBoxReservations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboRooms
            // 
            this.comboRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRooms.FormattingEnabled = true;
            this.comboRooms.Location = new System.Drawing.Point(12, 12);
            this.comboRooms.Name = "comboRooms";
            this.comboRooms.Size = new System.Drawing.Size(240, 23);
            this.comboRooms.TabIndex = 0;
            this.comboRooms.SelectedIndexChanged += new System.EventHandler(this.comboRooms_SelectedIndexChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(12, 41);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(240, 23);
            this.datePicker.TabIndex = 1;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(12, 70);
            this.txtHours.Name = "txtHours";
            this.txtHours.PlaceholderText = "Hours (e.g. 08:00-10:00)";
            this.txtHours.Size = new System.Drawing.Size(240, 23);
            this.txtHours.TabIndex = 2;
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(12, 99);
            this.txtClass.Name = "txtClass";
            this.txtClass.PlaceholderText = "Class name";
            this.txtClass.Size = new System.Drawing.Size(240, 23);
            this.txtClass.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(240, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Reservation";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBoxReservations
            // 
            this.listBoxReservations.FormattingEnabled = true;
            this.listBoxReservations.ItemHeight = 15;
            this.listBoxReservations.Location = new System.Drawing.Point(12, 157);
            this.listBoxReservations.Name = "listBoxReservations";
            this.listBoxReservations.Size = new System.Drawing.Size(560, 184);
            this.listBoxReservations.TabIndex = 5;
            // 
            // FrmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.listBoxReservations);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.comboRooms);
            this.Name = "FrmReservation";
            this.Text = "Reservations";
            this.Load += new System.EventHandler(this.FrmReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboRooms;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listBoxReservations;
    }
}
