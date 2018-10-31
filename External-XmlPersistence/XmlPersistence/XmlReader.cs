using System.Xml.Serialization;

namespace ExternalXmlPersistence
{
    public class XmlReader
    {
        public XmlReader() {}

        [XmlAttribute]
        public long Id { get; set; }

        [XmlAttribute]
        public string CardId { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Surname { get; set; }
    }
}
