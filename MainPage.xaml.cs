using System.Globalization;

namespace MauiCalculator
{
    public partial class MainPage : ContentPage
    {
        private double firstNumber;
        private double secondNumber;
        private string operatorSymbol;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button? button = sender as Button;
            string? number = button?.Text;
            string currentResult = ResultLabel.Text;

            if (currentResult == "0")
            {
                ResultLabel.Text = number;
            }
            else
            {
                ResultLabel.Text += number;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operatorSymbol = button.Text;
            string currentResult = ResultLabel.Text;

            if (currentResult != "0")
            {
                firstNumber = double.Parse(currentResult, culture);
                ResultLabel.Text = "0";
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            string currentResult = ResultLabel.Text;
            secondNumber = double.Parse(currentResult, culture);

            double result = PerformOperation(firstNumber, secondNumber, operatorSymbol);
            ResultLabel.Text = result.ToString(culture);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            operatorSymbol = "";
            ResultLabel.Text = "0";
        }

        private double PerformOperation(double firstNumber, double secondNumber, string operatorSymbol)
        {
            double result = 0;

            switch (operatorSymbol)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }

            return result;
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            string currentResult = ResultLabel.Text;
            string dot = culture.NumberFormat.NumberDecimalSeparator;
            if (!currentResult.Contains(dot))
            {
                ResultLabel.Text += dot;
            }
        }
    }

}
