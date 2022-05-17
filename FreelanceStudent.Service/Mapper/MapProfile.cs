using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Entity.Entities;

namespace FreelanceStudent.Service.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Advert, AdvertDto>().ReverseMap();
            CreateMap<Background, BackgroundDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
