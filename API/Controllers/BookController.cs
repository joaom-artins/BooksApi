using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Book;
using API.Helpers;
using API.Mapper;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IBookRepository _BookRepo;
        private readonly IAuthorRepository _AuthorRepo;
        public BookController(IBookRepository bookRepository,IAuthorRepository authorRepo)
        {
            _BookRepo=bookRepository;
            _AuthorRepo=authorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryBookObject query)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var bookModel= await _BookRepo.GetAllAsync(query);
            if(bookModel is null) return NotFound();
            var bookDto=bookModel.Select(b=>b.ToBookDto());
            return Ok(bookDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var bookModel=await _BookRepo.GetById(id);
            if(bookModel is null) return NotFound();
            return Ok(bookModel.ToBookDto());
        }
        [HttpPost("{authorId}")]
         public async Task<IActionResult> Post([FromRoute]int authorId,[FromBody]CreatedBookDto createdBookDto)
         {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(!await _AuthorRepo.AuthorExists(authorId)) return BadRequest();
            var bookModel=createdBookDto.ToBookFromCreate(authorId);
            await _BookRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById),new {Id=bookModel.Id},bookModel.ToBookDto());
         }
         [HttpPut("{id}")]
          public async Task<IActionResult> Put([FromRoute]int id,[FromBody]UpdateBookDto updateBookDto)
          {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var bookModel=await _BookRepo.UpdateAsync(id,updateBookDto.ToBookFromUpdate());
            if(bookModel is null) return NotFound();
            return Ok(bookModel.ToBookDto());
          }
          [HttpDelete("{id}")]
          public async Task<IActionResult> Delete([FromRoute]int id)
          {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var bookModel=await _BookRepo.RemoveAsync(id);
            if(bookModel is null) return NotFound();
            return NoContent();
          }
    }
}