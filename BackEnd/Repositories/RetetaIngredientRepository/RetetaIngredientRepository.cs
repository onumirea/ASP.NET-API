using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RetetaIngredientRepository
{
    public class RetetaIngredientRepository : GenericRepository<RetetaIngredient>, IRetetaIngredientRepository
    {
        public RetetaIngredientRepository(ProiectOAContext context) : base(context) { }
        public async Task<List<IngredientPerRetetaDTO>> GetByRetetaName(string nume)
        {
            return await _context.RetetaIngrediente.Where(ri => ri.Reteta.Nume == nume).Select(ri => new IngredientPerRetetaDTO(ri.Ingredient,  ri.Cantitate)).ToListAsync();
        }
        public async Task<List<RetetaPerIngredientDTO>> GetByIngredientName(string nume)
        {
            return await _context.RetetaIngrediente.Where(ri => ri.Ingredient.Nume == nume).Select(ri => new RetetaPerIngredientDTO(ri.Reteta, ri.Cantitate)).ToListAsync();
        }
        public async Task<RetetaIngredient> GetByIds(int id1, int id2)
        {
            return await _context.RetetaIngrediente.Where(ri => ri.RetetaId == id1 && ri.IngredientId==id2).FirstOrDefaultAsync();
        }
        public async Task<List<RetetaIngredient>> GetAllReteteIngrediente()
        {
            return await _context.RetetaIngrediente.ToListAsync();
        }
    }
}
