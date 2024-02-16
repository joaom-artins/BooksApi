using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dto.Author;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(b=>b.Books).ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
           var author=await _context.Authors.Include(b=>b.Books).FirstOrDefaultAsync(x=>x.Id==id);
           if (author is null)return null;
           return author;
        }
        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> DeleteAsync(int id)
        {
            var author=await _context.Authors.FirstOrDefaultAsync(x=>x.Id==id);
            if (author is null)return null;
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Author?> UpdateAsync(int id,UpdateAuthorRequestDto author)
        {
            var authorModel=await _context.Authors.FirstOrDefaultAsync(x=>x.Id==id);
            if (authorModel is null)return null;
            authorModel.Name=author.Name;
            await _context.SaveChangesAsync();
            return authorModel;
        }
    }
}