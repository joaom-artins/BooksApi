using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Mapper;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Interfaces
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
           var bookModel=await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
           if(bookModel is null) return null;
           return bookModel;
        }
        public async Task<Book?> CreateAsync(Book book)
        {
            if(book is null) return null;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book?> RemoveAsync(int id)
        {
            var bookModel=await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if(bookModel is null) return null;
            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var bookModel=await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if(bookModel is null) return null;
            bookModel.Pages=book.Pages;
            bookModel.Title=book.Title;
            bookModel.Description=bookModel.Description;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}