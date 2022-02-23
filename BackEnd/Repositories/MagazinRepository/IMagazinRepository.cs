using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.MagazinRepository
{
    public interface IMagazinRepository : IGenericRepository<Magazin>
    {
        Task<Magazin> GetByName(string nume);
        Task<List<Magazin>> GetAllByOrasWithAdresa(string oras);
        Task<List<Magazin>> GetAllMagazineWithAdresa();
        Task<Magazin> GetByIdWithAdresa(int id);
    }
}
