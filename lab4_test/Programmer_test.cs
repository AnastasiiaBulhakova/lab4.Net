
using lab4.class_lab4;

namespace lab4_test
{
    [TestClass]
    public class Programmer_tests
    {
        [TestMethod]
        public void CalculateMonthlySalary_JuniorWithBonus_ReturnsBaseSalaryPlusBonus()
        {
           
            var programmer = new Programmer(2, 100, 0);
            double expectedSalary = (100 * 160) + (0.05 * 100 * 160); // 16000 + 800 = 16800

            
            double actualSalary = programmer.CalculateMonthlySalary();

            
            Assert.AreEqual(expectedSalary, actualSalary, 0.01);
        }

        [TestMethod]
        public void CalculateMonthlySalary_SeniorWithBonus_ReturnsBaseSalaryPlusBonus()
        {
            
            var programmer = new Programmer(5, 150, 1);
            double expectedSalary = (150 * 160) + (0.2 * 150 * 160); // 24000 + 4800 = 28800

            
            double actualSalary = programmer.CalculateMonthlySalary();

            
            Assert.AreEqual(expectedSalary, actualSalary, 0.01);
        }

        [TestMethod]
        public void CalculateBonus_Junior_ReturnsCorrectBonus()
        {
            
            var programmer = new Programmer(2, 100, 0);
            double expectedBonus = 0.05 * 100 * 160; // 800

            
            programmer.CalculateBonus();
            double actualBonus = programmer.Bonus; 
            
            Assert.AreEqual(expectedBonus, actualBonus, 0.01);
        }

        [TestMethod]
        public void CalculateBonus_Senior_ReturnsCorrectBonus()
        {
            
            var programmer = new Programmer(5, 150, 1);
            double expectedBonus = 0.2 * 150 * 160; // 4800

            
            programmer.CalculateBonus();
            double actualBonus = programmer.Bonus; 

            
            Assert.AreEqual(expectedBonus, actualBonus, 0.01);
        }

        [TestMethod]
        public void GetProjects_Junior_ReturnsCorrectProjects()
        {
            
            var programmer = new Programmer(2, 100, 0);
            string expectedProjects = "1. Невеликий сайт-візитка\n" +
                                     "2. Модуль тестування";

            
            string actualProjects = programmer.GetProjects();

            
            Assert.AreEqual(expectedProjects, actualProjects);
        }

        [TestMethod]
        public void GetProjects_Senior_ReturnsCorrectProjects()
        {
            
            var programmer = new Programmer(5, 150, 1);
            string expectedProjects = "1. Корпоративна CRM система\n" +
                                     "2. Серверна частина API\n" +
                                     "3. Мобільний застосунок";

            
            string actualProjects = programmer.GetProjects();

            
            Assert.AreEqual(expectedProjects, actualProjects);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_NegativeExperience_ThrowsException()
        {
            
            var programmer = new Programmer(-1, 100, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_NegativeHourlyRate_ThrowsException()
        {
            
            var programmer = new Programmer(2, -100, 0);
        }
    }
}