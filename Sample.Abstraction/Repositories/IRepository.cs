using Sample.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IAggregate
    {
        TEntity Add(TEntity model);
        TEntity Update(TEntity model);
        void Delete(string id);
        List<TEntity> GetAll();
        List<TEntity> GetMany(Func<TEntity, bool> expression);
        TEntity GetOne(Func<TEntity, bool> expression);
    }
}
