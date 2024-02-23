using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto.Author;
using API.Helpers;
using API.Mapper;
using API.Models;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController:ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepo=authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]QueryAuthorObject query)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var author=await _authorRepo.GetAllAsync(query);
            var authorDto=author.Select(s=>s.ToAuthorDto());
            return Ok(authorDto);
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var author=await _authorRepo.GetByIdAsync(id);
            if(author is null) return NotFound();
            return Ok(author.ToAuthorDto());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorCreatedDto authorDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
           var authorModel=authorDto.ToAuthorFromAuthorDto();
           await _authorRepo.CreateAsync(authorModel);
           return CreatedAtAction(nameof(GetById),new{id=authorModel.Id},authorModel.ToAuthorDto());
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody] UpdateAuthorRequestDto updateAuthorRequestDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var authorModel=await _authorRepo.UpdateAsync(id,updateAuthorRequestDto);
              if(authorModel is null) return NotFound();

       
            return Ok(authorModel.ToAuthorDto());
        }  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var authorModel= await _authorRepo.DeleteAsync(id);
            if(authorModel is null) return NotFound();

            return NoContent();
        }
    }
}