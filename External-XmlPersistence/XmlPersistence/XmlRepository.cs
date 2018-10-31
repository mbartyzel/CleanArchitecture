using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Borrowings.DomainModel;
using Borrowings.Gateway;

namespace ExternalXmlPersistence
{
    public class XmlRepository : IRepository
    {
        static readonly String XML_FILE_NAME = AppDomain.CurrentDomain.BaseDirectory + @"/storage.xml";

        StorageRoot _root;

        ObjectAssembler _assembler;

        public XmlRepository(ObjectAssembler assembler) {

            _assembler = assembler;

            _root = new StorageRoot
            {
                Borrowings = new List<XmlBorrowing>(),
                Books = new List<XmlBook>(),
                Readers = new List<XmlReader>()
            };
        }

        public Book FindBook(string isbn)
        {
            return _assembler.toBook(_findXmlBook(isbn));
        }

        public Reader FindReader(string cardId)
        {
            return _assembler.toReader(_findXmlReader(cardId));
        }

        public Borrowing FindBorrowing(string isbn, string cardId)
        {
            XmlBorrowing xmlBorrowing = _findXmlBorrowing(isbn, cardId);

            XmlBook xmlBook = _findXmlBook(isbn);

            XmlReader xmlReader = _findXmlReader(cardId);

            return _assembler.toBorrowing(xmlBorrowing, xmlBook, xmlReader);
        }

        public void Store(Book book)
        {
            _root.Books.Add(_assembler.toXmlBook(book));
            _serialize();
        }

        public void Store(Reader reader)
        {
            _root.Readers.Add(_assembler.toXmlReader(reader));
            _serialize();
        }

        public void Store(Borrowing borrowing)
        {
             _root.Borrowings.Add(_assembler.toXmlBorrowing(borrowing));
            _serialize();
        }

        void _serialize() 
        {
            XmlSerializer serializer = new XmlSerializer(_root.GetType());
            Stream stream = new FileStream(XML_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.Serialize(stream, _root);
            stream.Close();
        }

        XmlBorrowing _findXmlBorrowing(string isbn, string cardId)
        {
            return _root.Borrowings.Find(x => x.IsIsbnOf(isbn) && x.IsReaderCardIdOf(cardId));
        }

        XmlBook _findXmlBook(string isbn)
        {
            return _root.Books.Find(x => x.Isbn.Equals(isbn));
        }

        XmlReader _findXmlReader(string cardId)
        {
            return _root.Readers.Find(x => x.CardId.Equals(cardId));
        }
    }
}
