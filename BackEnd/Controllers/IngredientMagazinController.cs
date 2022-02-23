using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.IngredientMagazinRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientMagazinController : ControllerBase
    {
        private readonly IIngredientMagazinRepository _repository;
        public IngredientMagazinController(IIngredientMagazinRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("all")]
        //[Authorize]
        public async Task<IActionResult> GetAllIngredienteMagazine()
        {
            var ingredient_magazine = await _repository.GetAllIngredienteMagazine();
            return Ok(ingredient_magazine);
        }

        [HttpGet]
        [Route("pretmediu")]
        //[Authorize]
        public async Task<IActionResult> GetPretMediu()
        {
            var ingredient_magazine = await _repository.GetAllIngredienteMagazine();
            var query = ingredient_magazine.GroupBy(
                ingmag => ingmag.IngredientId,
                ingmag => ingmag.Pret,
                (basemag, ingred) => new
                {
                    Key = basemag,
                    Pret = ingred.Average()
                });
            return Ok(query);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, ResponsabilMag")]
        public async Task<IActionResult> CreateIngredientMagazin(CreateIngredientMagazinDTO dto)
        {
            IngredientMagazin ingredient_magazin = new IngredientMagazin();
            ingredient_magazin.IngredientId = dto.IngredientId;
            ingredient_magazin.MagazinId = dto.MagazinId;
            ingredient_magazin.Pret = dto.Pret;
            _repository.Create(ingredient_magazin);
            await _repository.SaveAsync();
            return Ok(new IngredientMagazinDTO(ingredient_magazin));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIngredientMagazin(int id1, int id2)
        {
            var ingredient_magazin_de_sters = await _repository.GetByIds(id1, id2);
            if (ingredient_magazin_de_sters == null)
            {
                return NotFound("Nu exista ingredientul pentru magazinul dat");
            }
            _repository.Delete(ingredient_magazin_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("update/{pret}/{id1}/{id2}")]
        [Authorize(Roles = "Admin, ResponsabilMag")]
        public async Task<IActionResult> UpdateIngredientMagazin(int id1, int id2, int pret)
        {
            var ingredient_magazin = await _repository.GetByIds(id1, id2);
            ingredient_magazin.Pret = pret;
            await _repository.SaveAsync();
            return Ok(new IngredientMagazinDTO(ingredient_magazin));
        }
    }
}
