using Dapper;
using EmployeeLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmployeeLite.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public List<Customer> GetAllByEmployeeId(int employeeId)
        {
            List<Customer> dataItemList = new List<Customer>();
            var parameters = new { EmployeeId = employeeId };
            dataItemList = connection.Query<Customer>("select * from customers where SupportRepId = @EmployeeId", parameters).ToList();

            return dataItemList;
        }

        public Employee GetName(int id)
        {
            Employee employee = new Employee();
            employee = connection.QueryFirstOrDefault<Employee>("select employees.FirstName, employees.LastName from employees\r\ninner join customers on customers.SupportRepId = employees.EmployeeId\r\nwhere CustomerId = " + id);

            return employee;
        }

        public Customer GetDataById(int id)
        {
            Customer customer = new Customer();
            var parameters = new { customerId = id };
            customer = connection.QueryFirstOrDefault<Customer>("select * from customers where CustomerId = @customerId", parameters);

            return customer;
        }

        public void SaveCustomer(string firstName, string lastName, string company,
            string country, string city, string state, string address,
            string postalCode, string phone, string fax, string email, int employeeId)
        {
            var parameters = new
            {
                _firstName = firstName,
                _lastName = lastName,
                _company = company,
                _country = country,
                _city = city,
                _state = state,
                _address = address,
                _postalCode = postalCode,
                _phone = phone,
                _fax = fax,
                _email = email,
                EmployeeId = employeeId
            };

            connection.Execute(
        @"insert or replace into customers (FirstName, LastName, Company, Country, City, State, Address, PostalCode, Phone, Fax, Email, SupportRepId)
        values (@_firstName, @_lastName, @_company, @_country, @_city, @_state, @_address, @_postalCode, @_phone, @_fax, @_email, @EmployeeId)",
        parameters);
        }

        public void UpdateCustomer(int customerId, string firstName, string lastName, string company,
            string country, string city, string state, string address,
            string postalCode, string phone, string fax, string email)
        {
            var parameters = new
            {
                _customerId = customerId,
                _firstName = firstName,
                _lastName = lastName,
                _company = company,
                _country = country,
                _city = city,
                _state = state,
                _address = address,
                _postalCode = postalCode,
                _phone = phone,
                _fax = fax,
                _email = email,
            };

            connection.Execute("update customers set FirstName = @_firstName, LastName = @_lastName, Company = @_company, " +
"Country = @_country, City = @_city, State = @_state, Address = @_address, " +
"PostalCode = @_postalCode, Phone = @_phone, Fax = @_fax, Email = @_email " +
"where CustomerId = @_customerId", parameters);
        }

        public void DeleteCustomer(int customerId)
        {
            connection.Execute("delete from customers where CustomerId = " + customerId);
        }
    }
}
