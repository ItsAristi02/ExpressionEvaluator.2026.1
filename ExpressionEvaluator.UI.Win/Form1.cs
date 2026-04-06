
using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.UI.Win
{
    public partial class Form1 : Form
    {
        private string expresion = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.BackColor = Color.Silver;
            textBox1.ForeColor = Color.White;
            textBox1.ReadOnly = true;
        }


        private void btn7_Click(object sender, EventArgs e)
        {
            expresion += "7";
            textBox1.Text = expresion;
        }

        private void btn8_Click(object sender, EventArgs e) 
        {
            expresion += "8";
            textBox1.Text = expresion;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            expresion += "9";
            textBox1.Text = expresion;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            expresion += "4";
            textBox1.Text = expresion;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            expresion += "5";
            textBox1.Text = expresion;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            expresion += "6";
            textBox1.Text = expresion;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            expresion += "1";
            textBox1.Text = expresion;
        }

        private void btn2_Click(object sender, EventArgs e) 
        {
            expresion += "2";
            textBox1.Text = expresion;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            expresion += "3";
            textBox1.Text = expresion;
        }

        private void btn0_Click(object sender, EventArgs e) 
        {
            expresion += "0";
            textBox1.Text = expresion;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            expresion += ".";
            textBox1.Text = expresion;
        }


        private void btnOpenParenthesis_Click(object sender, EventArgs e)
        {
            expresion += "(";
            textBox1.Text = expresion;
        }

        private void btnCloseParenthesis_Click(object sender, EventArgs e)
        {
            expresion += ")";
            textBox1.Text = expresion;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            expresion += "*";
            textBox1.Text = expresion;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            expresion += "/";
            textBox1.Text = expresion;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            expresion += "+";
            textBox1.Text = expresion;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            expresion += "-";
            textBox1.Text = expresion;
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            expresion += "^";
            textBox1.Text = expresion;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (expresion.Length > 0)
            {
                expresion = expresion.Substring(0, expresion.Length - 1);
                textBox1.Text = expresion;
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            expresion = "";
            textBox1.Text = "";
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            if (expresion == "")
                return;
            try
            {
                double resultado = Evaluator.Evaluate(expresion);
                string resultadoTexto = $"{resultado}";

                textBox1.Text = $"{expresion}={resultadoTexto}";
                expresion = resultadoTexto;
            }
            catch (Exception ex)
            {
                textBox1.Text = $"Error: {ex.Message}";
                expresion = "";
            }
        }
    }
}