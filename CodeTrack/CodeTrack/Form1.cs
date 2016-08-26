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

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            String topic = txtTopic.Text;
            String address = txtAddress.Text;
            String linkType = txtLinkType.Text;
            String description = txtDescription.Text;

            man.AddNewLink(topic, address, linkType, description);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            man.ShowAllLinks(rtbDisplay);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            man.SearchLinks(txtSearchTopic.Text, txtSearchLinkType.Text, rtbDisplay);
        }

    }
}
