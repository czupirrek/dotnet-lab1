using dotnet_lab1;
using System.Runtime.CompilerServices;

namespace dotnet_lab1_gui
{
    public partial class Form1 : Form
    {
        private int formsSeed;
        private int formsNumItems;
        private int formsCapacity;

        private Problem problem;
        private Result rv;

        public Form1()
        {
            InitializeComponent();
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

            try
            {
                formsSeed = int.Parse(textBox1.Text);
                if (formsSeed < 0)
                {
                    textBox1.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {
                textBox1.BackColor = Color.Orange;
                throw;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                formsCapacity = int.Parse(textBox2.Text);
                if (formsCapacity < 0)
                {
                    textBox2.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {
                textBox2.BackColor = Color.Orange;
                throw;
            }
            
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                formsNumItems = int.Parse(textBox3.Text);
                if (formsNumItems < 0)
                {
                    textBox3.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {
                textBox3.BackColor = Color.Orange;
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            problem = new Problem(formsSeed, formsNumItems);
            rv = problem.Solve(formsCapacity);
            textBox5.Text = "ids: " + rv.ToString() + "\r\nvalue sum: " + rv.getValueSum() + "\r\ncapacity used: " + rv.getCapacityUsed() ;

            textBox4.Text = problem.ParseToString();


        }
    }
}
