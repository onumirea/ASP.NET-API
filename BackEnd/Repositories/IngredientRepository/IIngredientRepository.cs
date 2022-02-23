using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.IngredientRepository
{
    public interface IIngredientRepository: IGenericRepository<Ingredient>
    { 
        Task<Ingredient> GetByName(string nume);
        Task<List<Ingredient>> GetByCategorie(string cat);
        Task<List<Ingredient>> GetAllIngrediente();
    }
}
