using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.AutorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect_O_A.Repositories.RetetaRepository;
using Microsoft.AspNetCore.Authorization;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _repository;
        private readonly IRetetaRepository _repository2;
        public AutorController(IAutorRepository repository, IRetetaRepository repository2)
        {
            _repository = repository;
            _repository2 = repository2;
        }

        [HttpGet]
        [Route("byname/{name}")]
        //[Authorize]
        public async Task<IActionResult> GetAutorByName(string name)
        {
            var autor = await _repository.GetByName(name);
            return Ok(new AutorDTO(autor));
        }
        [HttpGet]
        [Route("byid/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetAutorById(int id)
        {
            var autor = await _repository.GetByIdAsync(id);
            return Ok(new AutorDTO(autor));
        }
        [HttpGet]
        [Route("curetete/{nume}")]
        //[Authorize]
        public async Task<IActionResult> GetAutorWithRetete(string nume)
        {
            var retete = await _repository2.GetAllByNumeAutor(nume);
            var autor = await _repository.GetByName(nume);
            return Ok(new ReteteleAutoruluiDTO(autor,retete));
        }
        [HttpGet]
        [Route("all")]
        //[Authorize]
        public async Task<IActionResult> GetAllAutori()
        {
            var autori = await _repository.GetAllAutori();
            return Ok(autori);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> CreateAutor(CreateAutorDTO dto)
        {
            Autor autor = new Autor();
            autor.Nume = dto.Nume;
            autor.Prenume = dto.Prenume;
            autor.Ani_Experienta = dto.Ani_Experienta;
            _repository.Create(autor);
            await _repository.SaveAsync();
            return Ok(new AutorDTO(autor));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor_de_sters = await _repository.GetByIdAsync(id);
            if (autor_de_sters == null)
            {
                return NotFound("Nu exista autorul dat");
            }
            _repository.Delete(autor_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("update/{nume}")]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> UpdateAutor(string nume)
        {
            var autor = await _repository.GetByName(nume);
            autor.Ani_Experienta = autor.Ani_Experienta + 1;
            await _repository.SaveAsync();
            return Ok(new AutorDTO(autor));
        }
    }
}
