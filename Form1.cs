using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cal_app
{//단순한 연산은 가능하나 복잡한 연산은 불가능함.
    public partial class Form1 : Form
    {
        private bool opFlag = false; //연산자 사용 확인
        private double savedValue; //txtResult 값 저장
        private char op; //연산자
        private bool reFlag = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnNumber_Click(object sender, EventArgs e)
        { //숫자 버튼 클릭
            Button btn = sender as Button;
            if(reFlag == true)
            {
                txtExp.Text = "";
                txtResult.Text = btn.Text;
                reFlag = false;
            }
            else if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = btn.Text;
                opFlag = false;
            }
            else
                txtResult.Text = txtResult.Text + btn.Text;
        }
        private void btnDot_click(object sender, EventArgs e)
        { //소수점 중복 예외 처리
            if (txtResult.Text.Contains("."))
                return;
            else
                txtResult.Text += ".";
        }
        private void btnPulsMinus_click(object sender, EventArgs e)
        { //부호 변경 (곱셈을 이용 음수*음수=양수)
            double s = Double.Parse(txtResult.Text);
            txtResult.Text = (-s).ToString();
        }
        private void btnPlus_click(object sender, EventArgs e)
        { //+ 연산자
            if (savedValue == 0) savedValue = Double.Parse(txtResult.Text);
            else savedValue += Double.Parse(txtResult.Text);
            txtExp.Text += txtResult.Text + " + ";
            txtResult.Text = savedValue.ToString();
            op = '+';
            opFlag = true;
        }
        private void btnMinus_click(object sender, EventArgs e)
        { //- 연산자 
            if (savedValue == 0) savedValue = Double.Parse(txtResult.Text);
            else savedValue -= Double.Parse(txtResult.Text);
            txtExp.Text += txtResult.Text + " - ";
            txtResult.Text = savedValue.ToString();
            op = '-';
            opFlag = true;
        }
        private void btnMul_click(object sender, EventArgs e)
        { //× 연산자
            if (savedValue == 0) savedValue = Double.Parse(txtResult.Text);
            else savedValue *= Double.Parse(txtResult.Text);
            txtExp.Text += txtResult.Text + " × ";
            txtResult.Text = savedValue.ToString();
            op = '*';
            opFlag = true;
        }
        private void btnDiv_click(object sender, EventArgs e)
        { //÷ 연산자
            if (savedValue == 0) savedValue = Double.Parse(txtResult.Text);
            else savedValue = savedValue / Double.Parse(txtResult.Text);
            txtExp.Text += txtResult.Text + " ÷ ";
            txtResult.Text = savedValue.ToString();
            op = '/';
            opFlag = true;
        }
        private void btnResult_click(object sender, EventArgs e)
        { //= Result
            Double v = Double.Parse(txtResult.Text);
            switch (op)
            {
                case '+':
                    txtExp.Text += txtResult.Text;
                    txtResult.Text = (savedValue + v).ToString();
                    break;
                case '-':
                    txtExp.Text += txtResult.Text;
                    txtResult.Text = (savedValue - v).ToString();
                    break;
                case '*':
                    txtExp.Text += txtResult.Text;
                    txtResult.Text = (savedValue * v).ToString();
                    break;
                case '/':
                    txtExp.Text += txtResult.Text;
                    txtResult.Text = (savedValue / v).ToString();
                    break;
            }
            savedValue = 0;
            op = '\0';
            opFlag = false;
            reFlag = true;
        }
        private void btnErase_click(object sender, EventArgs e)
        { //지우기 버튼
            txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
            if (txtResult.Text.Length == 0)
                txtResult.Text = "0";
        }
        private void btnAllClear_click(object sender, EventArgs e)
        { //초기화
            txtResult.Text = "0";
            txtExp.Text = "";
            savedValue = 0;
            op = '\0';
            opFlag = false;
        }
        private void btnClearEntry_click(object sender, EventArgs e)
        { //txtResult값만 지우기
            txtResult.Text = "0";
        }
    }
}
