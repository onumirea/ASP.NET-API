using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.IngredientMagazinRepository;
using Proiect_O_A.Repositories.MagazinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinController : ControllerBase
    {
        private readonly IMagazinRepository _repository;
        private readonly IIngredientMagazinRepository _repository2;
        public MagazinController(IMagazinRepository repository, IIngredientMagazinRepository repository2)
        {
            _repository = repository;
            _repository2 = repository2;
        }
        [HttpGet]
        [Route("ingrediente/{nume}")]
        //[Authorize]
        public async Task<IActionResult> GetMagazinWithIngrediente(string nume)
        {
            var ingrediente = await _repository2.GetByMagazinName(nume);
            var magazin = await _repository.GetByName(nume);
            return Ok(new IngredienteleMagazinuluiDTO(magazin, ingrediente));
        }
        [HttpGet]
        [Route("byname/{name}")]
        //[Authorize]
        public async Task<IActionResult> GetMagazinByName(string name)
        {
            var magazin = await _repository.GetByName(name);
            return Ok(new MagazinDTO(magazin));
        }
        [HttpGet]
        [Route("byid/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetMagazinById(int id)
        {
            var magazin = await _repository.GetByIdWithAdresa(id);
            return Ok(new MagazinDTO(magazin));
        }
        [HttpGet]
        [Route("all")]
        //[Authorize]
        public async Task<IActionResult> GetAllMagazine()
        {
            var magazine = await _repository.GetAllMagazineWithAdresa();
            var magazine_return = new List<MagazinDTO>();
            foreach (var magazin in magazine)
            {
                magazine_return.Add(new MagazinDTO(magazin));
            }
            return Ok(magazine_return);
        }
        [HttpGet]
        [Route("byoras/{oras}")]
        //[Authorize]
        public async Task<IActionResult> GetAllMagazineByOras(string oras)
        {
            var magazine = await _repository.GetAllByOrasWithAdresa(oras);
            var magazine_return = new List<MagazinDTO>();
            foreach (var magazin in magazine)
            {
                magazine_return.Add(new MagazinDTO(magazin));
            }
            return Ok(magazine_return);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, ResponsabilMag")]
        public async Task<IActionResult> CreateMagazin(CreateMagazinDTO dto)
        {
            Magazin magazin = new Magazin();
            magazin.Nume = dto.Nume;
            magazin.Telefon = dto.Telefon;
            magazin.Email = dto.Email;
            magazin.Site = dto.Site;
            magazin.Adresa = dto.Adresa;
            _repository.Create(magazin);
            await _repository.SaveAsync();
            return Ok(new MagazinDTO(magazin));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMagazin(int id)
        {
            var magazin_de_sters = await _repository.GetByIdAsync(id);
            if (magazin_de_sters == null)
            {
                return NotFound("Nu exista magazinul dat");
            }
            _repository.Delete(magazin_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("update/{id}/{telefon}")]
        [Authorize(Roles = "Admin, ResponsabilMag")]
        public async Task<IActionResult> UpdateTelefonMagazin(int id, string telefon)
        {
            var magazin = await _repository.GetByIdAsync(id);
            magazin.Telefon = telefon;
            await _repository.SaveAsync();
            return Ok(new MagazinDTO(magazin));
        }
    }
}
