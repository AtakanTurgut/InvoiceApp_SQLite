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
    public partial class EmployeeDetail : Form
    {
        int employeeId;

        public EmployeeDetail(int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void EmployeeDetail_Load(object sender, EventArgs e)
        {
            GetEmployeeById();
            GetCustomersByEmployeeId();
        }

        void GetEmployeeById()
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository()) 
            {
                Employee dataItem = employeeRepository.GetDataById(employeeId);

                if (dataItem != null)
                {
                    txtTitle.Text = dataItem.Title;
                    txtFirstName.Text = dataItem.FirstName;
                    txtLastName.Text = dataItem.LastName;
                    dateTimeBirthDate.Text = dataItem.BirthDate.ToString();
                    dateTimeHireDate.Text = dataItem.HireDate.ToString();

                    txtCountry.Text = dataItem.Country;
                    txtCity.Text = dataItem.City;
                    txtState.Text = dataItem.State;
                    txtAddress.Text = dataItem.Address;

                    txtPostalCode.Text = dataItem.PostalCode;
                    txtPhone.Text = dataItem.Phone;
                    txtFax.Text = dataItem.Fax;
                    txtEmail.Text = dataItem.Email;
                }
            }
        }

        void GetCustomersByEmployeeId()
        {
            using (CustomerRepository  customerRepository = new CustomerRepository())
            {
                grdCustomer.DataSource = customerRepository.GetAllByEmployeeId(employeeId);
            }
        }

        private void grdCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int customerId = (int)grdCustomer.Rows[e.RowIndex].Cells[0].Value;

            CustomerDetail customerDetailForm = new CustomerDetail(customerId);
            customerDetailForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                employeeRepository.UpdateEmployee(employeeId, txtTitle.Text, txtFirstName.Text, txtLastName.Text, txtCountry.Text, txtCity.Text, txtState.Text, txtAddress.Text, txtPostalCode.Text, txtPhone.Text, txtFax.Text, txtEmail.Text);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            GetCustomersByEmployeeId();
        }

        private void btnAddCustmer_Click(object sender, EventArgs e)
        {
            InsertCustomerForm insertCustomerForm = new InsertCustomerForm(employeeId);
            insertCustomerForm.ShowDialog();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var chosen = (Customer)grdCustomer.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected Customer?", "Customer Will Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (CustomerRepository customerRepository = new CustomerRepository())
                {
                    customerRepository.DeleteCustomer(chosen.CustomerId);
                }

                MessageBox.Show("Delete Successful!");

                GetCustomersByEmployeeId();
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }           
        }
    }
}
