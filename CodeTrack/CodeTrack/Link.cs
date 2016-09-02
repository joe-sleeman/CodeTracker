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
        public String Language { get; set; }

        public Link()
        {
        }

        public Link(String topic, String address, String linkType, String description, String language)
        {
            Topic = topic;
            Address = address;
            LinkType = linkType;
            Description = description;
            Language = language;
        }

        public override String ToString()
        {
            return "Topic: " + Topic + Environment.NewLine + 
                "Address: " + Address + Environment.NewLine +
                "Link Type: " + LinkType + Environment.NewLine +
                "Description: " + Description + Environment.NewLine +
                "Language: " + Language + Environment.NewLine
                + Environment.NewLine; 
        }
    }
}
