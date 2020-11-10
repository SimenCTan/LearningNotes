using Microsoft.EntityFrameworkCore;
using MvcMovies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovies.Data.Repositories
{
    public class EFStormSessionRepository : IBrainstormSessionRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public EFStormSessionRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public Task AddAsync(BrainstormSession session)
        {
            _movieDbContext.BrainstormSessions.Add(session);
            return _movieDbContext.SaveChangesAsync();
        }

        public Task<BrainstormSession> GetByIdAsync(int id)
        {
            return _movieDbContext.BrainstormSessions
              .Include(s => s.Ideas)
              .FirstOrDefaultAsync(s => s.Id == id);
        }
        
        public Task<List<BrainstormSession>> ListAsync()
        {
            return _movieDbContext.BrainstormSessions
                .Include(s => s.Ideas)
                .OrderByDescending(s => s.DateCreated)
                .ToListAsync();
        }

        public Task UpdateAsync(BrainstormSession session)
        {
            _movieDbContext.Entry(session).State = EntityState.Modified;
            return _movieDbContext.SaveChangesAsync();
        }
    }
}
