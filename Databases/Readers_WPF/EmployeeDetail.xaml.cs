using System;
using System.Globalization;
using System.Windows;
using static Readers_WPF.MainWindow;

namespace Readers_WPF
{
    /// <summary>
    /// Interaction logic for EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        public Employee Model { get; set; }

        public EmployeeDetail(Employee employee = null)
        {
            InitializeComponent();

            Model = employee;
            if(Model != null) {
                NameTextBox.Text = Model.Name;
                TotalBonusTextBox.Text = Model.TotalBonus.ToString("0.##", CultureInfo.InvariantCulture);
                ProductivityTextBox.Text = Model.Productivity.ToString("0.##", CultureInfo.InvariantCulture);
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Model = ParseValues();
            if (Model == null) {
                MessageBox.Show("Alcuni valori non sono validi");
            }
            else {
                DialogResult = true;
            }
        }

        private Employee ParseValues()
        {
            Employee employee = new Employee();

            employee.Name = TextControl(NameTextBox.Text);

            if (double.TryParse(ProductivityTextBox.Text, out double _prod)){
                employee.Productivity = _prod;
            }
            else {
                return null;
            }

            if (int.TryParse(TotalBonusTextBox.Text, out int _bonus)) {
                employee.TotalBonus = _bonus;
            }
            else {
                return null;
            }

            return employee;
        }

        private string TextControl(string text)
        {
            string strClean = text;

            /*
             * Devo controllare che nel testo non ci sia del codice eseguibile
             */

            return strClean;
        }
    }
}
