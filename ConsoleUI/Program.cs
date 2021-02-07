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
            //NewTest();

            //ColorTest();

            CarDetailTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void NewTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetByDailyPrice(1000, 2000))
            {
                Console.WriteLine($"{car.CarId}\t\t{brandManager.GetById(car.BrandId).BrandName}" +
                    $"\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarDetailTest()
        {
            
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {

                Console.WriteLine(car.CarName.PadRight(10) + car.BrandName.PadRight(16) + car.ColorName.PadRight(15) + car.DailyPrice);
            }
        }
    }
}
