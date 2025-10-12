using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.class_lab4
{
    public abstract class Employee
    {
        public int position; //0 - програміст, 1 - дизайнер
        public int experience;
        public double hourlyRate;
        public Employee(int position, int experience, double hourlyRate)
        {   if (experience >= 0 && hourlyRate >= 0)
            {
                this.position = position;
                this.experience = experience;
                this.hourlyRate = hourlyRate;
            }
            else throw new Exception("Досвід та оплата не повинні бути від'ємними");
        }
        public abstract double CalculateMonthlySalary();
        public abstract string GetProjects();
    }
}
