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
        public void SearchLinks(String topic, String linkType, String language, RichTextBox rtb)
        {
            IEnumerable<String> links;

            // Do we need to search for all kinds of links?
            if (linkType.Equals("Any") && language.Equals("Any"))
            {
                links = from l in Links
                        where l.Topic.Contains(topic)
                        select l.ToString();

            }
            // Otherwise, we have defined a user topic.
            // So lets check if they aren't fussy on language.
            else if (language.Equals("Any"))
            {
                links = from l in Links
                        where l.Topic.Contains(topic) && l.LinkType.Equals(linkType)
                        select l.ToString();

            }
            // Else, they are fussy on language, but maybe not type.
            else if (linkType.Equals("Any"))
            {
                links = from l in Links
                        where l.Topic.Contains(topic) && l.Language.Equals(language)
                        select l.ToString();
            }
            else
            // Fussy on both Language & LinkType
            {
                links = from l in Links
                        where l.Topic.Contains(topic) && l.Language.Equals(language)
                        && l.LinkType.Equals(linkType)
                        select l.ToString();
            }
            display(links, rtb);

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

        public void GenerateSeeds()
        {
            AddNewLink("Recursion - Sierpinski Triangle", "https://github.com/joe-sleeman/Fractals/blob/master/Fractals/Fractals/Triangle.cs",
                "Git - Public", "Using recursion to generate fractals", "C#");
            AddNewLink("Random in .NET", "http://www.dotnetperls.com/random", "Dot Net Perls", "Good tutorial on using Random in .NET", "C#");
            AddNewLink("Yes / No Message Box", "http://stackoverflow.com/questions/3036829/how-to-create-a-message-box-with-yes-no-choices-and-a-dialogresult",
                "Stack Overflow", "Answer explains how to create a Yes/No MessageBox in C#", "C#");
            AddNewLink("Non-Editable ComboBox", "http://stackoverflow.com/questions/85702/how-can-i-make-a-combobox-non-editable-in-net", "Stack Overflow",
                "Answer explains how to create a non-editable combo box in C#", "C#");
            AddNewLink("Unit Testing in C#", "https://github.com/joe-sleeman/Course-Work/blob/master/GreyScott/UnitTestGreyScott/UnitTest1.cs", "Git - Public",
                "Repo of unit tests that I did for an assignment 'Grey Scott Simulation'", "C#");
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
            // Create the XML file.
            xDoc = new XDocument(
                new XElement("Links"));
            // Save.
            xDoc.Save(FILE_NAME);
            loadData();
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
