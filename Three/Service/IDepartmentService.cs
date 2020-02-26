using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Service
{
    public interface IDepartmentService
    {
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Department>> GetAll();
        /// <summary>
        /// 通过ID获取部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Department> GetById(int id);
        /// <summary>
        /// 获得整个公司的整体情况
        /// </summary>
        /// <returns></returns>
        Task<CompanySummary> GetCompanySummary();
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        Task Add(Department department);
    }
}
