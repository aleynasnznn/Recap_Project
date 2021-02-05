using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //List<Car> GetAll(Expression<Func<Car, bool>> filter = null);
        //Car Get(Expression<Func<Car, bool>> filter);
        //void Add(Car entity);
        //void Update(Car entity);
        //void Delete(Car entity);

    }
}
