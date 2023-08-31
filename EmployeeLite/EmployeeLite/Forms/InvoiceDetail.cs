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
    public partial class InvoiceDetail : Form
    {
        int customerId = 0;

        public InvoiceDetail(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void InvoiceDetail_Load(object sender, EventArgs e)
        {
            using (InvoiceRepository invoiceRepository = new InvoiceRepository())
            {
                grdInvoice.DataSource = invoiceRepository.GetAll(customerId);
            }
        }
    }
}
