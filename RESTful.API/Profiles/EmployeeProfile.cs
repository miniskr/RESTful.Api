﻿using AutoMapper;
using RESTful.API.Entities;
using RESTful.API.Models;
using System;

namespace RESTful.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.GenderDisplay,
                            opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Age,
                            opt => opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year))
                ;
        }
    }
}
