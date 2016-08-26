using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CodeTrack
{
    public class Manager
    {
        public List<Link> Links;
        XDocument xDoc;
        String FILE_NAME = Constants.FILE_NAME;


        public Manager()
        {
            xDoc = XDocument.Load(FILE_NAME);
            Links = new List<Link>();
            loadData();
        }

        // Show all links in a rich text box.
        public void ShowAllLinks(RichTextBox rtb)
        {
            rtb.Clear();
            IEnumerable<String> allLinks;
            allLinks = from l in Links
                       select l.ToString();

            foreach (String l in allLinks)
                rtb.Text += l;
        }

        public void AddNewLink(String topic, String address, String linkType,
            String description)
        {
            // Create new XElement called newLink which will be a link entry in 
            // our XML file.
            XElement newLink = new XElement("Link",
                                                    new XElement("Topic", topic),
                                                    new XElement("Address", address),
                                                    new XElement("Link_Type", linkType),
                                                    new XElement("Description", description)
                                            );

            // Add new link to our XDocument inside root element "Links".
            xDoc.Element("Links").Add(newLink);
            // Save and overwrite our xml file.
            xDoc.Save(FILE_NAME);
            // Feedback to user.
            MessageBox.Show("New entry added for: " + topic + " at " + address + ".");
        }

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
                Links.Add(new Link(topic, address, linkType, description));
            }
        }

    }
}
