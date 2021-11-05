using MVCCoreTemplate.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MVCCoreTemplate.Core.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntitiy, new()
    {

        T GetById(Expression<Func<T, bool>> where);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

    }
}
