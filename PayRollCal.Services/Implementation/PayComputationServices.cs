using PayRollCal.Entity;
using PayRollCal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRollCal.Services.Implementation
{
    public class PayComputationServices:IPayComputationService
    {
        private readonly ApplicationDbContext _context;
        private decimal contractualEarnings;
        private decimal netPay;
        private decimal OThours;
        public PayComputationServices(ApplicationDbContext context)
        {
            _context = context;

        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);


        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
            {
                Text = taxYears.YearofTax,
                Value = taxYears.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetByID(int id) => _context.PaymentRecords.Where(pay => pay.Id == id).FirstOrDefault();

        public TaxYear GetTaxYearById(int id) => _context.TaxYears.Where(year => year.Id == id).FirstOrDefault();
        
        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        {
            netPay = totalEarnings - totalDeduction;
            return netPay;
        }

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours) => overtimeRate * overtimeHours;


        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked <= contractualHours)
            {

                OThours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                OThours = hoursWorked - contractualHours;
            }
            return OThours;
        }


        public decimal OvertimeRate(decimal hourlyRate) => hourlyRate * 1.50m;


        public decimal TotalDeduction(decimal tax, decimal studentLoanRepayment) => tax + studentLoanRepayment;


        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings) => overtimeEarnings + contractualEarnings;

    }
}
