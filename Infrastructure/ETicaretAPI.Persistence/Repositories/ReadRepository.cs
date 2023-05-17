using ETicaretAPI.Application.Common;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T>
        where T : BaseEntity
    {
        private readonly ETicaretAPIContext _context;

        public ReadRepository(ETicaretAPIContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        => tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        => tracking ? await Table.FindAsync(Guid.Parse(id)) : await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        => tracking ? await Table.FirstOrDefaultAsync(method) : await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync();

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        => tracking ? Table.AsQueryable().Where(method) : Table.AsQueryable().AsNoTracking().Where(method);

    }
}
