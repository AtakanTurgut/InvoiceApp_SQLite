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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace EmployeeLite.Forms
{
    public partial class CustomerDetail : Form
    {
        int customerId = 0;
        int invoiceId = 0;

        public CustomerDetail(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        public CustomerDetail(int customerId, int invoiceId)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.invoiceId = invoiceId;
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
            DialogResult result = MessageBox.Show("Are you sure you want to update the selected Customer?", "Customer Will Updated!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (CustomerRepository customerRepository = new CustomerRepository())
                {
                    customerRepository.UpdateCustomer(customerId, txtFirstName.Text, txtLastName.Text, txtCompany.Text, txtCountry.Text, txtCity.Text, txtState.Text, txtAddress.Text, txtPostalCode.Text, txtPhone.Text, txtFax.Text, txtEmail.Text);
                }

                MessageBox.Show("Customer Updated Successful!");
            }
            else
            {
                MessageBox.Show("Update Canceled.");
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            InsertInvoiceForm insertInvoiceForm = new InsertInvoiceForm(customerId, invoiceId);
            insertInvoiceForm.ShowDialog();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            var chosen = (Invoice)grdInvoice.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected Invoice?", "Invoice Will Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (InvoiceRepository invoiceRepository = new InvoiceRepository())
                {
                    invoiceRepository.DeleteInvoice(chosen.InvoiceId);
                }

                MessageBox.Show("Delete Successful!");

                GetInvoiceByCustomerId();
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }
        }

        private void btnRefreshInvoice_Click(object sender, EventArgs e)
        {
            GetInvoiceByCustomerId();
        }

        private void grdInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int invoiceId = (int)grdInvoice.Rows[e.RowIndex].Cells[0].Value;

            InvoiceDetail invoiceDetailForm = new InvoiceDetail(invoiceId);
            invoiceDetailForm.ShowDialog();
        }
    }
}
