using lab4.class_lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_test
{
    [TestClass]
    public class PayrollManager_Tests
    {
        [TestMethod]
        public void AddEmployee_AddsEmployeesToList()
        {
            // Arrange
            var payroll = new PayrollManager();
            var programmer = new Programmer(3, 120, 0);
            var designer = new Designer(2, 150, 1);

            // Act
            payroll.AddEmployee(programmer);
            payroll.AddEmployee(designer);
            List<Employee> employees = payroll.GetAllEmployees();

            // Assert
            Assert.AreEqual(2, employees.Count, "Неправильна кількість співробітників у списку.");
            Assert.IsTrue(employees.Contains(programmer), "Програміста не додано.");
            Assert.IsTrue(employees.Contains(designer), "Дизайнера не додано.");
        }

        [TestMethod]
        public void CalculateTotalMonthlySalary_ReturnsCorrectSum()
        {
            // Arrange
            var payroll = new PayrollManager();
            var programmerJunior = new Programmer(2, 100, 0); // Junior
            var programmerSenior = new Programmer(5, 200, 1); // Senior
            var designerUx = new Designer(3, 150, 1);         // UX/UI

            payroll.AddEmployee(programmerJunior);
            payroll.AddEmployee(programmerSenior);
            payroll.AddEmployee(designerUx);

            
            double juniorSalary = programmerJunior.CalculateMonthlySalary(); // 100*160 + бонус 5%
            double seniorSalary = programmerSenior.CalculateMonthlySalary(); // 200*160 + бонус 20%
            double designerSalary = designerUx.CalculateMonthlySalary();     // 150*160
            double expectedTotal = juniorSalary + seniorSalary + designerSalary;

            // Act
            double actualTotal = payroll.CalculateTotalMonthlySalary();

            // Assert
            Assert.AreEqual(expectedTotal, actualTotal, 0.01);
        }

        [TestMethod]
        public void CalculateTotalMonthlySalary_ReturnsZero_WhenNoEmployees()
        {
            // Arrange
            var payroll = new PayrollManager();

            // Act
            double total = payroll.CalculateTotalMonthlySalary();

            // Assert
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void AddEmployee_IgnoresNullValues()
        {
            // Arrange
            var payroll = new PayrollManager();

            // Act
            payroll.AddEmployee(null);

            // Assert
            Assert.AreEqual(0, payroll.GetAllEmployees().Count);
        }
    }
}
