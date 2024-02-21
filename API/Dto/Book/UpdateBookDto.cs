using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Book
{
    public class UpdateBookDto
    {
        [Required]
        [MinLength(1,ErrorMessage ="Title must be 1 character")]
        [MaxLength(50,ErrorMessage ="Title cannot be over 50 character")]
        public string Title { get; set; }=string.Empty;
        [Required]
        [MinLength(4,ErrorMessage ="Description must be 4 character")]
        [MaxLength(280,ErrorMessage ="Description cannot be over 280 character")]
        public string Description { get; set;}=string.Empty;
        [Required]
        public int Pages { get; set; }
    }
}