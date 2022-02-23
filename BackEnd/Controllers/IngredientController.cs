using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.IngredientMagazinRepository;
using Proiect_O_A.Repositories.IngredientRepository;
using Proiect_O_A.Repositories.RetetaIngredientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _repository;
        private readonly IIngredientMagazinRepository _repository2;
        private readonly IRetetaIngredientRepository _repository3;
        public IngredientController(IIngredientRepository repository, IIngredientMagazinRepository repository2, IRetetaIngredientRepository repository3)
        {
            _repository = repository;
            _repository2 = repository2;
            _repository3 = repository3;
        }
        [HttpGet]
        [Route("magazine/{nume}")]
        //[Authorize]
        public async Task<IActionResult> GetIngredientWithMagazine(string nume)
        {
            var magazine = await _repository2.GetByIngredientName(nume);
            var ingredient= await _repository.GetByName(nume);
            return Ok(new MagazineleCareVandIngredientulDTO(ingredient, magazine));
        }
        [HttpGet]
        [Route("all")]
        //[Authorize]
        public async Task<IActionResult> GetAllWithMagazine()
        {
            var ingrediente = await _repository.GetAllIngrediente();
            var ingrediente_return = new List<MagazineleCareVandIngredientulDTO>();
            foreach (var ingredient in ingrediente)
            {
                var magazine = await _repository2.GetByIngredientName(ingredient.Nume);
                ingrediente_return.Add(new MagazineleCareVandIngredientulDTO(ingredient, magazine));
            }
            return Ok(ingrediente_return);
        }
        [HttpGet]
        [Route("retete/{nume}")]
        //[Authorize]
        public async Task<IActionResult> GetIngredientWithRetete(string nume)
        {
            var retete = await _repository3.GetByIngredientName(nume);
            var ingredient = await _repository.GetByName(nume);
            return Ok(new ReteteleCareContinIngredientulDTO(ingredient, retete));
        }
        [HttpGet]
        [Route("byname/{name}")]
        [Authorize]
        public async Task<IActionResult> GetIngredientByName(string name)
        {
            var ingredient = await _repository.GetByName(name);
            return Ok(new IngredientDTO(ingredient));
        }
        [HttpGet]
        [Route("byNameWithMagazine/{name}")]
        //[Authorize]
        public async Task<IActionResult> GetIngredientWithMagazineByName(string name)
        {
            var ingredient = await _repository.GetByName(name);
            var magazine = await _repository2.GetByIngredientName(ingredient.Nume);
            return Ok(new MagazineleCareVandIngredientulDTO(ingredient, magazine));
        }
        [HttpGet]
        [Route("byid/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetIngredientById(int id)
        {
            var ingredient = await _repository.GetByIdAsync(id);
            return Ok(new IngredientDTO(ingredient));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Bucatar, ResponsabilMag")]
        public async Task<IActionResult> CreateIngredient(CreateIngredientDTO dto)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Nume = dto.Nume;
            ingredient.Unitate_Masura = dto.Unitate_Masura;
            ingredient.Categorie = dto.Categorie;
            _repository.Create(ingredient);
            await _repository.SaveAsync();
            return Ok(new IngredientDTO(ingredient));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient_de_sters = await _repository.GetByIdAsync(id);
            if (ingredient_de_sters == null)
            {
                return NotFound("Nu exista ingredientul dat");
            }
            _repository.Delete(ingredient_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("update/{nume}/{numeNou}/{unitateMasura}/{categorie}")]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> UpdateIngredient(string nume, string numeNou, string unitateMasura, string categorie)
        {
            var ingredient = await _repository.GetByName(nume);
            ingredient.Nume = numeNou;
            ingredient.Unitate_Masura = unitateMasura;
            ingredient.Categorie = categorie;
            await _repository.SaveAsync();
            return Ok(new IngredientDTO(ingredient));
        }

    }
}
