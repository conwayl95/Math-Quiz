using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conwaylMathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addEnd1;
        int addEnd2;

        int minuEnd;
        int subtrahEnd;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public void StartTheQuiz()
        {
            addEnd1 = randomizer.Next(51);
            addEnd2 = randomizer.Next(51);

            plusLeftLabel.Text = addEnd1.ToString();
            plusRightLabel.Text = addEnd2.ToString();

            sum.Value = 0;

            minuEnd = randomizer.Next(1, 101);
            subtrahEnd = randomizer.Next(1, minuEnd);
            minusLeftLabel.Text = minuEnd.ToString();
            minusRightLabel.Text = subtrahEnd.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private bool CheckTheAnswer()
        {
            if ((addEnd1 + addEnd2 == sum.Value)
                && (minuEnd - subtrahEnd == difference.Value)
               && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

     
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
           else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }     
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addEnd1 + addEnd2;
                difference.Value = minuEnd - subtrahEnd;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Transparent;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox !=null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (sum.Value == addEnd1 + addEnd2)
            {
                SystemSounds.Beep.Play();
                
            }
        }


        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (difference.Value == minuEnd - subtrahEnd)
            {
                SystemSounds.Exclamation.Play();

            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (product.Value == multiplicand * multiplier)
            {
                SystemSounds.Exclamation.Play();

            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (quotient.Value == dividend / divisor)
            {
                SystemSounds.Exclamation.Play();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
