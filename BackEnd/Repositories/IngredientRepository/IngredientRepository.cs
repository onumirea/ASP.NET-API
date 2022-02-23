using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.IngredientRepository
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ProiectOAContext context) : base(context) { }

        public async Task<List<Ingredient>> GetByCategorie(string cat)
        {
            return await _context.Ingrediente.Where(a => a.Categorie == cat).ToListAsync();
        }

        public async Task<Ingredient> GetByName(string nume)
        {
            return await _context.Ingrediente.Where(a => a.Nume == nume).FirstOrDefaultAsync();
        }
        public async Task<List<Ingredient>> GetAllIngrediente()
        {
            return await _context.Ingrediente.ToListAsync();
        }
    }
}
