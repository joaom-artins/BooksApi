using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Book
    { 
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set;}=string.Empty;
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}