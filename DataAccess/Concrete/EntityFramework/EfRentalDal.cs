using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                var result= from rental in context.Rentals

                            join car in context.cars
                            on rental.CarId equals car.CarId

                            join customer in context.Customers
                            on rental.CustomerId equals customer.CustomerId

                            join user in context.Users
                            on rental.CustomerId equals user.UserId

                            join brand in context.Brands
                            on car.BrandId equals brand.BrandId

                            select new RentalDetailDto
                            {
                                Id = rental.RentalId,
                                CarDescription = car.Description,
                                CarBrand = brand.BrandName,
                                CarModel = car.ModelYear,
                                CompanyName = customer.CompanyName,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                RentDate =rental.RentDate ,
                                ReturnDate = rental.ReturnDate
                            };
                                return result.ToList();
            };
        }
    }
}
