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
            populateComboBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set form location to top left.
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            String topic = txtTopic.Text;
            String address = txtAddress.Text;
            String linkType = cbLinkType.SelectedValue.ToString();
            String language = cbLanguageTypes.SelectedValue.ToString();
            String description = txtDescription.Text;

            man.AddNewLink(topic, address, linkType, description, language);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            man.ShowAllLinks(rtbDisplay);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            man.SearchLinks(txtSearchTopic.Text, cbLinkTypeSearch.SelectedValue.ToString(),
                cbLanguageSearch.SelectedValue.ToString(), rtbDisplay);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            man.CreateXMLFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populateComboBoxes()
        {
            cbLinkType.DataSource = Constants.LINK_TYPES;
            cbLanguageTypes.DataSource = Constants.LANGUAGE_TYPES;
            cbLinkTypeSearch.DataSource = Constants.LINK_TYPES_SEARCH;
            cbLanguageSearch.DataSource = Constants.LANGUAGE_TYPES_SEARCH;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if user really wants to reset their XML file.
            DialogResult result = MessageBox.Show("Are you sure you want to reset your XML file?",
                "Sure?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                man.ResetXMLFile();
                MessageBox.Show("Successfully reset XML File", "Success!");
            }

        }

        private void loadDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            man.GenerateSeeds();
        }

        private void rtbDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            webBrowser1.Navigate(e.LinkText);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

    }
}
