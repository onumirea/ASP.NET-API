using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.AutorRepository;
using Proiect_O_A.Repositories.RecenzieRepository;
using Proiect_O_A.Repositories.RetetaIngredientRepository;
using Proiect_O_A.Repositories.RetetaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetetaController : ControllerBase
    {
        private readonly IRetetaRepository _repository;
        private readonly IRecenzieRepository _repository2;
        private readonly IRetetaIngredientRepository _repository3;
        public RetetaController(IRetetaRepository repository, IRecenzieRepository repository2, IRetetaIngredientRepository repository3)
        {
            _repository = repository;
            _repository2 = repository2;
            _repository3 = repository3;
        }
        [HttpGet]
        [Route("recenzii/{nume}")]
        public async Task<IActionResult> GetRetetaWithRecenzii(string nume)
        {
            var recenzii = await _repository2.GetAllByNumeReteta(nume);
            var reteta = await _repository.GetByName(nume);
            return Ok(new RecenziileReteteiDTO(reteta, recenzii));
        }
        [HttpGet]
        [Route("ingredienteById/{id}")]
        public async Task<IActionResult> GetRetetaWithIngrediente(int id)
        {
            var reteta = await _repository.GetByIdAsync(id);
            var ingrediente = await _repository3.GetByRetetaName(reteta.Nume);
            return Ok(new IngredienteleReteteiDTO(reteta, ingrediente));
        }
        [HttpGet]
        [Route("categorie/{categ}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategorie(string categ)
        {
            var retete = await _repository.GetAllByCategorie(categ);
            return Ok(retete);
        }
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var reteta = await _repository.GetByIdAsync(id);
            return Ok(reteta);
        }


        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllWithIngrediente()
        {
            var retete = await _repository.GetAllRetete();
            var retete_return = new List<IngredienteleReteteiDTO>();
            foreach (var reteta in retete)
            {
                var ingrediente = await _repository3.GetByRetetaName(reteta.Nume);
                retete_return.Add(new IngredienteleReteteiDTO(reteta, ingrediente));
            }
            return Ok(retete_return);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> CreateReteta(CreateRetetaDTO dto)
        {
            Reteta reteta = new Reteta();
            reteta.Nume = dto.Nume;
            reteta.Grad_Dificultate = dto.Grad_Dificultate;
            reteta.Durata_minute = dto.Durata_minute;
            reteta.Numar_portii = dto.Numar_portii;
            reteta.Categorie = dto.Categorie;
            reteta.Bucatarie = dto.Bucatarie;
            reteta.Mod_preparare = dto.Mod_preparare;
            reteta.Informatii_Nutritionale = dto.Informatii_Nutritionale;
            reteta.AutorId = dto.AutorId;
            _repository.Create(reteta);
            await _repository.SaveAsync();
            return Ok(new RetetaDTO(reteta));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReteta(int id)
        {
            var reteta_de_sters = await _repository.GetByIdAsync(id);
            if (reteta_de_sters == null)
            {
                return NotFound("Nu exista reteta data");
            }
            _repository.Delete(reteta_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
