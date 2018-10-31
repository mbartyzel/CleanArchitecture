using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExternalXmlPersistence
{
    [XmlRoot]
    public class StorageRoot
    {
        public StorageRoot() {}

        [XmlElement]
        public List<XmlBook> Books { get; set; }

        [XmlElement]
        public List<XmlReader> Readers { get; set; }

        [XmlElement]
        public List<XmlBorrowing> Borrowings { get; set; } 
    }
}
