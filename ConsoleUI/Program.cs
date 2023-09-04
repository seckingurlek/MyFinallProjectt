using Business.Concrete;
using DataAccess.Concrete.EntityFramewok;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAllByUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName );
            }
            
        }
    }
}