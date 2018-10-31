using System;
using Borrowings.DomainModel;

namespace ExternalXmlPersistence
{
    public class ObjectAssembler
    {
        ModelFactory _create;

        public ObjectAssembler(ModelFactory factory)
        {
            _create = factory;
        }

        public XmlReader toXmlReader(Reader reader)
        {
            XmlReader xml = new XmlReader
            {
                Name = reader.Name,
                Surname = reader.Surname,
                CardId = reader.CardId
            };

            return xml;
        }

        public Reader toReader(XmlReader xml)
        {
            return _create.Reader(xml.CardId, xml.Name, xml.Surname);
        }

        public Book toBook(XmlBook xml)
        {
            return _create.Book(xml.Isbn, xml.Author, xml.Title);
        }

        public XmlBook toXmlBook(Book book)
        {
            XmlBook xml = new XmlBook
            {
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author
            };

            return xml;
        }

        public Borrowing toBorrowing(XmlBorrowing xmlBorrowing, XmlBook xmlBook, XmlReader xmlReader)
        {
            return _create.Borrowing(toReader(xmlReader), toBook(xmlBook), xmlBorrowing.StartDate, xmlBorrowing.BorrowingDuration);
        }

        public XmlBorrowing toXmlBorrowing(Borrowing borrowing)
        {
            XmlBorrowing xml = new XmlBorrowing
            {
                BookIsbn = borrowing.BookIsbn,
                ReaderCardId = borrowing.ReaderCardId,
                StartDate = borrowing.StartDate,
                BorrowingDuration = borrowing.BorrowingDuration
            };

            return xml;
        }
    }
}
