using PayRollCal.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRollCal.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeDetails newEmployee);
        EmployeeDetails GetById(int employeeId);
        Task UpdateAsync(EmployeeDetails employeeDet);
        Task UpdateAsync(int id);
        Task Delete(int employeeId);
        decimal StudentLoanRepaymentAmount(int id, decimal totalAmount);
        IEnumerable<EmployeeDetails> GetAll();
        IEnumerable<SelectListItem> GetAllEmployeesForPayroll();
    }
}
