using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.RetetaIngredientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetetaIngredientController : ControllerBase
    {
        private readonly IRetetaIngredientRepository _repository;
        public RetetaIngredientController(IRetetaIngredientRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllReteteIngrediente()
        {
            var reteta_ingrediente = await _repository.GetAllReteteIngrediente();
            return Ok(reteta_ingrediente);
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> CreateRetetaIngredient(CreateRetetaIngredientDTO dto)
        {
            RetetaIngredient reteta_ingredient = new RetetaIngredient();
            reteta_ingredient.RetetaId = dto.RetetaId;
            reteta_ingredient.IngredientId = dto.IngredientId;
            reteta_ingredient.Cantitate = dto.Cantitate;
            _repository.Create(reteta_ingredient);
            await _repository.SaveAsync();
            return Ok(new RetetaIngredientDTO(reteta_ingredient));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRetetaIngredient(int id1, int id2)
        {
            var reteta_ingredient_de_sters = await _repository.GetByIds(id1, id2);
            if (reteta_ingredient_de_sters == null)
            {
                return NotFound("Nu exista ingredientul pentru reteta data");
            }
            _repository.Delete(reteta_ingredient_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("update/{cantitate}/{id1}/{id2}")]
        [Authorize(Roles = "Admin, Bucatar")]
        public async Task<IActionResult> UpdateRetetaIngredient(int id1, int id2, int cantitate)
        {
            var reteta_ingredient = await _repository.GetByIds(id1, id2);
            reteta_ingredient.Cantitate = cantitate;
            await _repository.SaveAsync();
            return Ok(new RetetaIngredientDTO(reteta_ingredient));
        }
    }
}
