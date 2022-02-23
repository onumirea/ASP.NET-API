using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RetetaRepository
{
    public class RetetaRepository : GenericRepository<Reteta>, IRetetaRepository
    {
        public RetetaRepository(ProiectOAContext context) : base(context) { }
        public async Task<Reteta> GetByName(string nume)
        {
            return await _context.Retete.Where(r => r.Nume == nume).FirstOrDefaultAsync();
        }
        public async Task<List<Reteta>> GetAllByNumeAutor(string nume_aut)
        {
            return await _context.Retete.Where(r => r.Autor.Nume == nume_aut).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllByCategorie(string categorie)
        {
            return await _context.Retete.Where(r => r.Categorie == categorie).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllByBucatarie(string bucatarie)
        {
            return await _context.Retete.Where(r => r.Bucatarie == bucatarie).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllByDificultate(string dificultate)
        {
            return await _context.Retete.Where(r => r.Grad_Dificultate == dificultate).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllByTimp(int durata_in_min)
        {
            return await _context.Retete.Where(r => r.Durata_minute <= durata_in_min).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllByPortii(int nr_portii)
        {
            return await _context.Retete.Where(r => r.Numar_portii >= nr_portii).ToListAsync();
        }
        public async Task<List<Reteta>> GetAllRetete()
        {
            return await _context.Retete.ToListAsync();
        }
    }
}
