using AutoMapper;
using Entity.Concrete;
using Entity.DTOs;

namespace WebUI.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddJobDto, Job>();
        }
    }
}
