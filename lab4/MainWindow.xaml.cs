using lab4.class_lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        PayrollManager payrollManager = new PayrollManager();
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int experience = int.Parse(Experience.Text);
                double rate = double.Parse(HourlyRate.Text);

                Employee emp = null;

                // --- Якщо обрано програміста ---
                if (Programmer.IsChecked == true)
                {
                    int level = Junior.IsChecked == true ? 0 : 1;

                    Programmer programmer = new Programmer(experience, rate, level);
                    emp = programmer;

                    MonthlySalary.Content = programmer.CalculateMonthlySalary().ToString();
                    Result.Content = programmer.Bonus.ToString();

                    Projects.Text = programmer.GetProjects();
                }

                // --- Якщо обрано дизайнера ---
                else if (Designer.IsChecked == true)
                {
                    int specialization = 0;
                    if (Graphic.IsChecked == true) specialization = 0;
                    else if (UX.IsChecked == true) specialization = 1;
                    else if (_3D.IsChecked == true) specialization = 2;

                    Designer designer = new Designer(experience, rate, specialization);
                    emp = designer;

                    MonthlySalary.Content = designer.CalculateMonthlySalary().ToString();
                    Result.Content = designer.CalculateProjectCost(40).ToString();
                    Projects.Text = designer.GetProjects();
                }

                // --- Додаємо працівника до списку ---
                if (emp != null)
                {
                    payrollManager.AddEmployee(emp);
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
