using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCodeBased.Models;

namespace CoreCodeBased.Controllers
{
    public class EmployeesController : Controller
    {
        EFDataContext _dbContext = new EFDataContext();


        public IActionResult Index()
        {


            var data = (from dept in _dbContext.Departments
                        join emp in _dbContext.Employees
                        on dept.DepartmentId equals emp.DepartmentId
                        select new Employee
                        {
                            EmployeeId = emp.EmployeeId,
                            EmployeeCode = emp.EmployeeCode,
                            EmployeeName = emp.EmployeeName,
                            DepartmentId = emp.DepartmentId,
                            DepartmentName = dept.DepartmentName
                        }).ToList();

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _dbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _dbContext.Departments.ToList();
            return View();
        }



        public IActionResult Edit(int id)
        {
            Employee data = _dbContext.Employees.Where(p => p.EmployeeId == id).FirstOrDefault();
            ViewBag.Departments = _dbContext.Departments.ToList();
            return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("EmployeeId");
            if (ModelState.IsValid)
            {
                _dbContext.Employees.Update(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _dbContext.Departments.ToList();
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            Employee data = _dbContext.Employees.Where(p => p.EmployeeId == id).FirstOrDefault();
            if (data != null)
            {
                _dbContext.Employees.Remove(data);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
