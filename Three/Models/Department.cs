﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        /// <summary>
        /// 员工数量
        /// </summary>
        public int EmployeeCount { get; set; }
    }
}
