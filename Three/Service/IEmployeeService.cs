using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Service
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task Add(Employee employee);
        /// <summary>
        /// 根据部门ID 获取对应所有员工
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        /// <summary>
        /// 开除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> Fire(int id);
    }
}
