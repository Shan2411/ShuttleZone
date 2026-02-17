using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShuttleZone.UserManagement
{
    public partial class ucUserManagement : UserControl
    {
        private BindingList<UserModel> users = new BindingList<UserModel>();

        public ucUserManagement()
        {
            InitializeComponent();

            
            dgvUsers.AutoGenerateColumns = false;

     
            dgvUsers.DataSource = users;

        
            StyleDataGridView();

        
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
        }

        
        // SAFE STYLING 
      
        private void StyleDataGridView()
        {
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AllowUserToResizeRows = false;

            // Header Style 
            dgvUsers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(124, 58, 237);
            dgvUsers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvUsers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ThemeStyle.HeaderStyle.Height = 45;

            dgvUsers.ColumnHeadersHeight = 45;

            // Row Style
            dgvUsers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(55, 65, 81);
            dgvUsers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10);
            dgvUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(237, 233, 254);
            dgvUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dgvUsers.ThemeStyle.RowsStyle.Height = 45;

            // Alternating rows
            dgvUsers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(249, 250, 251);

            // Grid color
            dgvUsers.GridColor = Color.FromArgb(230, 230, 230);

            dgvUsers.ReadOnly = true;
        }

        //  ROLE & STATUS BADGE COLORING
  
        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // ROLE COLUMN
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role" && e.Value != null)
            {
                string role = e.Value.ToString().ToLower();

                if (role == "admin")
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);  
                else if (role == "manager")
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); 
                else if (role == "front desk")
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);  

                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            }

            // STATUS COLUMN
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().ToLower();

                if (status == "active")
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);  
                else
                    e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);  

                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            }
        }
        //  ADD USER BUTTON (UNCHANGED FUNCTIONALITY)
     
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (Form popup = new Form())
            {
                popup.FormBorderStyle = FormBorderStyle.None;
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.BackColor = Color.White;

                UC_AddUserMain addUserUC = new UC_AddUserMain();
                addUserUC.Location = new Point(0, 0);

                popup.ClientSize = addUserUC.Size;

                addUserUC.UserCreated += (s, newUser) =>
                {
                    users.Add(newUser);
                    popup.Close();
                };

               

                addUserUC.CloseRequested += (s, args) =>
                {
                    popup.Close();
                };

                popup.Controls.Add(addUserUC);
                popup.ShowDialog();
            }
        }



        private void tblRoot_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void label21_Click(object sender, EventArgs e)
        {
            
        }

    }

}
