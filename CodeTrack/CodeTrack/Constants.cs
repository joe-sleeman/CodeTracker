using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTrack
{
    public static class Constants
    {
        public const string FILE_NAME = "links.xml";
        // No such thing as constant list - so make readonly.
        public static readonly List<String> LINK_TYPES = new List<String>() 
            { "Git - Private", "Git - Public", "Stack Overflow",
                "Dot Net Perls", "Code Academy" };
        public static readonly List<String> LINK_TYPES_SEARCH = new List<String>() 
            { "Any", "Git - Private", "Git - Public", "Stack Overflow",
                "Dot Net Perls", "Code Academy" };
        public static readonly List<String> LANGUAGE_TYPES = new List<String>() 
            { "C#", "C++", "Go", "Java", "JavaScript", "PHP", "Python", "Ruby", "R", "Other" };
        public static readonly List<String> LANGUAGE_TYPES_SEARCH = new List<String>() 
            { "Any", "C#", "C++", "Go", "Java", "JavaScript", "PHP", "Python", "Ruby", "R", "Other" };
    }
}
