﻿using Dapper.Contrib.Extensions;
using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Interfaces.Repositorios;
using LojaVirtual.Infra.Data.Dapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LojaVirtual.Infra.Data.Dapper.Repositorios
{
    public class RepositorioBase<TEntity> : SqlConnectionBase, IRepositorioBase<TEntity>, IDisposable where TEntity : class
    {
        public void Add(TEntity obj)
        {
            using (var conn = CreateConnection)
            {
                conn.Insert<TEntity>(obj);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var conn = CreateConnection)
            {
                return conn.GetAll<TEntity>().ToList();
            }
        }
        public TEntity GetById(int id)
        {
            using (var conn = CreateConnection)
            {
                return conn.Get<TEntity>(id);
            }
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            using (var conn = CreateConnection)
            {
                conn.Delete<TEntity>(entity);
            }
        }

        public void Remove(TEntity obj)
        {
            using (var conn = CreateConnection)
            {
                conn.Delete<TEntity>(obj);
            }
        }

        public void Update(TEntity obj)
        {
            using (var conn = CreateConnection)
            {
                conn.Update<TEntity>(obj);
            }
        }
    }
}