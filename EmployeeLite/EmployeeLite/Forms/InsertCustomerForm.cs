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
    public partial class InsertCustomerForm : Form
    {
        int employeeId;

        public InsertCustomerForm(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (CustomerRepository customerRepository = new CustomerRepository())
            {
                customerRepository.SaveCustomer(txtFirstName.Text, txtLastName.Text, txtCompany.Text, txtCountry.Text, txtCity.Text, txtState.Text, txtAddress.Text, txtPostalCode.Text, txtPhone.Text, txtFax.Text, txtEmail.Text, employeeId);
            }

            MessageBox.Show("Registration Successful!");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
