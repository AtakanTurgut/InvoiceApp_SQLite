using Dapper;
using EmployeeLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLite.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public List<Invoice> GetAll(int customerId)
        {
            List<Invoice> dataItemList = new List<Invoice>();
            var parameters = new { CustomerId = customerId };
            dataItemList = connection.Query<Invoice>("select * from invoices where CustomerId = @CustomerId", parameters).ToList();

            return dataItemList;
        }

        public Invoice GetDataById(int id)
        {
            Invoice invoice = new Invoice();
            var parameters = new { invoiceId = id };
            invoice = connection.QueryFirstOrDefault<Invoice>("select * from invoices where InvoiceId = @invoiceId", parameters);

            return invoice;
        }

        public void UpdateInvoice(int invoiceId, DateTime invoiceDate, string billingAddress, string billingCity, string billingCountry, decimal total)
        {
            var parameters = new
            {
                _invoiceId = invoiceId,
                _invoiceDate = invoiceDate,
                _billingAddress = billingAddress,
                _billingCity = billingCity,
                _billingCountry = billingCountry,
                _total = total
            };

            connection.Execute("update invoices set InvoiceDate = @_invoiceDate, BillingAddress = @_billingAddress, BillingCity = @_billingCity, BillingCountry = @_billingCountry, Total = @_total " +
                "where InvoiceId = @_invoiceId", parameters);
        }

        public void SaveInvoice(int customerId, DateTime invoiceDate, string billingAddress, string billingCity, string billingCountry, decimal total)
        {
            var parameters = new
            {
                _customerId = customerId,
                _invoiceDate = invoiceDate,
                _billingAddress = billingAddress,
                _billingCity = billingCity,
                _billingCountry = billingCountry,
                _total = total
            };

            connection.Execute(
                @"insert or replace into invoices (CustomerId, InvoiceDate, BillingAddress, BillingCity, BillingCountry, Total)
                values (@_customerId, @_invoiceDate, @_billingAddress, @_billingCity, @_billingCountry, @_total)",
                parameters);
        }

        public void DeleteInvoice(int invoiceId)
        {
            connection.Execute("delete from invoices where InvoiceId = " + invoiceId);
        }
    }
}
