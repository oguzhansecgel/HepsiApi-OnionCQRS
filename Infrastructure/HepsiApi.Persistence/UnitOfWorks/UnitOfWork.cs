﻿using HepsiApi.Application.Interface.Repositories;
using HepsiApi.Application.Interface.UnitOfWorks;
using HepsiApi.Persistence.Context;
using HepsiApi.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask DisposeAsync() => await _appDbContext.DisposeAsync();

        public int Save()=>_appDbContext.SaveChanges();

        public async Task<int> SaveAsync()=>await _appDbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_appDbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(_appDbContext);
    }
}
 