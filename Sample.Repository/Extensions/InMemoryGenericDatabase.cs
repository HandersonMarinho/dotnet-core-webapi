﻿using Sample.Abstraction.Models;
using Sample.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sample.Repository
{
    public class InMemoryGenericDatabase<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregate
    {
        private List<TEntity> CacheData { get; set; } = new List<TEntity>();

        public virtual TEntity Add(TEntity model)
        {
            model.Id = Guid.NewGuid().ToString("N");
            model.Time = DateTime.Now;

            CacheData.Add(model);
            return model;
        }

        public virtual TEntity Update(TEntity model)
        {
            Delete(model.Id);
            model.Time = DateTime.Now;

            CacheData.Add(model);
            return model;
        }

        public virtual void Delete(string id)
        {
            CacheData = CacheData.Where(x => x.Id != id).ToList();
        }

        public virtual List<TEntity> GetAll()
        {
            return CacheData;
        }

        public virtual List<TEntity> GetMany(Func<TEntity, bool> expression)
        {
            return CacheData.Where(expression).ToList();
        }

        public virtual TEntity GetOne(Func<TEntity, bool> expression)
        {
            return CacheData.Where(expression).FirstOrDefault();
        }

        public virtual int Count()
        {
            return CacheData.Count;
        }
    }
}
