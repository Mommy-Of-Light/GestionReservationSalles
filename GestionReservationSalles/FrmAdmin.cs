using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionReservationSalles
{
    public partial class FrmAdmin : Form
    {

        private UserManager userManager = UserManager.Instance;
        private RoomManager roomManager = new RoomManager();
        private ReservationManager reservationManager = new ReservationManager();

        private static FrmAdmin? _instance;

        public static FrmAdmin Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new FrmAdmin();
                return _instance;
            }
        }

        private FrmAdmin()
        {
            InitializeComponent();
            LoadUsers();
            LoadRooms();
        }

        private void LoadUsers()
        {
            listUsers.Items.Clear();
            var users = userManager.GetAllUsers();
            foreach (var u in users)
                listUsers.Items.Add(u);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem is User u)
            {
                var confirm = MessageBox.Show($"Delete user {u.Name}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    if (userManager.DeleteUser(u.IdUser))
                    {
                        MessageBox.Show("User deleted");
                        LoadUsers();
                    }
                    else MessageBox.Show("Failed to delete user");
                }
            }
        }

        private void btnSetRole_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem is User u)
            {
                string newRole = comboRoles.SelectedItem?.ToString() ?? "user";
                if (userManager.UpdateUserRole(u.IdUser, newRole))
                {
                    MessageBox.Show("Role updated");
                    LoadUsers();
                }
            }
        }

        private void LoadRooms()
        {
            listRooms.Items.Clear();
            var rooms = roomManager.GetAllRooms();
            foreach (var r in rooms)
                listRooms.Items.Add(r);
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (listRooms.SelectedItem is Room r)
            {
                var confirm = MessageBox.Show($"Delete room {r.Name}?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    if (roomManager.DeleteRoom(r.IdRoom))
                    {
                        MessageBox.Show("Room deleted");
                        LoadRooms();
                    }
                    else MessageBox.Show("Failed to delete room");
                }
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var room = new Room { Name = txtRoomName.Text.Trim(), Capacity = int.TryParse(txtCapacity.Text, out var c) ? c : 0, Building = txtBuilding.Text.Trim(), Floor = int.TryParse(txtFloor.Text, out var f) ? f : 0 };
            if (roomManager.AddRoom(room))
            {
                MessageBox.Show("Room added");
                LoadRooms();
            }
        }

        private void listRooms_DoubleClick(object sender, EventArgs e)
        {
            // Show reservations for this room and allow delete
            if (listRooms.SelectedItem is Room r)
            {
                var res = reservationManager.GetReservationsForRoom(r.IdRoom);
                var dlg = new Form();
                var lb = new ListBox { Dock = DockStyle.Fill };
                foreach (var item in res) lb.Items.Add(item);
                lb.DoubleClick += (s, ev) =>
                {
                    if (lb.SelectedItem is Reservation sel)
                    {
                        var confirm = MessageBox.Show("Delete this reservation?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            if (reservationManager.DeleteReservation(sel))
                            {
                                MessageBox.Show("Deleted");
                                dlg.Close();
                            }
                            else MessageBox.Show("Failed");
                        }
                    }
                };
                dlg.Controls.Add(lb);
                dlg.ShowDialog();
            }
        }
    }
}
