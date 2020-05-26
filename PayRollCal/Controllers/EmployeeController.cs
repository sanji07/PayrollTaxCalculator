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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var employee = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                FullName = employee.Fullname,
                Designation = employee.Designation,
                ImageUrl = employee.ImageUrl,
                DOJ = employee.DOJ,
                Gender = employee.Gender,
                City = employee.City,
            }).ToList();

            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new EmployeeDetails
                {
                    Id = model.Id,
                    EmpId = model.EmpId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Fullname = model.Fullname,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DOJ = model.DOJ,
                    Designation = model.Designation,
                    TFN = model.TFN,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    Address = model.Address,
                    Phone = model.Phone,
                    City = model.City,
                    POcode = model.POcode
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));


            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NoContent();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DOJ = employee.DOJ,
                Designation = employee.Designation,
                TFN = employee.TFN,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                Address = employee.Address,
                Phone = employee.Phone,
                City = employee.City,
                POcode = employee.POcode
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmpId = model.EmpId;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.Designation = model.Designation;
                employee.TFN = model.TFN;
                employee.DOB = model.DOB;
                employee.DOJ = model.DOJ;
                employee.PaymentMethod = model.PaymentMethod;
                employee.StudentLoan = model.StudentLoan;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.POcode = model.POcode;
                employee.Phone = model.Phone;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                Fullname = employee.Fullname,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DOJ = employee.DOJ,
                Designation = employee.Designation,
                Phone = employee.Phone,
                Email = employee.Email,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                Address = employee.Address,
                City = employee.City,
                POcode = employee.POcode,
                TFN = employee.TFN,
                ImageUrl = employee.ImageUrl
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();

            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.Fullname
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employeeService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}