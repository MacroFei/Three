using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Three.Models;
using Three.Service;

namespace Three.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IDepartmentService departmentService , IEmployeeService employeeService)
        {
            this._departmentService = departmentService;
            this._employeeService = employeeService;
        }
        //GET: Employee
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);
            //返回标题和属性
            ViewBag.Title = $"Employees of {department.Name}";
            ViewBag.DepartmentId = departmentId;

            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);
        }


        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            //判断model的属性是否合法
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }

            return RedirectToAction(nameof(Index), new { departmentId = model.DepartmentId });
        }

        public async Task<IActionResult> Fire (int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);

            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }

    }
}