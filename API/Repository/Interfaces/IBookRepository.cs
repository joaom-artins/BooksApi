using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Book;
using API.Helpers;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(QueryBookObject query);
        Task<Book?> GetById(int id);
        Task<Book?> CreateAsync(Book book);
        Task<Book?> UpdateAsync(int id,Book book);
        Task<Book?> RemoveAsync(int id);
    }
}