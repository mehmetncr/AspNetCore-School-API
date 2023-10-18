using AspNetCore_School_Entity_Layer.DTOs;
using AspNetCore_School_Entity_Layer.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Service.Mapping
{
    public class MappingProfile : Profile
    {
       public MappingProfile() 
        {
            CreateMap<School, SchoolDto>().ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
