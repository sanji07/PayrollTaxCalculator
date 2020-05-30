using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollCal.Models
{
    public class PaymentRecordDetailViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }
        [Display(Name = "Month")]
        public string Paymonth { get; set; }
        [Display(Name = "TaxYear")]
        public int TaxYearId { get; set; }
        public string Year { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; } 
        [Display(Name = "Hourly rate")]
        public decimal Hourlyrate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HoursWoreked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContrctHours { get; set; }
        [Display(Name = "Overtime Hours")]
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeRate { get; set; }
        [Display(Name = "Contractual Earning")]
        public decimal Contrctearning { get; set; }
        [Display(Name = "Overtime Earning")]
        public decimal Overtimeearning { get; set; }
        [Display(Name = "Tax")]
        public decimal Tax { get; set; }
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { get; set; }
        [Display(Name = "Net Pay")]
        public decimal NetPay { get; set; }

        public Nullable<decimal> SLC { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
