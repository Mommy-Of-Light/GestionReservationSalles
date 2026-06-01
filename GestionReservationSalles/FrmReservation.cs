using System;
using System.Linq;
using System.Windows.Forms;

namespace GestionReservationSalles
{
    public partial class FrmReservation : Form
    {
        public static FrmReservation Instance { get; private set; } = new FrmReservation();

        private RoomManager roomManager = new RoomManager();
        private UserManager userManager = UserManager.Instance;
        private ReservationManager reservationManager = new ReservationManager();

        public FrmReservation()
        {
            InitializeComponent();
            LoadRooms();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000; // 3 seconds
            timer.Tick += (s, e) =>
            {
                LoadReservations();
                // if main form is open, refresh its reservation list as well
                try
                {
                    FrmAccueil.Instance.RefreshReservations();
                }
                catch { }
            };
            timer.Start();
        }

        private void LoadRooms()
        {
            var rooms = roomManager.GetAllRooms();
            comboRooms.DisplayMember = "Name";
            comboRooms.ValueMember = "IdRoom";
            comboRooms.DataSource = rooms;

            if (userManager.CurrentUser.Role == "user")
            {
                comboRooms.Enabled = false;
                datePicker.Enabled = false;
                txtHours.Enabled = false;
                txtClass.Enabled = false;
                btnAdd.Enabled = false;

                listBoxReservations.Location = new System.Drawing.Point(12, 12);
                listBoxReservations.Size = new System.Drawing.Size(560, 184);
            }
            else
            {
                comboRooms.Enabled = true;
                datePicker.Enabled = true;
                txtHours.Enabled = true;
                txtClass.Enabled = true;
                btnAdd.Enabled = true;

                listBoxReservations.Location = new System.Drawing.Point(12, 157);
                listBoxReservations.Size = new System.Drawing.Size(560, 184);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboRooms.SelectedItem == null || string.IsNullOrWhiteSpace(txtHours.Text) || string.IsNullOrWhiteSpace(txtClass.Text))
            {
                MessageBox.Show("Please fill all fields before adding a reservation.");
                return;
            }

            var current = UserManager.Instance.CurrentUser;
            if (current == null)
            {
                MessageBox.Show("You must be logged in to make a reservation.");
                return;
            }

            if (current.Role != "teacher" && current.Role != "admin")
            {
                MessageBox.Show("Only teachers and admins can make reservations.");
                return;
            }

            var r = new Reservation
            {
                IdRoom = (int)comboRooms.SelectedValue,
                IdUser = current.IdUser,
                Date = datePicker.Value.Date,
                Hours = txtHours.Text.Trim(),
                ClassName = txtClass.Text.Trim()
            };

            if (reservationManager.AddReservation(r))
            {
                AppMetrics.ReservationCreated.Inc();
                // clear the inputs on success
                txtHours.Clear();
                txtClass.Clear();
                datePicker.Value = DateTime.Now;
                LoadReservations();
            }
            else
            {
                MessageBox.Show("Failed to add reservation");
            }
        }

        private void FrmReservation_Load(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void LoadReservations()
        {
            if (comboRooms.SelectedItem == null) return;
            int idRoom = (int)comboRooms.SelectedValue;
            var list = reservationManager.GetReservationsForRoom(idRoom);
            listBoxReservations.Items.Clear();
            foreach (var res in list)
            {
                listBoxReservations.Items.Add(res);
            }
        }

        private void comboRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReservations();
        }
    }
}
