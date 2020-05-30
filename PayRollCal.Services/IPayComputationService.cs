﻿using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRollCal.Services
{
    public interface IPayComputationService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetByID(int id);
        TaxYear GetTaxYearById(int id);

        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal OvertimeRate(decimal hourlyRate);
        decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);
        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalDeduction(decimal tax, decimal studentLoanRepayment);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);


    }
}
