using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;

namespace API.Repository.Interfaces
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context=context;
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Book> CreateAsync(Book book)
        {
            throw new NotImplementedException();
        }
        public Task<Book?> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> UpdateAsync(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}