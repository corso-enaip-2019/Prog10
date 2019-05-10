using Readers_WPF.MainDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Readers_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string sqlConnectionString = @"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;";


        public MainWindow()
        {
            InitializeComponent();
        }

        private static List<Employee> ReadEmployeesFromDb()
        {
            var result = new List<Employee>();

            using (var conn = new SqlConnection(@"Server=TRISRV10\SQLEXPRESS;Database=CS2019_Kraus_1;Trusted_Connection=True;")) {
                conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Id, Name, Productivity, TotalBonus FROM Employees";

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            var e = new Employee {
                                Id = (int)reader[0],                // indexer per indice di colonna
                                Name = (string)reader["Name"],      // indexer per nome di colonna
                                Productivity = reader.GetDouble(2), // metodo tipizzato per indice di colonna
                                TotalBonus = reader.GetInt32(3),    // i metodi tipizzati sono diversi: per int, double, string, DateTime, ...
                            };
                            result.Add(e);
                        }
                    }
                }
            }

            return result;
        }

        private static void UpdateEmployees(List<Employee> employees)
        {
            using (var conn = new SqlConnection(sqlConnectionString)) {
                conn.Open();

                var updates = employees
                    .Select(e => CreateCmdForUpdate(e, conn));

                foreach (var cmd in updates)
                    cmd.ExecuteNonQuery();
            }
        }

        private static SqlCommand CreateCmdForUpdate(Employee e, SqlConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE Employees SET Name = '{e.Name}', Productivity = {e.Productivity}, TotalBonus = {e.TotalBonus} WHERE Id = {e.Id}";

            return cmd;
        }

        private static bool SaveNewEmployee(Employee newEmployee)
        {
            int result = 0;
            using (var conn = new SqlConnection(sqlConnectionString)) {
                conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandType = CommandType.Text;
                    
                    cmd.CommandText = "INSERT INTO Employees (Name, Productivity, TotalBonus) VALUES (@param1,@param2,@param3)";                    
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = newEmployee.Name;
                    cmd.Parameters.Add("@param2", SqlDbType.Float).Value = newEmployee.Productivity;
                    cmd.Parameters.Add("@param3", SqlDbType.Int).Value = newEmployee.TotalBonus;

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        private static bool DeleteEmployee(Employee employee)
        {
            int result = 0;
            using (var conn = new SqlConnection(sqlConnectionString)) {
                conn.Open();

                using (var cmd = conn.CreateCommand()) {
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $"DELETE FROM Employees WHERE Id = {employee.Id}";
                    
                    result = cmd.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Productivity { get; set; }
            public int TotalBonus { get; set; }
        }
        
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            //var employees = ReadEmployeesFromDb();
            //MainGrid.ItemsSource = employees;

            using (var ta = new EmployeesTableAdapter()) {
                MainGrid.ItemsSource = ta.GetData();
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new EmployeeDetail();
            if (detailWindow.ShowDialog() == true) {
                // Salvo il dato dalla maschera di dettaglio                                
                //SaveNewEmployee(detailWindow.Model);
                //LoadButton_Click(sender, e);
                using (var ta = new EmployeesTableAdapter()) {
                    ta.Insert(detailWindow.Model.Name, detailWindow.Model.Productivity, detailWindow.Model.TotalBonus);
                }
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
                    UpdateEmployees(new List<Employee>() { detailWindow.Model });
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
