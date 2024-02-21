using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto.Author
{
    public class UpdateAuthorRequestDto
    {
        [Required]
        [MinLength(4,ErrorMessage ="Author must be 4 character")]
        [MaxLength(50,ErrorMessage ="Author cannot be over 50 character")]
        public string Name { get; set; }=string.Empty;
    }
}