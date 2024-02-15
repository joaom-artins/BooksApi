using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public List<Book> Books { get; set; }=new List<Book>();
    }
}