﻿﻿using System;

namespace Borrowings.DomainModel
{
    public class ModelFactory
    {
        public Book Book(string isbn, string author, string title)
        {
            return new Book(isbn, author, title);
        }

        public Reader Reader(string cardId, string name, string surname)
        {
            return new Reader(cardId, name, surname);
        }

        public Borrowing Borrowing(Reader who, Book whichBook, DateTime fromWhen, int forHowLong) 
        {
            return new Borrowing(who, whichBook, fromWhen, forHowLong);
        }
    }
}
