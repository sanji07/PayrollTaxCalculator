using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollCal.Models
{
    public class EmployeeDetailViewModel
    {

        public int Id { get; set; }

        public string EmpId { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }

        public string TFN { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string POcode { get; set; }
        public string Phone { get; set; }
    }
}
