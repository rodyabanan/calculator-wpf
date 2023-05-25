using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            lblResult.Content = "0";

        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = 0;
            if(lblResult.Content == "Ошибка")
            {
                lblResult.Content= "0";
            }
            
            
            if (sender == btnZero )
                selectedValue = 0;
            if (sender == btnOne)
                selectedValue = 1;
            if (sender == btnTwo)
                selectedValue = 2;
            if (sender == btnThree)
                selectedValue = 3;
            if (sender == btnFour)
                selectedValue = 4;
            if (sender == btnFive)
                selectedValue = 5;
            if (sender == btnSix)
                selectedValue = 6;
            if (sender == btnSeven)
                selectedValue = 7;
            if (sender == btnEight)
                selectedValue = 8;
            if (sender == btnNine)
                selectedValue = 9;



            lblResult.Content = lblResult.Content.ToString() == lastNumber.ToString() ? lblResult.Content = $"{selectedValue}" : lblResult.Content = $"{lblResult.Content}{selectedValue}";
        }

        private void btnNegative_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = lastNumber * (-1) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }

        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = Math.Round(Math.Sqrt(lastNumber),7) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }
        private void btnCos_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = Math.Round(Math.Cos(lastNumber),7) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }
        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = Math.Round(Math.Sin(lastNumber), 7) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }
        private void btnTg_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = Math.Round(Math.Tan(lastNumber), 7) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }
        private void btnCtg_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = double.TryParse(lblResult.Content.ToString(), out lastNumber) ? lastNumber = Math.Round(1/Math.Tan(lastNumber),7) : lblResult.Content;
            historyListBox.Items.Add(lblResult.Content);
        }


        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = Math.Round(SimpleMath.Add(lastNumber, newNumber), 7);
                        break;
                    case SelectedOperator.Sustraction:
                        result = Math.Round(SimpleMath.Minus(lastNumber, newNumber), 7);
                        break;
                    case SelectedOperator.Multiplicatiom:
                        result = Math.Round(SimpleMath.Multiple(lastNumber, newNumber),7);
                        break;
                    case SelectedOperator.Division:
                        if (newNumber == 0)
                        {
                            error = "Ошибка";
                            lblResult.Content = error.ToString();
                            
                        }
                        else result = Math.Round(SimpleMath.Divide(lastNumber, newNumber),7);
                        break;
                    case SelectedOperator.Degree:
                        result = Math.Round(SimpleMath.Degree(lastNumber, newNumber),7);
                        break;
                }
                if (error == "Ошибка")
                {
                    lblResult.Content = error;
                }else lblResult.Content = result.ToString();
                if (selectedOperator == SelectedOperator.Addition)
                {
                    historyListBox.Items.Add(lastNumber + "+" + newNumber + "=" + lblResult.Content);
                }
                if (selectedOperator == SelectedOperator.Sustraction)
                {
                    historyListBox.Items.Add(lastNumber + "-" + newNumber + "=" + lblResult.Content);
                }
                if (selectedOperator == SelectedOperator.Multiplicatiom)
                {
                    historyListBox.Items.Add(lastNumber + "*" + newNumber + "=" + lblResult.Content);
                }
                if (selectedOperator == SelectedOperator.Division)
                {
                    historyListBox.Items.Add(lastNumber + "/" + newNumber + "=" + lblResult.Content);
                }
                if (selectedOperator == SelectedOperator.Degree)
                {
                    historyListBox.Items.Add(lastNumber + "^" + newNumber + "=" + lblResult.Content);
                }
                
                lastNumber = 0;
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if(!lblResult.Content.ToString().Contains(","))
                lblResult.Content = $"{lblResult.Content},";
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = lastNumber;
            }

            if (sender == btnMultiple)
                selectedOperator = SelectedOperator.Multiplicatiom;
            if (sender == btnDivide)
                selectedOperator = SelectedOperator.Division;
            if (sender == btnPlus)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btnMinus)
                selectedOperator = SelectedOperator.Sustraction;
            if (sender == btnDegree)
                selectedOperator = SelectedOperator.Degree;
        }

        private void btnAc_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
            lastNumber= 0;

        }

    }
    // Перечисление действий
    public enum SelectedOperator
    {
        Addition,
        Sustraction,
        Multiplicatiom,
        Division,
        Degree
    }
    //класс математических расчетов
    public class SimpleMath
    {
        public static double Add(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }

        public static double Minus(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
        public static double Multiple(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }
        public static double Divide(double numberOne, double numberTwo)
        {
            return numberOne / numberTwo;
        }
        public static double Degree(double numberOne, double numberTwo)
        {
            return Math.Pow(numberOne, numberTwo);
        }
    }
}
