using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private Boolean isOperatorClicked;

        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LblResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
            LblOperacion.Text += button.Text;
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            LblOperacion.Text = "";
            isOperatorClicked = false;
            firstNumber = 0;
        }

        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                LblResult.Text = number;
                if (String.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
            }
        }

        private void BtnCommonOperation_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            Console.WriteLine(LblResult.Text);
            firstNumber = Convert.ToDecimal(LblResult.Text);
            Console.WriteLine(firstNumber);
            LblOperacion.Text += " " + operatorName + " ";
        }

        private async void BtnPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = LblResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    LblOperacion.Text = result;
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error de numero", ex.Message, "OK");
            }
        }

        private void BtnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                firstNumber = Convert.ToDecimal(firstNumber);
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.##");
                LblOperacion.Text += " = " + finalResult;
                LblResult.Text = finalResult;
                Console.WriteLine(finalResult);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
                Console.WriteLine(result);
            }
            else if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }
    }
}

