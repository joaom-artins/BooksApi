using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Book;
using API.Models;

namespace API.Dto.Author
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public List<BookDto> Books { get; set; }=[];
    }
}