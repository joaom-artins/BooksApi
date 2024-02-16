using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set;}=string.Empty;
        public int Pages { get; set; }
        public int AuthorId { get; set; }
    }
}