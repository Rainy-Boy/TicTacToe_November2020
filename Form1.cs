using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_November2020
{
    public partial class Form1 : Form
    {
        private string turn = "X";
        int turnCounter = 0;
        bool gameActive = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            var picture = (PictureBox)sender;

            picture.SizeMode = PictureBoxSizeMode.StretchImage;

            if((string)picture.Tag == "X" || (string)picture.Tag == "O")
            {
                return;
            }

            if (!gameActive)
            {
                return;
            }

            if (turn == "X")
            {
                picture.Image = Properties.Resources.X_tic;
                picture.Tag = turn;
                turnCounter += 1;
                CheckWinner();
                turn = "O";
                
            }
            else
            {
                picture.Image = Properties.Resources.O_tic;
                picture.Tag = turn;
                turnCounter += 1;
                CheckWinner();
                turn = "X";
            }
        }

        private void CheckWinner()
        {
            if(turnCounter < 3)
            {
                return;
            }
            //I also gave pictureBoxes 1, 5 and 9 each a unique "balance" tag in designer mode so everything works
            

            if(pictureBox1.Tag == pictureBox2.Tag && pictureBox2.Tag == pictureBox3.Tag)
            {
                GameOver();
            }
            else if(pictureBox4.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox6.Tag)
            {
                GameOver();
            }
            else if(pictureBox7.Tag == pictureBox8.Tag && pictureBox8.Tag == pictureBox9.Tag)
            {
                GameOver();
            }
            else if (pictureBox1.Tag == pictureBox4.Tag && pictureBox4.Tag == pictureBox7.Tag)
            {
                GameOver();
            }
            else if (pictureBox2.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox8.Tag)
            {
                GameOver();
            }
            else if (pictureBox3.Tag == pictureBox6.Tag && pictureBox6.Tag == pictureBox9.Tag)
            {
                GameOver();
            }
            else if (pictureBox1.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox9.Tag)
            {
                GameOver();
            }
            else if (pictureBox3.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox7.Tag)
            {
                GameOver();
            }
        }

        

        private void GameOver()
        {
            if (gameActive)
            {
                MessageBox.Show("The winner is " + turn);
                gameActive = false;
            }
            
        }
    }
}
