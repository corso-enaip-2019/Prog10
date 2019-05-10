using System;
using System.Globalization;
using System.Windows;
using static EntityFramework_WPF.MainWindow;

namespace EntityFramework_WPF
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
            var employee = ParseValues();
            if (employee == null) {
                MessageBox.Show("Alcuni valori non sono validi");
            }
            else {
                DialogResult = true;
            }
        }

        private Employee ParseValues()
        {
            //Employee employee = new Employee();
            if (Model == null)
                Model = new Employee();

            Model.Name = TextControl(NameTextBox.Text.Trim());

            if (double.TryParse(ProductivityTextBox.Text.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double _prod)){
                Model.Productivity = _prod;
            }
            else {
                return null;
            }

            if (int.TryParse(TotalBonusTextBox.Text.Trim(), out int _bonus)) {
                Model.TotalBonus = _bonus;
            }
            else {
                return null;
            }

            return Model;
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
