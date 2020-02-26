using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    public class Employee
    {
        public int Id { get; set; }
        /// <summary>
        /// 外键 部门id
        /// </summary>
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public bool Fired { get; set; }
    }

    public enum Gender
    {
        女 = 0,
        男 = 1
    }
}
