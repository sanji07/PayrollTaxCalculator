using Microsoft.AspNetCore.Http;
using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollCal.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string EmpId { get; set; }
        [Required(ErrorMessage = "First Name is Required"), MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required"), MaxLength(50)]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        [Required]
        public string TFN { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(3)]
        public string City { get; set; }
        [Required, MaxLength(4)]
        public string POcode { get; set; }
        public string Phone { get; set; }
    }
}
