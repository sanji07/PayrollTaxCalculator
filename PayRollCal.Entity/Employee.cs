using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayRollCal.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmpId { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        [Required, MaxLength(10)]
        public string TFN { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(20)]
        public string City { get; set; }
        [Required, MaxLength(4)]
        public string POcode { get; set; }
        public string Phone { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }
    }
}
