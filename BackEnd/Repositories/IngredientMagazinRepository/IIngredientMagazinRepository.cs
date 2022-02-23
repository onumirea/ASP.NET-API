using Proiect_O_A.Entities;
using Proiect_O_A.Entities.DTOs;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.IngredientMagazinRepository
{
    public interface IIngredientMagazinRepository : IGenericRepository<IngredientMagazin>
    {
        Task<List<MagazinPerIngredientDTO>> GetByIngredientName(string nume);
        Task<List<IngredientPerMagazinDTO>> GetByMagazinName(string nume);
        Task<IngredientMagazin> GetByIds(int id1, int id2);
        Task<List<IngredientMagazin>> GetAllIngredienteMagazine();
    }
}
