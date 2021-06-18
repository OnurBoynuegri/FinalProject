using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        //categorynin hangi bilgilerine ulaşılacağını belirliyoruz
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
