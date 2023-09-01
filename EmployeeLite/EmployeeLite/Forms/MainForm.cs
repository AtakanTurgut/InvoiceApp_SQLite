using EmployeeLite.Models;
using EmployeeLite.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeLite.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetEmployees();
        }

        public void GetEmployees()
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                grdEmployee.DataSource = employeeRepository.GetAll();
            }
        }

        private void grdEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var employeeId = (int)grdEmployee.Rows[e.RowIndex].Cells[0].Value;

            EmployeeDetail employeeDetailForm = new EmployeeDetail(employeeId);
            employeeDetailForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            InsertEmployeeForm insertEmployeeForm = new InsertEmployeeForm();
            insertEmployeeForm.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            var chosen = (Employee)grdEmployee.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected Employee?", "Employee Will Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (EmployeeRepository employeeRepository = new EmployeeRepository())
                {
                    employeeRepository.DeleteEmployee(chosen.EmployeeId);
                }

                MessageBox.Show("Delete Successful!");

                GetEmployees();
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }
        }
    }
}
