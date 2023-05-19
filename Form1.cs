using System;
using System.Drawing;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        private int playerQueue = 0;
        bool isGameEnded;
        bool isPvpGame = true;
        public Form1()
        {
            InitializeComponent();
        }
        
        private string xOrO()
        {
            string symbol;
            if((playerQueue%2)==0)
            {
                symbol= "X";
            }
            else
            {
                symbol= "O";
            }
            playerQueue++;
            return symbol;
        }

        private void winAlert(Button buttontest)
        {
            string winner;
            if (buttontest.Text.Equals("X"))
                winner = " pierwszy ";
            else
                winner = " drugi ";

            if (MessageBox.Show("Chcesz zagac ponownie?", "Gracz" + winner + "wygral", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clean();
            }
            else
            {
                Application.Exit();
            }
        }
        private bool isButtonBussy(Button buttontest)
        {
            if (buttontest.Text.Equals("X") || buttontest.Text.Equals("O"))
                return true;
            else
                return false;
        }

        private void winEqualizer(Button button1check, Button button2check, Button button3check)
        {
            if (isButtonBussy(button1check)==true&&isButtonBussy(button2check)==true&&isButtonBussy(button3check)==true)
            {
                if (button1check.Text.Equals(button2check.Text) && button2check.Text.Equals(button3check.Text))
                {
                    button1check.BackColor = Color.Green;
                    button2check.BackColor = Color.Green;
                    button3check.BackColor = Color.Green;
                    winAlert(button1check);
                    isGameEnded = true;
                }
                else
                    isGameEnded = false;
            }
            

        }
        private bool autoComplete(Button buttonTest)
        {
            if (buttonTest.Enabled == true)
            {
                buttonTest.Text = "O";
                playerQueue++;
                buttonTest.Enabled = false;
                winCheck();
                return true;
            }
            else
                return false;

        }
        private bool isGameWinable(Button button1test,Button button2test, Button button3test)
        {
            if (button1test.Enabled == false && button2test.Enabled == false&&button3test.Enabled==true)
            {
                if (button1test.Text.Equals(button2test.Text))
                    return true;
                else
                    return false;
            }
            else
                return false;

        }
        private void drawButton()
        {
            if(isPvpGame==false)
            {
                if (isGameWinable(button1, button2, button3))
                    autoComplete(button3);
                else if (isGameWinable(button2, button3, button1))
                    autoComplete(button1);
                else if (isGameWinable(button4, button5, button6))
                    autoComplete(button6);
                else if (isGameWinable(button5, button6, button4))
                    autoComplete(button4);
                else if (isGameWinable(button7, button8, button9))
                    autoComplete(button9);
                else if (isGameWinable(button8, button9, button7))
                    autoComplete(button7);
                else if (isGameWinable(button1, button4, button7))
                    autoComplete(button7);
                else if (isGameWinable(button4, button7, button1))
                    autoComplete(button1);
                else if (isGameWinable(button2, button5, button8))
                    autoComplete(button8);
                else if (isGameWinable(button5, button8, button2))
                    autoComplete(button2);
                else if (isGameWinable(button3, button6, button9))
                    autoComplete(button9);
                else if (isGameWinable(button6, button9, button3))
                    autoComplete(button3);
                else if (isGameWinable(button1, button5, button9))
                    autoComplete(button9);
                else if (isGameWinable(button9, button5, button1))
                    autoComplete(button1);
                else if (isGameWinable(button3, button5, button7))
                    autoComplete(button7);
                else if (isGameWinable(button7, button5, button3))
                    autoComplete(button3);
                //
                else if (isGameWinable(button1, button3, button2))
                    autoComplete(button2);
                else if (isGameWinable(button4, button6, button5))
                    autoComplete(button5);
                else if (isGameWinable(button7, button9, button8))
                    autoComplete(button8);
                //
                else if (isGameWinable(button1, button7, button4))
                    autoComplete(button4);
                else if (isGameWinable(button2, button8, button5))
                    autoComplete(button5);
                else if (isGameWinable(button3, button9, button6))
                    autoComplete(button6);
                //
                else if (isGameWinable(button1, button9, button5))
                    autoComplete(button5);
                else if (isGameWinable(button3, button7, button5))
                    autoComplete(button5);
                else if (!isButtonBussy(button5))
                    autoComplete(button5);
                else if (!isButtonBussy(button1))
                    autoComplete(button1);
                else if (!isButtonBussy(button3))
                    autoComplete(button3);
                else if (!isButtonBussy(button7))
                    autoComplete(button7);
                else if (!isButtonBussy(button9))
                    autoComplete(button9);
                else if (!isButtonBussy(button2))
                    autoComplete(button2);
                else if (!isButtonBussy(button4))
                    autoComplete(button4);
                else if (!isButtonBussy(button6))
                    autoComplete(button6);
                else if (!isButtonBussy(button8))
                    autoComplete(button8);

            }
        }
        private void winCheck()
        {
           if(playerQueue>4)
            {
                winEqualizer(button1, button2, button3);
                winEqualizer(button4, button5, button6);
                winEqualizer(button7, button8, button9);
                winEqualizer(button1, button4, button7);
                winEqualizer(button2, button5, button8);
                winEqualizer(button3, button6, button9);
                winEqualizer(button1, button5, button9);
                winEqualizer(button3, button5, button7);
           }
           if((isGameEnded==false)&&(playerQueue==9))
            {
                if (MessageBox.Show("Chcesz zagrac ponownie?", "Gra zakonczona remisem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clean();
                }
                else
                {
                    Application.Exit();
                }

            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = xOrO();
            button1.Enabled = false;
            drawButton();
            winCheck();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = xOrO();
            button2.Enabled = false;
            drawButton();
            winCheck();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = xOrO();
            button3.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = xOrO();
            button4.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Text = xOrO();
            button5.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Text = xOrO();
            button6.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = xOrO();
            button7.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Text = xOrO();
            button8.Enabled = false;
            drawButton();
            winCheck();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Text = xOrO();
            button9.Enabled = false;
            drawButton();
            winCheck();

        }

        private void clean()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            button6.BackColor = Color.Transparent;
            button7.BackColor = Color.Transparent;
            button8.BackColor = Color.Transparent;
            button9.BackColor = Color.Transparent;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            playerQueue = 0;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            isPvpGame=!isPvpGame;
            if(isPvpGame==true)
            {
                button10.Text = "PVP Game";
            }
            else
            {
                button10.Text = "PVC Game";
            }
            clean();
        }
    }
}
