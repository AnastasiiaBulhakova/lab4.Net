using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace lab4.class_lab4
{
    public class Programmer : Employee
    {
        public int level; // 0 junior  1 senior
        private double bonus;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public double Bonus
        {
            get { return bonus; }
        }

        public Programmer(int experience, double hourlyRate, int level): base(0, experience, hourlyRate)
        {
            this.level = level;
        }
        public void CalculateBonus()
        {
            if (level == 0) bonus = 0.05 * hourlyRate * 160;
            else bonus = 0.2 * hourlyRate * 160;
        }
        public override double CalculateMonthlySalary()
        {
            CalculateBonus();
            return hourlyRate * 160 + bonus;
        }
        public override string GetProjects()
        {
            if (level == 0)
            {
                return "1. Невеликий сайт-візитка\n" +
                       "2. Модуль тестування";
            }
            else
            {
                return "1. Корпоративна CRM система\n" +
                       "2. Серверна частина API\n" +
                       "3. Мобільний застосунок";
            }
        }
    }
}
