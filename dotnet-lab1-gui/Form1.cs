using dotnet_lab1;
using System.Runtime.CompilerServices;

namespace dotnet_lab1_gui
{
    public partial class Form1 : Form
    {
        private int formsSeed;
        private int formsNumItems;
        private int formsCapacity;
        private bool errorSeed = false;
        private bool errorNumItems = false;
        private bool errorCapacity = false;

        private Problem problem;
        private Result rv;

        public Form1()
        {
            InitializeComponent();
            this.Text = "problem plecakowy";
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            //textBox5.Text = rv.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int formsSeed))
            {
                if (formsSeed < 0)
                {
                    textBox1.BackColor = Color.Red; // ujemny seed -> error
                    errorSeed = true;
                }
                else
                {
                    textBox1.BackColor = SystemColors.Window; // valid input
                    errorSeed = false;
                    this.formsSeed = formsSeed;

                }
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int formsCapacity))
            {
                if (formsCapacity < 0)
                {
                    textBox2.BackColor = Color.Red; // ujemne capacity -> error
                    errorCapacity = true;
                }
                else
                {
                    textBox2.BackColor = SystemColors.Window; // valid input
                    errorCapacity = false;
                    this.formsCapacity = formsCapacity;

                }
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int formsNumItems))
            {
                if (formsNumItems < 0)
                {
                    textBox3.BackColor = Color.Red; // ujemna wartosc -> error
                    errorNumItems = true;
                }
                else
                {
                    textBox3.BackColor = SystemColors.Window; // valid input
                    errorNumItems = false;
                    this.formsNumItems = formsNumItems;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (errorSeed || errorNumItems || errorCapacity)
            {
                textBox5.Text = "invalid input";
                return;
            }
            problem = new Problem(formsSeed, formsNumItems);
            rv = problem.Solve(formsCapacity);
            textBox5.Text = "ids: " + rv.ToString() + "\r\nvalue sum: " + rv.getValueSum() + "\r\ncapacity used: " + rv.getCapacityUsed() ;
            //textBox5.Text = formsCapacity.ToString() + formsNumItems.ToString() + formsSeed.ToString(); 
            textBox4.Text = problem.ParseToString();


        }
    }
}
