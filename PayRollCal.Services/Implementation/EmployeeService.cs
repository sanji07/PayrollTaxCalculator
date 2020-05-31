using PayRollCal.Entity;
using PayRollCal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PayRollCal.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal studentAmount;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.EmployeeDetails.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }
        public Employee GetById(int employeeId) =>
            _context.EmployeeDetails.Where(e => e.Id == employeeId).FirstOrDefault();


        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() =>
            _context.EmployeeDetails;

        public async Task UpdateAsync(Employee employeeDet)
        {
            _context.Update(employeeDet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes && totalAmount < 45881.00m)
            {
                studentAmount = 0.00m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 45881.01m && totalAmount <= 70890.00m)
            {
                studentAmount = 0.04m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 70890.01m && totalAmount <= 94868.00m)
            {
                studentAmount = 0.065m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 94868.01m && totalAmount <= 112989.00m)
            {
                studentAmount = 0.080m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 112989.01m && totalAmount <= 134792.00m)
            {
                studentAmount = 0.095m;
            }
            else if (employee.StudentLoan == StudentLoan.Yes && totalAmount >= 134792.01m)
            {
                studentAmount = 0.10m;
            }
            else
            {
                studentAmount = 0.00m;
            }
            return studentAmount;
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = emp.Fullname,
                Value = emp.Id.ToString(),
            });
        }
    }
}
