using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Entities;
using Proiect_O_A.Data;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.MagazinRepository
{
    public class MagazinRepository : GenericRepository<Magazin>, IMagazinRepository
    {
        public MagazinRepository(ProiectOAContext context) : base(context) { }
        public async Task<Magazin> GetByName(string nume)
        {
            return await _context.Magazine.Where(m => m.Nume == nume).FirstOrDefaultAsync();
        }
        public async Task<List<Magazin>> GetAllByOrasWithAdresa(string oras)
        {
            return await _context.Magazine.Include(m => m.Adresa).Where(m => m.Adresa.Oras == oras).ToListAsync();
        }
        public async Task<List<Magazin>> GetAllMagazineWithAdresa()
        {
            return await _context.Magazine.Include(m => m.Adresa).ToListAsync();
        }
        public async Task<Magazin> GetByIdWithAdresa(int id)
        {
            return await _context.Magazine.Include(m => m.Adresa).Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
