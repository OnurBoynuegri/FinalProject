using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C# -------- ARAŞTIR.
            //altta kullanılan using kullanıldığında using'in  işi bittiğinde
            //Garbage Collecter'a bildirerek new'lenen class'ın bellekten hemen silinmesini sağlar.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                addedEntity.State = EntityState.Added;//bulunan ürüne ne yapcağımızı belirlediğimiz yer burada ekleme yapıldı.
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                updatedEntity.State = EntityState.Modified;//bulunan ürüne ne yapcağımızı belirlediğimiz yer burada ekleme yapıldı.
                context.SaveChanges();
            }
        }
    }
}
