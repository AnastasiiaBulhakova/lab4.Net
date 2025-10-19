using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4.class_lab4
{
    public class ProjectManager : IWorkable, ITrainable
    {

        public string GetProjects()
        {
            return "Планування проектів, контроль задач";
        }

        public double CalculateMonthlySalary()
        {
            return 6000; 
        }

        public string ConductTraining()
        {
            return $"Менеджер проводить тренінг: Управління проєктами";
        }
    }
}
