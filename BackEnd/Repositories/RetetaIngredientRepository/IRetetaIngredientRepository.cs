using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RetetaIngredientRepository
{
    public interface IRetetaIngredientRepository : IGenericRepository<RetetaIngredient>
    {
        Task<List<IngredientPerRetetaDTO>> GetByRetetaName(string nume);
        Task<List<RetetaPerIngredientDTO>> GetByIngredientName(string nume);
        Task<RetetaIngredient> GetByIds(int id1, int id2);
        Task<List<RetetaIngredient>> GetAllReteteIngrediente();
    }
}
