using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            
            foreach (var car in carManager.GetByDailyPrice(1000,2000))
            {
                Console.WriteLine($"{car.CarId}\t\t{brandManager.GetById(car.BrandId).BrandName}" +
                    $"\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }
    }
}
