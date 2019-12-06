using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MahApps.Metro.Controls;

namespace JobCostingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            List<JobItem> items = new List<JobItem>
            {
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39402, DetailNumber = 99, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39403, DetailNumber = 89, OperationCode = 9994, RunTime = 1.5 },
                new JobItem() { JobNumber = 39404, DetailNumber = 79, OperationCode = 9994, RunTime = 1.5 }
            };

            List<EmployeeName> employees = new List<EmployeeName>
            {
                new EmployeeName() { Employee = "Andrew Ashland" },
                new EmployeeName() { Employee = "Mark Ruffo Alan Anthony" },
                new EmployeeName() { Employee = "Rocco Trigianno" },
                new EmployeeName() { Employee = "Marc Del Torro" },
                new EmployeeName() { Employee = "Daniel Dan Danny" }
            };

            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "Employee";
            EmployeeComboBox.SelectedValuePath = "Employee";
            EmployeeComboBox.SelectedValue = "Employee";

            icTodoList.ItemsSource = items;
        }

        private void Enter_Btn_Click(object sender, RoutedEventArgs e)
        {
            var validated = ValidateInputs();

            if (validated == false)
            {
                return;
            }

            int jobNo = int.Parse(JobNumber.Text);            
            int operationNo = int.Parse(Operation.Text);
            double runTime = double.Parse(RunTime.Text);
            double totalTime = double.Parse(TotalTime.Text);

            List<int> detailNumbers = new List<int>();

            ParseDetailNumbers(detailNumbers);

            
        }

        private bool ValidateInputs()
        {

            if (JobNumber.Text.Length == 0)
            {
                MessageBox.Show("Please input a Job Number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                return false;
            }

            return true;
        }

        //will parse the detail number input as there can be multiple detail numbers per job no
        private void ParseDetailNumbers(List<int> detailNumbers)
        {
            Regex regex = new Regex("^[0-9]+$");

            StringBuilder sb = new StringBuilder();
                       
            for(int i = 0; i < DetailNumber.Text.Length; i++)
            {         
                //if current character is a number then it will be added to the stringbuilder sb
                if (regex.IsMatch(char.ToString(DetailNumber.Text[i])))
                {
                    sb.Append(DetailNumber.Text[i]);
                }                
                else if (sb.Length > 0)
                {

                    detailNumbers.Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
                //checks if in last position in the string and if so, adds whats in the stringbuilder, sb, to the detailNumbers List.
                if (i + 1 == DetailNumber.Text.Length && sb.Length > 0)
                {
                    detailNumbers.Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
            }
        }
    }

    public class JobItem
    {        
        public int JobNumber { get; set; }
        public int DetailNumber { get; set; }
        public int OperationCode { get; set; }
        public double RunTime { get; set; }
    }

    public class JobDetails
    {
        public int MyProperty { get; set; }
    }
    
    public class EmployeeName
    {
        public string Employee { get; set; }
       
    }

}
