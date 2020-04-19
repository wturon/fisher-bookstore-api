using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;

namespace Fisher.Bookstore.Services
{

    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BookstoreContext db;

        public AuthorsRepository(BookstoreContext db)
        {
            this.db = db;
        }

        public int AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author.Id;
        }

        public bool AuthorExists(int authorId)
        {
            return (db.Authors.Find(authorId) != null);
        }

        public void DeleteAuthor(int authorId)
        {
            var author = db.Authors.Find(authorId);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author GetAuthor(int authorId)
        {
            return db.Authors.Find(authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return db.Authors;
        }

        public void UpdateAuthor(Author author)
        {
            var UpdateAuthor = db.Authors.Find(author.Id);
            UpdateAuthor.Name = author.Name;
            db.Authors.Update(UpdateAuthor);
            db.SaveChanges();

        }
    }
}