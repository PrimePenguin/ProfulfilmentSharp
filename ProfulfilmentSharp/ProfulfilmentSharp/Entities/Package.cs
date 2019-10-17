using System.Xml.Serialization;

namespace ProfulfilmentSharp.Entities
{
    [XmlRoot(ElementName = "package")]
    public class Package
    {
        [XmlAttribute(AttributeName = "despatchReference")]
        public string DespatchReference { get; set; }
    }
}