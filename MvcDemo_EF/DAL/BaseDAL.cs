using System;
using MvcDemo_EF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcDemo_EF.DAL
{
    public class BaseDAL<T> where T :class
    {
        // UserContext context = new UserContext();

        // public IQueryable<T> GetEntities(Expression<Func<T, bool>> lambdWhere)
        // {
        //     return context.Set<T>().Where(lambdWhere);
        // }

        // public int Add(T Entities)
        // {
        //     context.Set<T>.Add(Entities);
        //     return context.SaveChanges();
        // }
    }
}