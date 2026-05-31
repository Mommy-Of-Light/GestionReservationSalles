namespace GestionReservationSalles
{
    partial class FrmAdmin
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
            listUsers = new ListBox();
            comboRoles = new ComboBox();
            btnSetRole = new Button();
            listRooms = new ListBox();
            txtRoomName = new TextBox();
            txtCapacity = new TextBox();
            txtBuilding = new TextBox();
            txtFloor = new TextBox();
            btnAddRoom = new Button();
            btnDeleteUser = new Button();
            btnDeleteRoom = new Button();
            SuspendLayout();
            // 
            // listUsers
            // 
            listUsers.FormattingEnabled = true;
            listUsers.Location = new Point(12, 12);
            listUsers.Name = "listUsers";
            listUsers.Size = new Size(300, 199);
            listUsers.TabIndex = 0;
            // 
            // comboRoles
            // 
            comboRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRoles.Items.AddRange(new object[] { "user", "teacher", "admin" });
            comboRoles.Location = new Point(12, 217);
            comboRoles.Name = "comboRoles";
            comboRoles.Size = new Size(121, 23);
            comboRoles.TabIndex = 1;
            // 
            // btnSetRole
            // 
            btnSetRole.Location = new Point(139, 217);
            btnSetRole.Name = "btnSetRole";
            btnSetRole.Size = new Size(75, 23);
            btnSetRole.TabIndex = 2;
            btnSetRole.Text = "Set Role";
            btnSetRole.UseVisualStyleBackColor = true;
            btnSetRole.Click += btnSetRole_Click;
            // 
            // listRooms
            // 
            listRooms.FormattingEnabled = true;
            listRooms.Location = new Point(330, 11);
            listRooms.Name = "listRooms";
            listRooms.Size = new Size(440, 199);
            listRooms.TabIndex = 3;
            listRooms.DoubleClick += listRooms_DoubleClick;
            // 
            // txtRoomName
            // 
            txtRoomName.Location = new Point(330, 217);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.PlaceholderText = "Name";
            txtRoomName.Size = new Size(100, 23);
            txtRoomName.TabIndex = 4;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(436, 217);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.PlaceholderText = "Capacity";
            txtCapacity.Size = new Size(50, 23);
            txtCapacity.TabIndex = 5;
            // 
            // txtBuilding
            // 
            txtBuilding.Location = new Point(492, 217);
            txtBuilding.Name = "txtBuilding";
            txtBuilding.PlaceholderText = "Building";
            txtBuilding.Size = new Size(60, 23);
            txtBuilding.TabIndex = 6;
            // 
            // txtFloor
            // 
            txtFloor.Location = new Point(558, 217);
            txtFloor.Name = "txtFloor";
            txtFloor.PlaceholderText = "Floor";
            txtFloor.Size = new Size(50, 23);
            txtFloor.TabIndex = 7;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(614, 217);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(75, 23);
            btnAddRoom.TabIndex = 8;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(220, 217);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(92, 23);
            btnDeleteUser.TabIndex = 9;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Location = new Point(695, 216);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(75, 23);
            btnDeleteRoom.TabIndex = 10;
            btnDeleteRoom.Text = "Delete Room";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // FrmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 260);
            Controls.Add(btnAddRoom);
            Controls.Add(txtFloor);
            Controls.Add(txtBuilding);
            Controls.Add(txtCapacity);
            Controls.Add(txtRoomName);
            Controls.Add(listRooms);
            Controls.Add(btnSetRole);
            Controls.Add(comboRoles);
            Controls.Add(listUsers);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnDeleteRoom);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.ComboBox comboRoles;
        private System.Windows.Forms.Button btnSetRole;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.ListBox listRooms;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
    }
}
