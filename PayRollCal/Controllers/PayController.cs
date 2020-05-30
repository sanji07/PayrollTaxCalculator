using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayRollCal.Entity;
using PayRollCal.Models;
using PayRollCal.Services;

namespace PayRollCal.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayComputationService _payComputationService;
        private readonly IEmployeeService _employeeService;
        private readonly ITaxService _taxService;
        private decimal ovrtime;
        private decimal contrctearn;
        private decimal ovrtimeearn;
        private decimal totalearn;
        private decimal tax;
        private decimal slc;
        private decimal totded;

        public PayController(IPayComputationService payComputationService, IEmployeeService employeeService, ITaxService taxService)
        {
            _payComputationService = payComputationService;
            _employeeService = employeeService;
            _taxService = taxService;
        }
        public IActionResult Index()
        {
            var payRecords = _payComputationService.GetAll().Select(pay => new PaymentRecordIndexViewModel
            {
                Id = pay.Id,
                EmployeeId = pay.EmployeeId,
                FullName = pay.FullName,
                PayDate = pay.PayDate,
                PayMonth = pay.Paymonth,
                TaxYearId = pay.TaxYearId,
                Year = _payComputationService.GetTaxYearById(pay.TaxYearId).YearofTax,
                TotalEarnings = pay.TotalEarnings,
                TotalDeduction = pay.TotalDeduction,
                NetPayment = pay.NetPay,
                EmployeeDetails=pay.EmployeeDetails
            });
            return View(payRecords);
        }
        public IActionResult Create() 
        {
            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.taxYears = _payComputationService.GetAllTaxYear();
            var model = new PaymentRecordCreateViewModel();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRecordCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var record = new PaymentRecord()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    FullName = _employeeService.GetById(model.EmployeeId).Fullname,
                    PayDate = model.PayDate,
                    Paymonth = model.Paymonth,
                    TaxYearId = model.TaxYearId,
                    TaxCode = model.TaxCode,
                    Hourlyrate = model.Hourlyrate,
                    HoursWoreked = model.HoursWoreked,
                    ContrctHours = model.ContrctHours,
                    OvertimeHours = ovrtime = _payComputationService.OvertimeHours(model.HoursWoreked, model.ContrctHours),
                    Contrctearning = contrctearn = _payComputationService.ContractualEarnings(model.ContrctHours, model.HoursWoreked, model.Hourlyrate),
                    Overtimeearning = ovrtimeearn = _payComputationService.OvertimeEarnings(_payComputationService.OvertimeRate(model.Hourlyrate), ovrtime),
                    TotalEarnings = totalearn = _payComputationService.TotalEarnings(ovrtimeearn, contrctearn),
                    Tax = tax = _taxService.TaxAmount(totalearn),
                    SLC = slc = _employeeService.StudentLoanRepaymentAmount(model.Id, totalearn),
                    TotalDeduction =totded= _payComputationService.TotalDeduction(tax, slc),
                    NetPay=_payComputationService.NetPay(totalearn,totded)
                };
                await _payComputationService.CreateAsync(record);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.taxYears = _payComputationService.GetAllTaxYear();
            return View();
        }
        public IActionResult Detail(int id)
        {
            var paymentRecord = _payComputationService.GetByID(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewModel()
                {
                Id=paymentRecord.Id,
                EmployeeId=paymentRecord.EmployeeId,
                FullName=paymentRecord.FullName,
                PayDate=paymentRecord.PayDate,
                Paymonth=paymentRecord.Paymonth,
                TaxYearId=paymentRecord.TaxYearId,
                Year=_payComputationService.GetTaxYearById(paymentRecord.TaxYearId).YearofTax,
                TaxCode=paymentRecord.TaxCode,
                Hourlyrate=paymentRecord.Hourlyrate,
                HoursWoreked=paymentRecord.HoursWoreked,
                ContrctHours=paymentRecord.ContrctHours,
                OvertimeHours=paymentRecord.OvertimeHours,
                OvertimeRate=_payComputationService.OvertimeRate(paymentRecord.Hourlyrate),
                Contrctearning=paymentRecord.Contrctearning,
                Overtimeearning=paymentRecord.Overtimeearning,
                Tax=paymentRecord.Tax,
                SLC=paymentRecord.SLC,
                TotalEarnings=paymentRecord.TotalEarnings,
                TotalDeduction=paymentRecord.TotalDeduction,
                EmployeeDetails=paymentRecord.EmployeeDetails,
                TaxYear=paymentRecord.TaxYear,
                NetPay=paymentRecord.NetPay
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult PaySlip(int id)
        {
            var paymentRecord = _payComputationService.GetByID(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PaymentRecordDetailViewModel()
            {
                Id = paymentRecord.Id,
                EmployeeId = paymentRecord.EmployeeId,
                FullName = paymentRecord.FullName,
                PayDate = paymentRecord.PayDate,
                Paymonth = paymentRecord.Paymonth,
                TaxYearId = paymentRecord.TaxYearId,
                Year = _payComputationService.GetTaxYearById(paymentRecord.TaxYearId).YearofTax,
                TaxCode = paymentRecord.TaxCode,
                Hourlyrate = paymentRecord.Hourlyrate,
                HoursWoreked = paymentRecord.HoursWoreked,
                ContrctHours = paymentRecord.ContrctHours,
                OvertimeHours = paymentRecord.OvertimeHours,
                OvertimeRate = _payComputationService.OvertimeRate(paymentRecord.Hourlyrate),
                Contrctearning = paymentRecord.Contrctearning,
                Overtimeearning = paymentRecord.Overtimeearning,
                Tax = paymentRecord.Tax,
                SLC = paymentRecord.SLC,
                TotalEarnings = paymentRecord.TotalEarnings,
                TotalDeduction = paymentRecord.TotalDeduction,
                EmployeeDetails = paymentRecord.EmployeeDetails,
                TaxYear = paymentRecord.TaxYear,
                NetPay = paymentRecord.NetPay
            };
            return View(model);
        }
    }
}
