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

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Input.Text += button.Content;
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Input.Text = "";
        }

        private void DelButton(object sender, RoutedEventArgs e)
        {
            if (Input.Text.Length != 0)
            {
                Input.Text = Input.Text.Substring(0, Input.Text.Length - 1);
            }
        }

        private void DotClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (string.IsNullOrEmpty(Input.Text))
            {
                Input.Text = "0" + btn.Content;
            }
            
            else if (!string.IsNullOrEmpty(Input.Text) && !Input.Text.Contains("."))
            {
                Input.Text = Input.Text + (string)btn.Content;
            }

            if (Input.Text.Contains("^") || Input.Text.Contains("+") || Input.Text.Contains("-") || Input.Text.Contains("*") || Input.Text.Contains("/"))
            {
                string[] Characters  = Input.Text.Split('*', '/', '-', '+', '^');
                if (!Characters[1].Contains("."))
                {
                    Input.Text += ".";
                }
            }
            
        }

        private void SqrtButton(object sender, RoutedEventArgs e)
        {
            try
            {
                double res = Math.Sqrt(double.Parse(Input.Text));

                Input.Text = res.ToString();
            }
            catch 
            {

                Input.Text = "Error";
            }
        }

        private string oper;

        private void OperationClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            string? operation = btn.Content.ToString();

            if (!string.IsNullOrEmpty(Input.Text) && Input.Text != "Error")
            {

                if (operation == "sqr" && IsFalse("^"))
                {
                    
                        Input.Text += " ^ ";
                        oper = "^";
                    
                }
                else if (operation == "+" && IsFalse("+"))
                {

                        Input.Text += " + ";
                        oper = "+";
                    
                }
                else if (operation == "-" && IsFalse("-"))
                {
                    
                        Input.Text += " - ";
                        oper = "-";
                    
                }
                else if (operation == "X" && IsFalse("*"))
                {
                    Input.Text += " * ";
                    oper = "*";
                }
                else if (operation == "/" && IsFalse("/"))
                {
                    Input.Text += " / ";
                    oper = "/";
                }
                


            }
        }


        private bool IsFalse(string Character)
        {
            if (!(Input.Text.Contains("^") || Input.Text.Contains("+") || Input.Text.Contains("-") || Input.Text.Contains("/") || Input.Text.Contains("*")))
            {
                return true;
            }
            return false;
                
        }




        private double num = 0;
        private void EqualClick(object sender, RoutedEventArgs e)
        {

            string [] Characts = Input.Text.Split('*', '/', '-', '+', '^');

            if (oper == "^")
            {
                num =  Math.Pow(double.Parse(Characts[0]), double.Parse(Characts[1]));
                
            }
            else if (oper == "+")
            {
                num = double.Parse(Characts[0]) + double.Parse(Characts[1]);
            }
            else if (oper == "-")
            {
                num = double.Parse(Characts[0]) - double.Parse(Characts[1]);
            }
            else if (oper == "/")
            {
                num = double.Parse(Characts[0]) / double.Parse(Characts[1]);
            }
            else if (oper == "*")
            {
                num = double.Parse(Characts[0]) * double.Parse(Characts[1]);
            }


            Input.Text = num.ToString();

        }
    }
}
