using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null; // clicking first time on label
        Label secondClicked = null;
        Random random = new Random();  // Generate random object to choose random icon
        List<string> icons = new List<string>() // to store a random object, we need list
        {
            "@","@","N","N",",",",","k","k",
            "b","b","v","v","w","w","z","z"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconToSquares();
        }

        private void AssignIconToSquares() // Creating a method, it will iterate label control on the table layout panel and execute the same statement or code for each of them
        {
            foreach (Control control in tableLayoutPanel1.Controls) // variable "control" that store each control one at a time
            {
                Label iconLabel = control as Label; //convert the control variable to a Label name iconLabel
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);  // randomNumber ->one of the item in the icon list, Next ->Returns the random number, count ->the range to choose the random number from
                    iconLabel.Text = icons[randomNumber]; // assign  the text property to random design 

                    iconLabel.ForeColor = iconLabel.BackColor; // hide the icon
                    icons.RemoveAt(randomNumber); // to remove the list of icon from the form

                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label; // class label, local variable -> clickedLabel, 
            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

               // clickedLabel.ForeColor = Color.Black;
               if(firstClicked == null) // if the clicked is null then, this click icon is the first icon
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if(iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("You matched all the icons!", "Congratulations and well done! ");
            Close();
        }

    }

}