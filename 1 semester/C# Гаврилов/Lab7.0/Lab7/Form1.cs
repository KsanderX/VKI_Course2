using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CalculateResult()
        {
            try
            {
                string infixExpression = txtExpression.Text; //получаем  инфиксное выражение 
                string postfixExpression = ExpressionConverter.InfixToPostfix(infixExpression); //преобразовываем в постфиксную запись

                double result = StackCalculator.Instance.EvaluatePostfix(postfixExpression);

                //Отображение результата
                txtResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResult.Text = "";
            }
        }

        private void AddToExpression(string value)
        {
            if (string.IsNullOrWhiteSpace(txtExpression.Text) //если поле пустое
                || char.IsDigit(txtExpression.Text[txtExpression.Text.Length - 1])//если последний элемент
                || txtExpression.Text[txtExpression.Text.Length - 1] == ')')
            {
                txtExpression.Text += value;
            }
            else
            {
                txtExpression.Text += "" + value;
            }
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
           CalculateResult();
        }        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtExpression.Text = ""; //очистка поля ввода
            txtResult.Text = ""; //очистка результата
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            AddToExpression("1");
        }        
        private void btn2_Click_1(object sender, EventArgs e)
        {
            AddToExpression("2");
        }
        private void btn3_Click_1(object sender, EventArgs e)
        {
            AddToExpression("3");
        }
        private void btn4_Click_1(object sender, EventArgs e)
        {
            AddToExpression("4");
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            AddToExpression("5");
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            AddToExpression("6");
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            AddToExpression("7");
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            AddToExpression("8");
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            AddToExpression("9");
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            AddToExpression("0");
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            AddToExpression("+");
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            AddToExpression("-");
        }
        private void Multiply_Click(object sender, EventArgs e)
        {
            AddToExpression("*");
        }
        private void Divide_Click(object sender, EventArgs e)
        {
            AddToExpression("/");
        }
        private void OpenParen_Click(object sender, EventArgs e)
        {
            AddToExpression("(");
        }
        private void CloseParen_Click(object sender, EventArgs e)
        {
            AddToExpression(")");
        }
        private void btnFactorial_Click(object sender, EventArgs e)
        {
            AddToExpression("!");
        }
        private void txtExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateResult();
                e.SuppressKeyPress = true;
            }
        }       
    }
}
