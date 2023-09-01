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
    public partial class InvoiceDetail : Form
    {
        int invoiceId;

        public InvoiceDetail(int invoiceId)
        {
            InitializeComponent();
            this.invoiceId = invoiceId;
        }

        private void InvoiceDetail_Load(object sender, EventArgs e)
        {
            GetInvoiceById();
        }

        void GetInvoiceById()
        {
            using (InvoiceRepository invoiceRepository = new InvoiceRepository())
            {
                Invoice dataItem = invoiceRepository.GetDataById(invoiceId);

                if (dataItem != null)
                {
                    dateTimeInvoiceDate.Text = dataItem.InvoiceDate.ToString();
                    txtBillingCountry.Text = dataItem.BillingCountry;
                    txtBillingCity.Text = dataItem.BillingCity;
                    txtBillingAddress.Text = dataItem.BillingAddress;
                    txtTotal.Text = dataItem.Total.ToString();
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update the selected Invoice?", "Invoice Will Updated!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var totalValue = decimal.Parse(txtTotal.Text);

                using (InvoiceRepository invoiceRepository = new InvoiceRepository())
                {
                    invoiceRepository.UpdateInvoice(invoiceId, dateTimeInvoiceDate.Value ,txtBillingAddress.Text, txtBillingCity.Text, txtBillingCountry.Text, totalValue);
                }

                MessageBox.Show("Invoice Updated Successful!");
            }
            else
            {
                MessageBox.Show("Update Canceled.");
            }
        }
    }
}
