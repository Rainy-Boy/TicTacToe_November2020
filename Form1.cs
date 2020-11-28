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
    public partial class Game : Form
    {
        private string turn = "X";
        int turnCounter = 0;
        private bool gameActive = true;

        public Game()
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
          
            if(pictureBox1.Tag == pictureBox2.Tag && pictureBox2.Tag == pictureBox3.Tag && pictureBox1.Tag != null)
            {
                HighlightCells(pictureBox1, pictureBox2, pictureBox3);
                GameOver("win");
            }
            else if(pictureBox4.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox6.Tag && pictureBox5.Tag != null)
            {
                HighlightCells(pictureBox4, pictureBox5, pictureBox6);
                GameOver("win");
            }
            else if(pictureBox7.Tag == pictureBox8.Tag && pictureBox8.Tag == pictureBox9.Tag && pictureBox9.Tag != null)
            {
                HighlightCells(pictureBox7, pictureBox8, pictureBox9);
                GameOver("win");
            }
            else if (pictureBox1.Tag == pictureBox4.Tag && pictureBox4.Tag == pictureBox7.Tag && pictureBox4.Tag != null)
            {
                HighlightCells(pictureBox1, pictureBox4, pictureBox7);
                GameOver("win");
            }
            else if (pictureBox2.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox8.Tag && pictureBox5.Tag != null)
            {
                HighlightCells(pictureBox2, pictureBox5, pictureBox8);
                GameOver("win");
            }
            else if (pictureBox3.Tag == pictureBox6.Tag && pictureBox6.Tag == pictureBox9.Tag && pictureBox6.Tag != null)
            {
                HighlightCells(pictureBox3, pictureBox6, pictureBox9);
                GameOver("win");
            }
            else if (pictureBox1.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox9.Tag && pictureBox5.Tag != null)
            {
                HighlightCells(pictureBox1, pictureBox5, pictureBox9);
                GameOver("win");
            }
            else if (pictureBox3.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox7.Tag && pictureBox3.Tag != null)
            {
                HighlightCells(pictureBox3, pictureBox5, pictureBox7);
                GameOver("win");
            }
            else if (turnCounter > 8)
            {
                GameOver("tie");
            }
        }

        

        private void GameOver(string endType)
        {
            if (gameActive)
            {
                if(endType == "win")
                {
                    MessageBox.Show("The winner is " + turn);
                    buttonReset.Visible = true;
                    gameActive = false;
                }
               else if(endType == "tie")
                {
                    MessageBox.Show("Tie");
                    buttonReset.Visible = true;
                    gameActive = false;
                }
            }
            
        }

        private void HighlightCells(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            pb1.BackColor = pb2.BackColor = pb3.BackColor = Color.Blue;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            PictureBox picture;
            for(int counter = 1; counter < 10; counter++)
            {
                picture = (PictureBox)Grid.Controls["pictureBox" + counter];
                picture.Image = null;
                picture.Tag = null;
                picture.BackColor = Color.Transparent;
            }
            gameActive = true;
            buttonReset.Visible = false;
            turnCounter = 0;
        }
    }
}
