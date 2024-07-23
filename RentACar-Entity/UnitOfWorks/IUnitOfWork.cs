using RentACar_Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T>  GetRepository<T>() where T : class, new();

        void Commit();      //içine SaveChanges();
        Task CommitAsync();

    }
}
