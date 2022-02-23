using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.RecenzieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenzieController : ControllerBase
    {
        private readonly IRecenzieRepository _repository;
        public RecenzieController(IRecenzieRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllRecenzii()
        {
            var recenzii = await _repository.GetAllRecenzii();
            return Ok(recenzii);
        }
        [HttpGet]
        [Route("recenzii/{id_r}")]
        public async Task<IActionResult> GetRecenziileRetetei(int id_r)
        {
            var recenzii = await _repository.GetAllByIdReteta(id_r);
            return Ok(recenzii);
        }
        [HttpGet]
        [Route("rating_mediu/{id_r}")]
        public async Task<int> GetRatingMediu(int id_r)
        {
            var sum = 0;
            var count = 0;
            var recenzii = await _repository.GetAllByIdReteta(id_r);
            foreach (var recenzie in recenzii)
            {
                sum = sum + recenzie.Rating;
                count++;
            }
            if (count > 0)
            {
                return sum / count;
            }
            return 0;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRecenzie(CreateRecenzieDTO dto)
        {
            Recenzie recenzie = new Recenzie();
            recenzie.Continut = dto.Continut;
            recenzie.Rating = dto.Rating;
            recenzie.RetetaId = dto.RetetaId;
            _repository.Create(recenzie);
            await _repository.SaveAsync();
            return Ok(new RecenzieDTO(recenzie));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRecenzie(int id)
        {
            var recenzie_de_sters = await _repository.GetByIdAsync(id);
            if (recenzie_de_sters == null)
            {
                return NotFound("Nu exista recenzia data");
            }
            _repository.Delete(recenzie_de_sters);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("update/{continut}/{rating}/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRecenzie(string continut, int rating, int id)
        {
            var recenzie = await _repository.GetByIdAsync(id);
            recenzie.Continut = continut;
            recenzie.Rating = rating;
            await _repository.SaveAsync();
            return Ok(new RecenzieDTO(recenzie));
        }
    }
}
