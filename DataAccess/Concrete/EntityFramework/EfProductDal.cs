using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C# -------- ARAŞTIR.
            //altta kullanılan using kullanıldığında using'in  işi bittiğinde
            //Garbage Collecter'a bildirerek new'lenen class'ın bellekten hemen silinmesini sağlar.
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                addedEntity.State = EntityState.Added;//bulunan ürüne ne yapcağımızı belirlediğimiz yer burada ekleme yapıldı.
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);//db den gelen parametre ile eşleşen değer olup olmadığına bakar.
                updatedEntity.State = EntityState.Modified;//bulunan ürüne ne yapcağımızı belirlediğimiz yer burada ekleme yapıldı.
                context.SaveChanges();
            }
        }
    }
}
