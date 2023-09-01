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
    public partial class InsertInvoiceForm : Form
    {
        int customerId;
        int invoiceId;

        public InsertInvoiceForm(int invoiceId)
        {
            InitializeComponent();
            this.invoiceId = invoiceId;
        }

        public InsertInvoiceForm(int customerId, int invoiceId)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.invoiceId = invoiceId;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var totalValue = decimal.Parse(txtTotal.Text);

            using (InvoiceRepository invoiceRepository = new InvoiceRepository())
            {
                invoiceRepository.SaveInvoice(customerId, dateTimeInvoiceDate.Value, txtBillingAddress.Text, txtBillingCity.Text, txtBillingCountry.Text, totalValue);
            }

            MessageBox.Show("Registration Successful!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dateTimeInvoiceDate.ResetText();
            txtBillingCountry.Clear();
            txtBillingCity.Clear();
            txtBillingAddress.Clear();
            txtTotal.Clear();
        }
    }
}
