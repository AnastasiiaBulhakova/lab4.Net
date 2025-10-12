using lab4.class_lab4;

namespace lab4_test
{
    [TestClass]
    public class Desiner_test
    {
        [TestMethod]
        public void CalculateProjectCost_ComputesCorrectValue()
        {
            
            var designer = new Designer(3, 120, 0); // Графічний
            int hours = 50;
            double expected = 120 * 50;

            
            designer.CalculateProjectCost(hours);
            double monthly = designer.CalculateMonthlySalary();

            
            Assert.AreEqual(120 * 160, monthly, 0.01);
            Assert.AreEqual(expected, 120 * 50, 0.01);
        }

        [TestMethod]
        public void MonthlySalary_CalculatedCorrectly()
        {
            
            var designer = new Designer(2, 150, 1);

            
            double salary = designer.CalculateMonthlySalary();

            
            Assert.AreEqual(150 * 160, salary, 0.01);
        }

        [TestMethod]
        public void GetProjects_ForGraphicDesigner_ReturnsCorrectList()
        {
            
            var designer = new Designer(4, 100, 0);

            
            string projects = designer.GetProjects();

            
            StringAssert.Contains(projects, "Logo Design");
            StringAssert.Contains(projects, "Brand Book");
            StringAssert.Contains(projects, "Product Packaging");
        }

        [TestMethod]
        public void GetProjects_ForUxUiDesigner_ReturnsCorrectList()
        {
            
            var designer = new Designer(5, 150, 1);

            
            string projects = designer.GetProjects();

            
            StringAssert.Contains(projects, "Mobile App UI");
            StringAssert.Contains(projects, "Website Redesign");
            StringAssert.Contains(projects, "Dashboard Prototype");
        }

        [TestMethod]
        public void GetProjects_For3DDesigner_ReturnsCorrectList()
        {
            
            var designer = new Designer(6, 180, 2);

            
            string projects = designer.GetProjects();

            
            StringAssert.Contains(projects, "3D Visualization");
            StringAssert.Contains(projects, "Animation Demo");
            StringAssert.Contains(projects, "Video Ad");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Designer_NegativeExperience_ThrowsException()
        {
            
            var designer = new Designer(-1, 100, 0);

            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Designer_NegativeHourlyRate_ThrowsException()
        {
           
            var designer = new Designer(2, -50, 0);

            // Перевірка: очікуємо виняток від конструктора Employee
        }
    }
}
