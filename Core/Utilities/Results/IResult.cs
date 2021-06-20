using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    //void fonksiyonlarda yapılan işlemlerin başarılı olup olmadığını bildirmek için kullanırız.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
