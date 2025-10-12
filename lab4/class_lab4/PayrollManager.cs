using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.class_lab4
{
    public class PayrollManager
    {
        private List<Employee> employees;

        public PayrollManager()
        {
            employees = new List<Employee>();
        }

        // Додати співробітника до списку
        public void AddEmployee(Employee employee)
        {
            if (employee != null)
                employees.Add(employee);
        }

        // Повернути список усіх співробітників
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        // Розрахунок загального фонду зарплати
        public double CalculateTotalMonthlySalary()
        {
            double total = 0;
            foreach (var emp in employees)
            {
                total += emp.CalculateMonthlySalary();
            }
            return total;
        }
    }
}
