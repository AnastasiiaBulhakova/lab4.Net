
using lab4.class_lab4;

namespace lab4_test
{
    [TestClass]
    public class ProjectManager_test
    {
        [TestMethod]
        public void CalculateMonthlySalary_Returns6000()
        {
            var manager = new ProjectManager();
            double expectedSalary = 6000;
            double actualSalary = manager.CalculateMonthlySalary();
            Assert.AreEqual(expectedSalary, actualSalary, 0.01);
        }

        [TestMethod]
        public void GetProjects_ReturnsCorrectString()
        {
            var manager = new ProjectManager();
            string expectedProjects = "Планування проектів, контроль задач";
            string actualProjects = manager.GetProjects();
            Assert.AreEqual(expectedProjects, actualProjects);
        }

        [TestMethod]
        public void ConductTraining_ReturnsCorrectString()
        {
            var manager = new ProjectManager();
            string expectedTraining = "Менеджер проводить тренінг: Управління проєктами";
            string actualTraining = manager.ConductTraining();
            Assert.AreEqual(expectedTraining, actualTraining);
        }
    }
}
