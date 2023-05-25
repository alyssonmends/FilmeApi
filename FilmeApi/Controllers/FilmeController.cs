using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //private static List<Filme> filmes = new List<Filme>();
        //private static int id = 1;

        [HttpPost]
        public IActionResult AdiconaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            /*filme.Id = id++;
            filmes.Add(filme);*/
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaFilmePorId), new { Id = filme.Id }, filme);
        }
        [HttpGet]
        public IActionResult RetornaFilmes()
        {
            return Ok(_context.Filmes);
        }
        [HttpGet("{id}")]
        public IActionResult RetornaFilmePorId(int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (f != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(f);
                return Ok(filmeDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme f = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (f == null) return NotFound();
            _mapper.Map(filmeDto, f);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveFilme(int id)
        {
            Filme f = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (f == null) return NotFound();
            _context.Remove(f);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
