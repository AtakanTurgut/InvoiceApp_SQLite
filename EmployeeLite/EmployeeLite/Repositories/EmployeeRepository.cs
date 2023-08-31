using Dapper;
using EmployeeLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLite.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeRepository()
        {

        }

        public List<Employee> GetAll()
        {
            List<Employee> dataItemList = new List<Employee>();
            dataItemList = connection.Query<Employee>("select * from employees").ToList();

            return dataItemList;
        }

        public Employee GetDataById(int id)
        {
            Employee employee = new Employee();
            var parameters = new { employeeId = id };
            employee = connection.QueryFirstOrDefault<Employee>("select * from employees where EmployeeId = @employeeId", parameters);

            return employee;
        }

        public void UpdateEmployee(int employeeId, string title, string firstName, string lastName,
            string country, string city, string state, string address,
            string postalCode, string phone, string fax, string email)
        {
            var parameters = new
            {
                _employeeId = employeeId,
                _title = title,
                _firstName = firstName,
                _lastName = lastName,
                _country = country,
                _city = city,
                _state = state,
                _address = address,
                _postalCode = postalCode,
                _phone = phone,
                _fax = fax,
                _email = email
            };

            connection.Execute("update employees set Title = @_title, FirstName = @_firstName, LastName = @_lastName," +
                "Country = @_country, City = @_city, State = @_state, Address = @_address," +
                "PostalCode = @_postalCode, Phone = @_phone, Fax = @_fax, Email = @_email where EmployeeId = @_employeeId", parameters);
        }

        public void SaveEmployee(string title, string firstName, string lastName, DateTime birthDate, DateTime hireDate,
            string country, string city, string state, string address,
            string postalCode, string phone, string fax, string email)
        {
            var parameters = new
            {
                _title = title,
                _firstName = firstName,
                _lastName = lastName,
                _birthDate = birthDate,
                _hireDate = hireDate,
                _country = country,
                _city = city,
                _state = state,
                _address = address,
                _postalCode = postalCode,
                _phone = phone,
                _fax = fax,
                _email = email
            };

            connection.Execute(
    @"insert or replace into employees (Title, FirstName, LastName, BirthDate, HireDate, Country, City, State, Address, PostalCode, Phone, Fax, Email)
    values (@_title, @_firstName, @_lastName, @_birthDate, @_hireDate, @_country, @_city, @_state, @_address, @_postalCode, @_phone, @_fax, @_email)",
    parameters);
        }

        public void DeleteEmployee(int employeeId)
        {
            connection.Execute("delete from employees where EmployeeId = " + employeeId);
        }
    }
}
