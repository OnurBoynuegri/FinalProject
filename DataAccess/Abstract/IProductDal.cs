using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {//burada ürüne ait özel operasyonlar kullanılır.örn ürünün deteylarını getirmek.
        List<ProductDetailDto> GetProductDetails();
    }
}
//Code Refactoring