using HepsiApi.Application.Interface.Repositories;
using HepsiApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Persistence.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbcontext;

        public WriteRepository(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        private DbSet<T> Table { get => dbcontext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
             
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));

        }
    }
}
