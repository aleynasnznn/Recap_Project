using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RecapContext>, IUserDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                              on c.CustomerId equals u.UserId

                             select new CustomerDetailDto
                             {
                                 CustomerID = c.CustomerId,
                                 FirstName= u.FirstName,
                                 LastName=u.LastName,
                                 Email=u.Email,
                                 Password=u.Password,
                                 CompanyName=c.CompanyName
                             };
                return result.ToList();
            }

        }
    }
}
