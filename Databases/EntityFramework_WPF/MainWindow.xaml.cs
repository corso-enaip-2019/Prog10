using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace EntityFramework_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string CONNECTION_STRING = @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Miani;Trusted_Connection=True;";

        static MainDbContext dbContext = null;

        public MainWindow()
        {
            InitializeComponent();

            dbContext = new MainDbContext(CONNECTION_STRING);
        }

        private static void UpdateEmployee(Employee updatedEmpleyee)
        {
            //dbContext.Employees.(updatedEmpleyee);
            dbContext.SaveChanges();
        }

        private static void SaveNewEmployee(Employee newEmployee)
        {
            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();
        }

        private static void DeleteEmployee(Employee employeeToDelete)
        {
            dbContext.Employees.Remove(employeeToDelete);
            dbContext.SaveChanges();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = dbContext.Employees.ToList();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetail();
            if (detailWindow.ShowDialog() == true) {
                // Salvo il dato dalla maschera di dettaglio                                
                SaveNewEmployee(detailWindow.Model);
                LoadButton_Click(sender, e);
            }
            else {
                // Non modifico niente
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetail(GetSelectedEmployee());
            if (detailWindow.Model != null) {
                if (detailWindow.ShowDialog() == true) {
                    // Salvo il dato dalla maschera di dettaglio                                
                    UpdateEmployee(detailWindow.Model);
                    LoadButton_Click(sender, e);
                }
                else {
                    // Non modifico niente
                }
            }
            else {
                MessageBox.Show("You have to select an Employee first");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = GetSelectedEmployee();
            if (employee != null) {
                DeleteEmployee(employee);
                LoadButton_Click(sender, e);
            }
            else {
                MessageBox.Show("You have to select an Employee first");
            }
        }

        private Employee GetSelectedEmployee()
        {            
            return (Employee)MainGrid.SelectedItem;
        }
    }
}
