using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //NewTest();
            //ShowColorTest(colorManager);
            //ShowBrandest(brandManager);
            //CarTestAll(carManager);
            //CarDetailTest(carManager);
            //CarTestAdd(carManager);
            //CarTestDelete(carManager);
            CarTestByBrand(carManager);
            //CarTestUpdate(carManager);


        }

        private static void AttributeDesign()
        {
            Console.WriteLine("ID\t" + "Brand ID\t" + "Color ID\t" + "Model Year\t" + "Daily Price\t" + "    Desciption");
            Console.WriteLine("--\t" + "--------\t" + "--------\t" + "----------\t" + "-----------\t" + "    ----------");
        }

        private static void ShowColorTest(ColorManager colorManager)
        {
            
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+"  "+color.ColorName);
            }
        }
        private static void ShowBandTest(BrandManager brandManager)
        {

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId+"  "+brand.BrandName);
            }
        }

        private static void NewTest(BrandManager brandManager, CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(1000, 2000))
            {
                Console.WriteLine($"{car.CarId}\t\t{brandManager.GetById(car.BrandId).BrandName}" +
                    $"\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
            }
        }


        private static void CarDetailTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                if (car.CarName == carManager.GetCarDetails()[0].CarName)
                {
                    Console.WriteLine($"Listed {carManager.GetCarDetails().Count} car(s)");

                }
                Console.WriteLine(car.CarName.PadRight(10) + car.BrandName.PadRight(16) + car.ColorName.PadRight(15) + car.DailyPrice);
            }
        }


        private static void CarTestAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                if (car.CarId == carManager.GetAll()[0].CarId)
                {
                    Console.WriteLine($"Listed {carManager.GetAll().Count} car(s)");
                    AttributeDesign();

                }
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }


        private static void CarTestAdd(CarManager carManager)
        {
            Console.WriteLine("\tAdding Car..");

            carManager.Add(new Car() { BrandId = 3, ColorId = 6, DailyPrice = 1200, ModelYear = 2018, Description = "four-wheel drive" });
            carManager.Add(new Car() { BrandId = 4, ColorId = 1, DailyPrice = 1100, ModelYear = 2015, Description = "classic" });
            carManager.Add(new Car() { BrandId = 6, ColorId = 3, DailyPrice = 900, ModelYear = 2016, Description = "sporty" });
            
            foreach (var car in carManager.GetAll())
            {
                if (car.CarId == carManager.GetAll()[0].CarId)
                {
                    Console.WriteLine($"Listed {carManager.GetAll().Count} car(s)");
                    AttributeDesign();


                }
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }
        private static void CarTestUpdate(CarManager carManager)
        {
            Console.WriteLine("\tUpdating Car..");
            carManager.Update(new Car{CarId =16,BrandId = 5,ColorId = 4,ModelYear = 2018, DailyPrice = 900,Description = "Speedy"});
            AttributeDesign();
            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarTestDelete(CarManager carManager)
        {
            Console.WriteLine("\tDeleting Car..");
            
            carManager.Delete(new Car() { CarId = 1015, BrandId = 7, ColorId = 3, DailyPrice = 2500, ModelYear = 2020, Description = "top-level" });

            foreach (var car in carManager.GetAll())
            {
                if (car.CarId == carManager.GetAll()[0].CarId)
                {
                    Console.WriteLine($"Listed {carManager.GetAll().Count} car(s)");

                }
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarTestByBrand(CarManager carManager)
        {
            foreach (var car in carManager.GetAllByBrandId(4))
            {
                if (car.CarId == carManager.GetAllByBrandId(4)[0].CarId)
                {
                   
                    Console.WriteLine($"\nCar informations of BrandId={car.BrandId}. Listed {carManager.GetAllByBrandId(4).Count} car(s)");
                    AttributeDesign();
                }
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }


        private static void CarTestByColor(CarManager carManager)
        {
            foreach (var car in carManager.GetAllByColorId(2))
            {
                if (car.CarId == carManager.GetAllByColorId(2)[0].CarId)
                {
                    Console.WriteLine($"\nCar informations of ColorId={car.ColorId}. Listed {carManager.GetAllByColorId(2).Count} car(s). ");
                    AttributeDesign();
                }

                Console.WriteLine($"{car.CarId}\t   {car.BrandId}\t\t   {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }

        

    }
}
