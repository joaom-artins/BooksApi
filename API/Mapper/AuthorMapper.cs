using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Author;
using API.Models;

namespace API.Mapper
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author authorModel)
        {
            return new AuthorDto
            {
                Id=authorModel.Id,
                Name=authorModel.Name,
                Books=authorModel.Books
            };
        }
        public static Author ToAuthorFromAuthorDto(this AuthorCreatedDto authorDto)
        {
            return new Author
            {
                Name=authorDto.Name,
                Books=new List<Book>()
            };
        }
    }
}