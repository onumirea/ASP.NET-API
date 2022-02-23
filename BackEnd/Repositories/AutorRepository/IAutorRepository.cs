using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.AutorRepository
{
    public interface IAutorRepository : IGenericRepository<Autor>
    {
        Task<Autor> GetByName(string nume);
        Task<List<Autor>> GetAllAutori();
    }
}
