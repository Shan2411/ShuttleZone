using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShuttleZone.Membership
{
    public partial class AddNewMember : Form
    {
        // --- Dragging fields ---
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // --- Shadow constant ---
        private const int CS_DROPSHADOW = 0x00020000;

        public AddNewMember()
        {
            InitializeComponent();

            // --- Make borderless ---
            this.FormBorderStyle = FormBorderStyle.None;

            // --- Optional: Set background color (if using Guna controls) ---
            this.BackColor = Color.White;

            // --- Make draggable anywhere on the form ---
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;

            // --- Attach drag events to all child controls so drag works even if mouse is on them ---
            AddDragEventsToControls(this.Controls);
        }

        // --- Recursively add drag events to all controls ---
        private void AddDragEventsToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseDown += Form_MouseDown;
                control.MouseMove += Form_MouseMove;
                control.MouseUp += Form_MouseUp;

                // If control has children, apply recursively
                if (control.HasChildren)
                    AddDragEventsToControls(control.Controls);
            }
        }

        // --- Shadow ---
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // --- Dragging methods ---
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // --- Close button (Guna picture box) ---
        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Optional: TableLayoutPanel Paint event ---
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            // You can customize painting here if needed
        }
    }
}
