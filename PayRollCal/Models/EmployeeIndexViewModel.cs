using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollCal.Models
{
    public class EmployeeIndexViewModel
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOJ { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}
