using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;

namespace mvc2019.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<Membership, MembershipDTO>();
            Mapper.CreateMap<Rental, RentalDTO>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>();            
            Mapper.CreateMap<MovieDTO, Movie>();
            Mapper.CreateMap<RentalDTO, Rental>();
        }
    }
}