using System;
using System.Xml.Serialization;

namespace ExternalXmlPersistence
{
    public class XmlBorrowing
    {
        public XmlBorrowing() {}

        [XmlAttribute]
        public long Id { get; set; }

        [XmlAttribute]
        public string ReaderCardId { get; set; }

        [XmlAttribute]
        public string BookIsbn { get; set; }

        [XmlAttribute]
        public DateTime StartDate { get; set; }

        [XmlAttribute]
        public int BorrowingDuration { get; set; }

        internal bool IsIsbnOf(string isbn)
        {
            return BookIsbn.Equals(isbn);
        }

        internal bool IsReaderCardIdOf(string cardId)
        {
            return ReaderCardId.Equals(cardId);
        }
    }
}
