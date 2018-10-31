using System;
namespace Borrowings.DomainModel
{
    public class Reader
    {
        public string CardId { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Fullname => string.Format("{0} {1}", Name, Surname);

        internal Reader(string cardId, string name, string surname)
        {
            CardId = cardId;
            Name = name;
            Surname = surname;
        }
    }
}
