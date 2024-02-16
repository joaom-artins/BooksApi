using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Book;
using API.Models;

namespace API.Mapper
{
    public static class BookMapper
    {
        public  static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id=bookModel.Id,
                Title=bookModel.Title,
                Description=bookModel.Description,
                Pages=bookModel.Pages,
                AuthorId=bookModel.AuthorId
            };
        }
    }
}