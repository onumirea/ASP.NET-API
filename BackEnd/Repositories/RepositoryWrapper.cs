using Proiect_O_A.Data;
using Proiect_O_A.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_O_A.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ProiectOAContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        public RepositoryWrapper(ProiectOAContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
