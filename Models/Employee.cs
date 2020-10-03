using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWebApp.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override string ToString()
        {
            return $"<p>Employee Id: {EmpID}</P><p> Employee Name: {EmpName}</p><p>Employee Address: {EmpAddress}</p><p>Employee Salary: {EmpSalary}</p>";
        }
    }
}