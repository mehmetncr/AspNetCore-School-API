using AspNetCore_School_DataAccess_Layer.Context;
using AspNetCore_School_DataAccess_Layer.Repository;
using AspNetCore_School_Entity_Layer.Interfaces;
using AspNetCore_School_Entity_Layer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_DataAccess_Layer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await  _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
    }
}
