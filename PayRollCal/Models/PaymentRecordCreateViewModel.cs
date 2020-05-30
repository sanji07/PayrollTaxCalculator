using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollCal.Models
{
    public class PaymentRecordCreateViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;
        [Display(Name = "Month")]
        public string Paymonth { get; set; } = DateTime.Today.Month.ToString();
        [Display(Name ="TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; } = "ATO";
        [Display(Name = "Hourly rate")]
        public decimal Hourlyrate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HoursWoreked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContrctHours { get; set; } = 160m;
 
        public decimal OvertimeHours { get; set; }
        
        public decimal Contrctearning { get; set; }
        
        public decimal Overtimeearning { get; set; }
        
        public decimal Tax { get; set; }
        
        public decimal TotalEarnings { get; set; }
       
        public decimal TotalDeduction { get; set; }
        
        public decimal NetPay { get; set; }
        
        public Nullable<decimal> SLC { get; set; }
        public string FullName { get; set; }
    }
}
