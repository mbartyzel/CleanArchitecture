using System.Xml.Serialization;

namespace ExternalXmlPersistence
{
    public class XmlBook
    {
        public XmlBook() {}

        [XmlAttribute]
        public long Id { get; set; }

        [XmlAttribute]
        public string Isbn { get; set; }

        [XmlAttribute]
        public string Author { get; set; }

        [XmlAttribute]
        public string Title { get; set; }
    }
}
