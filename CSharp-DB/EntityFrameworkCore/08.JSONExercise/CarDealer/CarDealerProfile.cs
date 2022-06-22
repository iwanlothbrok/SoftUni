using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SuppliesDTO, Supplier>();
            CreateMap<CarsDTO, Car>();
            CreateMap<PartsDTO, Part>();
            CreateMap<CustomersDTO, Customer>();
            CreateMap<SalesDTO, Sale>();
        }
    }
}
