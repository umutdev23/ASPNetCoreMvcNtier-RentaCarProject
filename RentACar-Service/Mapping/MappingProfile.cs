using AutoMapper;
using RentACar_Entity.Entities;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Location,LocationViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeViewModel>().ReverseMap();
            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<Reservation, ReservationViewModel>().ReverseMap();



        }
    }
}
