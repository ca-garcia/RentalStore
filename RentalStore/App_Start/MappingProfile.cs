using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2019.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();
        }
    }
}