﻿using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class ExperienceDal : EfRepositoryBase<Experience,AppDbContext>, IExperienceDal
    {
    }
}
