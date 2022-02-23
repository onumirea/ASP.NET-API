using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.RecenzieRepository
{
    public class RecenzieRepository : GenericRepository<Recenzie>, IRecenzieRepository
    {
        public RecenzieRepository(ProiectOAContext context) : base(context) { }
        public async Task<List<Recenzie>> GetAllByNumeReteta(string nume_r)
        {
            return await _context.Recenzii.Where(r => r.Reteta.Nume ==  nume_r).ToListAsync();
        }
        public async Task<List<Recenzie>> GetAllByIdReteta(int id_r)
        {
            return await _context.Recenzii.Where(r => r.Reteta.Id == id_r).ToListAsync();
        }
        public async Task<List<Recenzie>> GetAllRecenzii()
        {
            return await _context.Recenzii.ToListAsync();
        }
    }
}
