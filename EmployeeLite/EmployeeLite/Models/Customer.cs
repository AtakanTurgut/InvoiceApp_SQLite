using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLite.Models
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }
        public string Company { get; set; }
        public int SupportRepId { get; set; }
    }
}
