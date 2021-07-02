using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string ProductsListed="Ürün listelendi";
        internal static string MaintenanceTime="Sistem Bakımda";
        internal static string ProductCountOfCategoryError="Ürünü eklediğin kategoride çok ürün var başkan, yapma bunu.";
        internal static string ProductNameAlreadyExists = "Aynı isimde başka ürün var";
    }
}
