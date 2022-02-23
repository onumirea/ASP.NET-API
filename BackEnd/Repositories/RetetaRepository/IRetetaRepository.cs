using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RetetaRepository
{
    public interface IRetetaRepository : IGenericRepository<Reteta>
    {
        Task<Reteta> GetByName(string nume);
        Task<List<Reteta>> GetAllRetete();
        Task<List<Reteta>> GetAllByNumeAutor(string nume_aut);
        Task<List<Reteta>> GetAllByCategorie(string categorie);
        Task<List<Reteta>> GetAllByBucatarie(string bucatarie);
        Task<List<Reteta>> GetAllByDificultate(string dificultate);
        Task<List<Reteta>> GetAllByTimp(int durata_in_min);
        Task<List<Reteta>> GetAllByPortii(int nr_portii);
        //dupa ce fel de carne are sau daca nu vrei sa aiba(prin ingrediente sa fie pui/porc/vita/miel sau daca nu e se considera fara
        //dupa un anumit ingredient
        //sub un anumit nr de calorii
    }
}
