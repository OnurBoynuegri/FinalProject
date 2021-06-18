using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Constraint T nin alabileceğil data türlerini sınırlandıma işlemidir.
    //T:class = referas tip olabilir demek
    //IEntitiy = IEntity olabilir ya da IEntity implemente eden bir nesne olabilir demek.
    //new() = newlene bilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //GetAll sınıfını çağırırken filtreleme için expression kullanılır.
        //mesela business katmanından productManager classından çağırılırken Linq kullanarak sadece product'ların fitayının ya da ıd sinin getirilmesini sağlamak için kullanılır.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
