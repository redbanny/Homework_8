using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Employee Left { get; set; }
        public Employee Right { get; set; }
    }
}
