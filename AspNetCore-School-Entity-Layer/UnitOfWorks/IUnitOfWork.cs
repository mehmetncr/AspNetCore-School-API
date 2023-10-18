using AspNetCore_School_Entity_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Entity_Layer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;  //unitofworks üzerinden repoya erişmek için
        void Commit(); //save
        Task CommitAsync(); //saveAsync
    }
}
