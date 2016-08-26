using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTrack
{
    public partial class Form1 : Form
    {
        Manager man;
        public Form1()
        {
            InitializeComponent();
            man = new Manager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set form location to top left.
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            man.AddNewLink("Test", "Test.com", "TEST", "TESTTESTTEST");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            man.ShowAllLinks(rtbDisplay);
        }
    }
}
