using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RecenzieRepository
{
    public interface IRecenzieRepository : IGenericRepository<Recenzie>
    {
        Task<List<Recenzie>> GetAllByNumeReteta(string nume_r);
        Task<List<Recenzie>> GetAllByIdReteta(int id_r);
        Task<List<Recenzie>> GetAllRecenzii();
    }
}
