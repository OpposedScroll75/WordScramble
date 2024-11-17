using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordScramble
{
    public partial class Form1 : Form
    {
        string[] correctWordList = { "Plan Late Pale Tale Net Planet", "Star Team Mate Arts Ram Stream", "Rode Doer Bore Red Rob Border", "Birth Grit Big Hit Rig Bright", "Farm Fear Mare Arms Sea Frames"};
        string selectedWords = "";
        string awardedWords = "";
        string winningWord = "";
        string guess = "";
        int points;
        int time = 30;
        
        int wordChooser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            tmr_Game_Time.Enabled = true;
            wordChooser = ran.Next(0, 4);
            lbl_time.Text = time.ToString();
            selectedWords = correctWordList[wordChooser];
            switch (wordChooser)
            {
                case 0:
                    winningWord = "Planet";
                    break;
                case 1:
                    winningWord = "Stream";
                    break;
                case 2:
                    winningWord = "Border";
                    break;
                case 3:
                    winningWord = "Bright";
                    break;
                case 4:
                    winningWord = "Frames";
                    break;
            }
            char[] winW = winningWord.ToCharArray();
            Random r = new Random();

            for (int i = winW.Length - 1; i >= 0; i--)
            {
                int randNbr = r.Next(0, winW.Length);
                char temp = winW[i];
                winW[i] = winW[randNbr];
                winW[randNbr] = temp;
            }

            textBox2.Text = winW[0].ToString().ToLower();
            textBox3.Text = winW[1].ToString().ToLower();
            textBox4.Text = winW[2].ToString().ToLower();
            textBox5.Text = winW[3].ToString().ToLower();
            textBox6.Text = winW[4].ToString().ToLower();
            textBox7.Text = winW[5].ToString().ToLower();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                guess = textBox1.Text;

                if (selectedWords.Contains(guess) && guess.Length == 6)
                {
                    points += guess.Length;
                    awardedWords += guess;
                    lbl_GuessedWords.Text += $" {guess}";
                    label1.Text = $"Points: {points}";
                    time = 10000;
                    lbl_time.Visible = false;
                    MessageBox.Show("Congratulations, you won.");
                    textBox1.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    button4.Visible = true;
                    tmr_Game_Time.Enabled = false;
                }

                else if (selectedWords.Contains(guess))
                {

                    if (!awardedWords.Contains(guess))
                    {
                        points += guess.Length;
                        awardedWords += guess;
                        lbl_GuessedWords.Text += $" {guess}";
                        label1.Text = $"Points: {points}";
                    }
                    else if (awardedWords.Contains(guess))
                    {
                        MessageBox.Show("You've already written that word");
                        points += 0;
                    }
                }

                else if (selectedWords.Contains(guess) == false)
                {
                    MessageBox.Show("Invalid word");
                }
            }

            else if(textBox1.Text == "")
            {
                MessageBox.Show("Input field empty. Please write a word");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] winW = winningWord.ToCharArray();
            Random r = new Random();

            tmr_Game_Time.Enabled = true;
            int time = 60;

            for(int i = winW.Length - 1; i >= 0; i--)
            {
                int randNbr = r.Next(0, winW.Length);
                char temp = winW[i];
                winW[i] = winW[randNbr];
                winW[randNbr] = temp;
            }

            textBox2.Text = winW[0].ToString().ToLower();
            textBox3.Text = winW[1].ToString().ToLower();
            textBox4.Text = winW[2].ToString().ToLower();
            textBox5.Text = winW[3].ToString().ToLower();
            textBox6.Text = winW[4].ToString().ToLower();
            textBox7.Text = winW[5].ToString().ToLower();
            
        }

        public void ResetValues()
        {
            Random ran = new Random();
            wordChooser = ran.Next(0, 5);
            selectedWords = correctWordList[wordChooser];
            points = 0;
            time = 30;
            lbl_time.Visible = true;
            lbl_time.Text = time.ToString();
            tmr_Game_Time.Enabled = true;
            awardedWords = "";
            textBox1.Text = "";
            label1.Text = "Points: ";
            lbl_GuessedWords.Text = "";
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button4.Visible = false;

            switch (wordChooser)
            {
                case 0:
                    winningWord = "Planet";
                    break;
                case 1:
                    winningWord = "Stream";
                    break;
                case 2:
                    winningWord = "Border";
                    break;
                case 3:
                    winningWord = "Bright";
                    break;
                case 4:
                    winningWord = "Frames";
                    break;
            }

            char[] winW = winningWord.ToCharArray();
            Random r = new Random();

            for (int i = winW.Length - 1; i >= 0; i--)
            {
                int randNbr = r.Next(0, winW.Length);
                char temp = winW[i];
                winW[i] = winW[randNbr];
                winW[randNbr] = temp;
            }

            textBox2.Text = winW[0].ToString().ToLower();
            textBox3.Text = winW[1].ToString().ToLower();
            textBox4.Text = winW[2].ToString().ToLower();
            textBox5.Text = winW[3].ToString().ToLower();
            textBox6.Text = winW[4].ToString().ToLower();
            textBox7.Text = winW[5].ToString().ToLower();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void tmr_Game_Time_Tick(object sender, EventArgs e)
        {
            time--;
            lbl_time.Text = time.ToString();

            if(time == 0) {
                tmr_Game_Time.Enabled = false;
                MessageBox.Show("You ran out of time");
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button4.Visible = true;
            }
        }
    }
}
