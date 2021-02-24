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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //ShowColorTest(colorManager);
            //ShowBrandest(brandManager);
            //CarTestAll(carManager);
            //CarDetailTest(carManager); //using DTO
            //CarTestAdd(carManager);
            //CarTestDelete(carManager);
            //CarTestByBrand(carManager);
            //CarTestUpdate(carManager);

            //UserTestAdd(userManager);
            //UserTestDelete(userManager);
            //CustomerTestAdd(customerManager);
            //Rental(rentalManager);
            ListRental(rentalManager);
        }

        private static void AttributeDesign()
        {
            Console.WriteLine("ID\t" + "Brand ID\t" + "Color ID\t" + "Model Year\t" + "Daily Price\t" + "    Desciption");
            Console.WriteLine("--\t" + "--------\t" + "--------\t" + "----------\t" + "-----------\t" + "    ----------");
        }

        private static void ShowColorTest(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            if(result.Success)
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorId+"  "+color.ColorName);
            }
            else
                Console.WriteLine(result.Message);
        }


        private static void ShowBandTest(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if(result.Success)
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId+"  "+brand.BrandName);
            }
            else
                Console.WriteLine(result.Message);
        }


        private static void CarDetailTest(CarManager carManager)
        {
           
            var result = carManager.GetCarDetails();
                if (result.Success)
                foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName.PadRight(10) + car.BrandName.PadRight(16) + car.ColorName.PadRight(15) + car.DailyPrice);
             }
            else
                Console.WriteLine(result.Message);
        }


        private static void CarTestAll(CarManager carManager)
        {
            var result = carManager.GetAll();
            AttributeDesign();
            if (result.Success)
                foreach (var car in result.Data)
            {
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
            else
                Console.WriteLine(result.Message);
        }


        private static void CarTestAdd(CarManager carManager)
        {
            Console.WriteLine("\tAdding Car..");
            var result = carManager.GetAll();
            carManager.Add(new Car() { BrandId = 3, ColorId = 6, DailyPrice = 1200, ModelYear = 2018, Description = "four-wheel drive" });
            carManager.Add(new Car() { BrandId = 4, ColorId = 1, DailyPrice = 1100, ModelYear = 2015, Description = "classic" });
            carManager.Add(new Car() { BrandId = 6, ColorId = 3, DailyPrice = 900, ModelYear = 2016, Description = "sporty" });
            
            foreach (var car in result.Data)
            {
 
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }
        private static void CarTestUpdate(CarManager carManager)
        {
            Console.WriteLine("\tUpdating Car..");
            carManager.Update(new Car{CarId =16,BrandId = 5,ColorId = 4,ModelYear = 2018, DailyPrice = 900,Description = "Speedy"});
            AttributeDesign();
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {

                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
        }

        private static void CarTestDelete(CarManager carManager)
        {
            Console.WriteLine("\tDeleting Car..");
            
            carManager.Delete(new Car() { CarId = 1015, BrandId = 7, ColorId = 3, DailyPrice = 2500, ModelYear = 2020, Description = "top-level" });
            var result = carManager.GetAll();
            if(result.Success)
            foreach (var car in result.Data)
            {
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
            else
                Console.WriteLine(result.Message);

        }

        private static void CarTestByBrand(CarManager carManager)
        {
            AttributeDesign();
            var result = carManager.GetAllByBrandId(4);
            if(result.Success)
            foreach (var car in result.Data )
            {
                Console.WriteLine($"{car.CarId}\t    {car.BrandId}\t\t    {car.ColorId}\t\t  {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
            else
                Console.WriteLine(result.Message);
        }


        private static void CarTestByColor(CarManager carManager)
        {
            var result = carManager.GetAllByColorId(2);
            AttributeDesign();
            if(result.Success)
            foreach (var car in result.Data)
            {

                Console.WriteLine($"{car.CarId}\t   {car.BrandId}\t\t   {car.ModelYear}\t\t    {car.DailyPrice}\t\t{car.Description}");
            }
            else
                Console.WriteLine(result.Message);
        }

        private static void UserTestAdd(UserManager userManager)
        {
            var result = userManager.Add(new User()
            {
                FirstName = "Atacenk",
                LastName = "Urut",
                Email = "atacenkurut@gmail.com",
                Password = "12345"
            });

            Console.WriteLine(result.Message);
        }
        private static void UserTestDelete(UserManager userManager)
        {
            var result = userManager.Delete(new User()
            {
                UserId=4,
                FirstName = "Aleyna",
                LastName = "Senozan",
                Email = "aleynasnzn@gmail.com",
                Password = "12345"
            });

            Console.WriteLine(result.Message);
        }
        private static void CustomerTestAdd(CustomerManager customerManager)
        {
            var result = customerManager.Add(new Customer()
            {
                UserId = 1,
                CompanyName="Elixus"
            });

            Console.WriteLine(result.Message);
        }

        private static void Rental(RentalManager rentalManager)
        {
            var result = rentalManager.Add(new Rental()
            {
                CarId = 3,
                CustomerId = 2,
                RentDate = new DateTime(2020, 01, 10),
                ReturnDate = new DateTime(2020, 02, 10),
            });
            System.Console.WriteLine(result.Message);
        }

        public static void ListRental(RentalManager rentalManager)
        {
            //try
            //{
                var result = rentalManager.GetAllRentDetail();
                if (result.Success == true)
                    foreach (var rental in result.Data)
                    {

                        Console.WriteLine(rental.Id+"  "+ rental.CompanyName+"  "+rental.RentDate+"  "+rental.ReturnDate);
                     
                    }
                else
                {
                    Console.WriteLine(result.Message);
                }
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            
        }

    }
}
