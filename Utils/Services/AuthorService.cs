using LibraryManagement.Models;
using LibraryManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Utils.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public ICollection<Author> parseAuthors(string authorsString)
        {
            ICollection<Author> authors = new List<Author>();
            var authorNames = authorsString.Split(',').Select(name => name.Trim());
            foreach(var name in authorNames)
            {
                var author = _authorRepository.FindByCondition(author => author.Name == name).FirstOrDefault();
                if(author == null)
                {
                    author = new Author() { Name = name };
                }
                authors.Add(author);
            }
            return authors;
        }

        public string stringifyAuthors(ICollection<Author> authors)
        {
            return String.Join(", ", authors.Select(author => author.Name));
        }
    }
}
