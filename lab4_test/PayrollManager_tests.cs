using lab4.class_lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var manager = new ProjectManager();

            // Act
            payroll.AddEmployee(programmer);
            payroll.AddEmployee(designer);
            payroll.AddEmployee(manager);

            List<IWorkable> employees = payroll.GetAllEmployees();

            // Assert
            Assert.AreEqual(3, employees.Count, "Неправильна кількість співробітників у списку.");
            Assert.IsTrue(employees.Contains(programmer), "Програміста не додано.");
            Assert.IsTrue(employees.Contains(designer), "Дизайнера не додано.");
            Assert.IsTrue(employees.Contains(manager), "Менеджера не додано.");
        }

        [TestMethod]
        public void CalculateTotalMonthlySalary_ReturnsCorrectSum()
        {
            // Arrange
            var payroll = new PayrollManager();
            var programmerJunior = new Programmer(2, 100, 0); // Junior
            var programmerSenior = new Programmer(5, 200, 1); // Senior
            var designerUx = new Designer(3, 150, 1);         // UX/UI
            var manager = new ProjectManager();               // Фіксована зарплата 6000

            payroll.AddEmployee(programmerJunior);
            payroll.AddEmployee(programmerSenior);
            payroll.AddEmployee(designerUx);
            payroll.AddEmployee(manager);

            // Обчислення очікуваної зарплати
            double juniorSalary = programmerJunior.CalculateMonthlySalary(); // 100*160 + 5%
            double seniorSalary = programmerSenior.CalculateMonthlySalary(); // 200*160 + 20%
            double designerSalary = designerUx.CalculateMonthlySalary();     // 150*160
            double managerSalary = manager.CalculateMonthlySalary();         // 6000

            double expectedTotal = juniorSalary + seniorSalary + designerSalary + managerSalary;

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

        [TestMethod]
        public void ProjectManager_GetProjectsAndSalary_ReturnsCorrectValues()
        {
            // Arrange
            var manager = new ProjectManager();

            string expectedProjects = "Планування проектів, контроль задач";
            double expectedSalary = 6000;

            // Act
            string actualProjects = manager.GetProjects();
            double actualSalary = manager.CalculateMonthlySalary();

            // Assert
            Assert.AreEqual(expectedProjects, actualProjects);
            Assert.AreEqual(expectedSalary, actualSalary, 0.01);
        }

        [TestMethod]
        public void ProjectManager_ConductTraining_ReturnsExpectedString()
        {
            // Arrange
            var manager = new ProjectManager();
            string expected = "Менеджер проводить тренінг: Управління проєктами";

            // Act
            string actual = manager.ConductTraining();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
