using EmployeeLite.Models;
using EmployeeLite.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeLite.Forms
{
    public partial class InsertEmployeeForm : Form
    {
        public InsertEmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                employeeRepository.SaveEmployee(txtTitle.Text, txtFirstName.Text, txtLastName.Text, dateTimeBirthDate.Value, dateTimeHireDate.Value, txtCountry.Text, txtCity.Text, txtState.Text, txtAddress.Text, txtPostalCode.Text, txtPhone.Text, txtFax.Text, txtEmail.Text);
            }

            MessageBox.Show("Registration Successful!");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
