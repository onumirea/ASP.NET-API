using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.GenericRepository;
using Proiect_O_A.Repositories.RetetaIngredientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.IngredientMagazinRepository
{
    public class IngredientMagazinRepository : GenericRepository<IngredientMagazin>, IIngredientMagazinRepository
    {
        public IngredientMagazinRepository(ProiectOAContext context) : base(context) { }
        public async Task<List<MagazinPerIngredientDTO>> GetByIngredientName(string nume)
        {
            return await _context.IngredientMagazine.Where(im => im.Ingredient.Nume == nume).Select(im => new MagazinPerIngredientDTO(im.Magazin, im.Pret)).ToListAsync();
        }
        public async Task<List<IngredientPerMagazinDTO>> GetByMagazinName(string nume)
        {
            return await _context.IngredientMagazine.Where(im => im.Magazin.Nume == nume).Select(im => new IngredientPerMagazinDTO(im.Ingredient, im.Pret)).ToListAsync();
        }
        public async Task<IngredientMagazin> GetByIds(int id1, int id2)
        {
            return await _context.IngredientMagazine.Where(ri => ri.IngredientId == id1 && ri.MagazinId == id2).FirstOrDefaultAsync();
        }
        public async Task<List<IngredientMagazin>> GetAllIngredienteMagazine()
        {
            return await _context.IngredientMagazine.ToListAsync();
        }
    }
}
