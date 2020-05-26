using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayRollCal.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        public DateTime PayDate { get; set; }
        public string Paymonth { get; set; }
        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal Hourlyrate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWoreked { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ContrctHours { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OvertimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal Contrctearning { get; set; }
        [Column(TypeName = "money")]
        public decimal Overtimeearning { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")]
        public decimal NetPay { get; set; }
        [Column(TypeName ="money")]
        public Nullable<decimal> SLC { get; set; }
      

    }
}
