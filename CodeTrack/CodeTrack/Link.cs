using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTrack
{
    public class Link
    {
        public String Topic { get; set; }
        public String Address { get; set; }
        public String LinkType { get; set; }    // Change to Enum, maybe.
        public String Description { get; set; }

        public Link()
        {
        }

        public Link(String topic, String address, String linkType, String description)
        {
            Topic = topic;
            Address = address;
            LinkType = LinkType;
            Description = description;
        }

        public override String ToString()
        {
            return "Topic: " + Topic + "\t Address: " + Address +
                "\t Link Type: " + LinkType + Environment.NewLine +
                "Description: " + Description + Environment.NewLine
                + Environment.NewLine; 
        }
    }
}
