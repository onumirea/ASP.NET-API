using Microsoft.EntityFrameworkCore;
using Proiect_O_A.Data;
using Proiect_O_A.Entities;
using Proiect_O_A.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories.AutorRepository
{
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        public AutorRepository(ProiectOAContext context):base(context){}

        public async Task<Autor> GetByName(string nume)
        {
            return await _context.Autori.Where(a => a.Nume == nume).FirstOrDefaultAsync();
        }
        public async Task<List<Autor>> GetAllAutori()
        {
            return await _context.Autori.ToListAsync();
        }
    }
}
