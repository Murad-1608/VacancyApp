﻿using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IJobSeekerDal : IRepositoryBase<JobSeeker>
    {
        List<JobSeekersDto> GetJobSeekerWithCity(Expression<Func<JobSeeker, bool>> filter = null);
    }
}
