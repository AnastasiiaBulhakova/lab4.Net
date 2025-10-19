using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.class_lab4
{
    public class PayrollManager
    {
        private List<IWorkable> employees;

        public PayrollManager()
        {
            employees = new List<IWorkable>();
        }

        // Додати співробітника до списку
        public void AddEmployee(IWorkable employee)
        {
            if (employee != null)
                employees.Add(employee);
        }

        // Повернути список усіх співробітників
        public List<IWorkable> GetAllEmployees()
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
