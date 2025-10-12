using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.class_lab4
{
    public class Designer : Employee
    {
         public int specialization; // 0 - Графічний дизайнер, 1 -UX/UI дизайнер, 2 - 3D або Motion дизайнер
         private double projectCost;

         public Designer(int experience, double hourlyRate, int specialization)
         : base(1, experience, hourlyRate) // 1 — Дизайнер
         {
            this.specialization = specialization;
         }
         public double CalculateProjectCost(int hours)
         {
            return hourlyRate * hours;
         }
         public override double CalculateMonthlySalary()
         {
             return hourlyRate * 160;
         }
        public override string GetProjects()
        {
            string projects = "";

            switch (specialization)
            {
                case 0: // Графічний дизайнер
                    projects = "Logo Design\nBrand Book\nProduct Packaging";
                    break;

                case 1: // UX/UI дизайнер
                    projects = "Mobile App UI\nWebsite Redesign\nDashboard Prototype";
                    break;

                case 2: // 3D або Motion дизайнер
                    projects = "3D Visualization\nAnimation Demo\nVideo Ad";
                    break;

                default:
                    projects = "General Design Tasks";
                    break;
            }

            return projects;
        }
    }
}
