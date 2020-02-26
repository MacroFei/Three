using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();
        public DepartmentService()
        {
            _departments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "BeiJing"
            });
            _departments.Add(new Department
            {
                Id = 2,
                Name = "RD",
                EmployeeCount = 52,
                Location = "ShangHai"
            });
            _departments.Add(new Department
            {
                Id = 3,
                Name = "Java",
                EmployeeCount = 22,
                Location = "ZheJiang"
            });
        }
        public Task Add(Department department)
        {
            department.Id = _departments.Max(x => x.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(function: () => _departments.AsEnumerable());

        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(function: () => _departments.FirstOrDefault(x => x.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(function:()=>
            {
                return new CompanySummary
                {
                    EmployeeCount = _departments.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_departments.Average(x => x.EmployeeCount)
                };
            });
        }
    }
}
