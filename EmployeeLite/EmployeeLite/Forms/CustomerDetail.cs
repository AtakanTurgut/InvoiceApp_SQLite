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
    public partial class CustomerDetail : Form
    {
        int customerId = 0;

        public CustomerDetail(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            GetCustomerById();
            GetInvoiceByCustomerId();
        }

        void GetCustomerById()
        {
            using (CustomerRepository customerRepository = new CustomerRepository())
            {
                Customer dataItem = customerRepository.GetDataById(customerId);
                Employee data = customerRepository.GetName(customerId);

                if (dataItem != null)
                {
                    txtFirstName.Text = dataItem.FirstName;
                    txtLastName.Text = dataItem.LastName;
                    txtSupportRepId.Text = data.FirstName + " " + data.LastName;

                    txtCompany.Text = dataItem.Company;
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

        void GetInvoiceByCustomerId()
        {
            using (InvoiceRepository invoiceRepository = new InvoiceRepository())
            {
                grdInvoice.DataSource = invoiceRepository.GetAll(customerId);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (CustomerRepository customerRepository = new CustomerRepository())
            {
                customerRepository.UpdateCustomer(customerId, txtFirstName.Text, txtLastName.Text, txtCompany.Text, txtCountry.Text, txtCity.Text, txtState.Text, txtAddress.Text, txtPostalCode.Text, txtPhone.Text, txtFax.Text, txtEmail.Text);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshInvoice_Click(object sender, EventArgs e)
        {
            GetInvoiceByCustomerId();
        }
    }
}
