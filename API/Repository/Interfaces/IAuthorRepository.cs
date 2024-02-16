using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Author;
using API.Models;

namespace API.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author?> UpdateAsync(int id,UpdateAuthorRequestDto author);
        Task<Author?> DeleteAsync(int id);
     }
}