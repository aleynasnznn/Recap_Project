﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal: IEntityRepository<Brand>
    {
        //List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null);
        //Brand Get(Expression<Func<Brand, bool>> filter);
        //void Add(Brand entity);
        //void Update(Brand Ientity);
        //void Delete(Brand entity);

    }
}
