using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CodeTrack
{
    // Handles all of the work involved and interacts with classes and the UI
    // so that our classes aren't coupled with the user interface.
    public class Manager
    {
        public List<Link> Links;
        XDocument xDoc;
        String FILE_NAME = Constants.FILE_NAME;

        public Manager()
        {
            CreateXMLFile();
            xDoc = XDocument.Load(FILE_NAME);
            Links = new List<Link>();
            loadData();
        }

        // Show all links in a rich text box.
        public void ShowAllLinks(RichTextBox rtb)
        {
            IEnumerable<String> allLinks;
            allLinks = from l in Links
                       select l.ToString();

            display(allLinks, rtb);
        }

        // Search for a link.
        public void SearchLinks(String topic, String linkType, RichTextBox rtb)
        {
            IEnumerable<String> links;

            // Do we need to search for all kinds of links?
            if (linkType.Equals(""))
            {
                links = from l in Links
                        where l.Topic.Equals(topic)
                        select l.ToString();

                display(links, rtb);
            }
            // Otherwise, we have defined a user topic.
            else
            {
                links = from l in Links
                        where l.Topic.Equals(topic) && l.LinkType.Equals(linkType)
                        select l.ToString();

                display(links, rtb);
            }
        }

        public void AddNewLink(String topic, String address, String linkType,
            String description, String language)
        {
            // Create new XElement called newLink which will be a link entry in 
            // our XML file.
            XElement newLink = new XElement("Link",
                                                    new XElement("Topic", topic),
                                                    new XElement("Address", address),
                                                    new XElement("Link_Type", linkType),
                                                    new XElement("Description", description),
                                                    new XElement("Language", language)
                                            );

            // Add new link to our XDocument inside root element "Links".
            xDoc.Element("Links").Add(newLink);
            // Save and overwrite our xml file.
            xDoc.Save(FILE_NAME);
            // Feedback to user.
            MessageBox.Show("New entry added for: " + topic + " at " + address + ".");
            loadData();         // Reload.
        }

        // Will create a fresh XML file, if there is no links.XML already.
        public void CreateXMLFile()
        {
            if (File.Exists(FILE_NAME))
            {
                // Already exists, do nothing -- Maybe prompt user?
            }
            else
            {
                // We can use our method ResetXMLFile.
                ResetXMLFile();
            }
        }

        // Used to Reset (or create) an XML file that we will use to store all of our
        // data. Simply creates an XML file with root element "Links".
        public void ResetXMLFile()
        {
            if (File.Exists(FILE_NAME))
            {
                // Create the XML file.
                xDoc = new XDocument(
                    new XElement("Links"));
                // Save.
                xDoc.Save(FILE_NAME);
            }
        }


        // Private

        // Load all of our XML data into a List<Link>.
        private void loadData()
        {
            Links.Clear();  // Clear first.
            foreach (XElement link in xDoc.Element("Links").Elements("Link"))
            {
                String topic = link.Element("Topic").Value.Trim();
                String address = link.Element("Address").Value.Trim();
                String linkType = link.Element("Link_Type").Value.Trim();
                String description = link.Element("Description").Value.Trim();
                String language = link.Element("Language").Value.Trim();
                Links.Add(new Link(topic, address, linkType, description, language));
            }
        }

        // Display to a Rich Text Box.
        private void display(IEnumerable<String> collection, RichTextBox rtb)
        {
            rtb.Clear();
            foreach (string s in collection)
                rtb.Text += s.ToString();
        }

    }
}
