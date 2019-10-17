using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "packages")]
    public class Packages
    {
        [XmlElement(ElementName = "package")]
        public List<Package> Package { get; set; }
    }
}