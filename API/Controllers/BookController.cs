using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public BookController(IBookRepository bookRepository)
        {
            _BookRepo=bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookModel= await _BookRepo.GetAllAsync();
            if(bookModel is null) return NotFound();
            var bookDto=bookModel.Select(b=>b.ToBookDto());
            return Ok(bookDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bookModel=await _BookRepo.GetById(id);
            if(bookModel is null) return NotFound();
            return Ok(bookModel.ToBookDto());
        }
    }
}