using lab4.class_lab4;
using System;
using System.Windows;
using System.Windows.Controls;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Programmer_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return;
            Level.Visibility = Visibility.Visible;
            Junior.Visibility = Visibility.Visible;
            Senior.Visibility = Visibility.Visible;
            Bonus.Visibility = Visibility.Visible;
            Experience.Visibility = Visibility.Visible;
            ExperienceL.Visibility = Visibility.Visible;
            HourlyRateL.Visibility = Visibility.Visible;
            HourlyRate.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Visible;


            Specialization.Visibility = Visibility.Collapsed;
            Graphic.Visibility = Visibility.Collapsed;
            UX.Visibility = Visibility.Collapsed;
            _3D.Visibility = Visibility.Collapsed;
            ProjectCost.Visibility = Visibility.Collapsed;
        }

        private void Designer_Checked(object sender, RoutedEventArgs e)
        {
            Level.Visibility = Visibility.Collapsed;
            Junior.Visibility = Visibility.Collapsed;
            Senior.Visibility = Visibility.Collapsed;
            Bonus.Visibility = Visibility.Collapsed;

            Specialization.Visibility = Visibility.Visible;
            Graphic.Visibility = Visibility.Visible;
            UX.Visibility = Visibility.Visible;
            _3D.Visibility = Visibility.Visible;
            ProjectCost.Visibility = Visibility.Visible;
            Experience.Visibility = Visibility.Visible;
            ExperienceL.Visibility = Visibility.Visible;
            HourlyRateL.Visibility = Visibility.Visible;
            HourlyRate.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Visible;
        }

        private void Manager_Checked(object sender, RoutedEventArgs e)
        {
            Specialization.Visibility = Visibility.Collapsed;
            Graphic.Visibility = Visibility.Collapsed;
            UX.Visibility = Visibility.Collapsed;
            _3D.Visibility = Visibility.Collapsed;
            ProjectCost.Visibility = Visibility.Collapsed;
            Level.Visibility = Visibility.Collapsed;
            Junior.Visibility = Visibility.Collapsed;
            Senior.Visibility = Visibility.Collapsed;
            Bonus.Visibility = Visibility.Collapsed;
            Experience.Visibility = Visibility.Collapsed;
            ExperienceL.Visibility = Visibility.Collapsed;
            HourlyRateL.Visibility = Visibility.Collapsed;
            HourlyRate.Visibility = Visibility.Collapsed;
            Result.Visibility = Visibility.Collapsed;
        }

        PayrollManager payrollManager = new PayrollManager();

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int experience = int.Parse(Experience.Text);
                double rate = double.Parse(HourlyRate.Text);

                IWorkable worker = null;

                //  Якщо обрано програміста 
                if (Programmer.IsChecked == true)
                {
                    int level = Junior.IsChecked == true ? 0 : 1;
                    Programmer programmer = new Programmer(experience, rate, level);
                    worker = programmer;

                    MonthlySalary.Content = programmer.CalculateMonthlySalary().ToString();
                    Result.Content = programmer.Bonus.ToString();
                    Projects.Text = programmer.GetProjects();
                    Traininng.Content = programmer.ConductTraining();
                }

                //  Якщо обрано дизайнера 
                else if (Designer.IsChecked == true)
                {
                    int specialization = 0;
                    if (Graphic.IsChecked == true) specialization = 0;
                    else if (UX.IsChecked == true) specialization = 1;
                    else if (_3D.IsChecked == true) specialization = 2;

                    Designer designer = new Designer(experience, rate, specialization);
                    worker = designer;

                    MonthlySalary.Content = designer.CalculateMonthlySalary().ToString();
                    Result.Content = designer.CalculateProjectCost(40).ToString();
                    Projects.Text = designer.GetProjects();
                    Traininng.Content ="";
                }

                //  Якщо обрано менеджера 
                else if (Manager.IsChecked == true)
                {
                    ProjectManager manager = new ProjectManager();
                    worker = manager;

                    MonthlySalary.Content = manager.CalculateMonthlySalary().ToString();
                    Traininng.Content = manager.ConductTraining();
                    Projects.Text = manager.GetProjects();
                }

                //  Додаємо працівника 
                if (worker != null)
                {
                    payrollManager.AddEmployee(worker);
                    AllResult.Content = payrollManager.CalculateTotalMonthlySalary().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}
