using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //context.Database.EnsureCreated();

            var JsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var JsonParts = File.ReadAllText("../../../Datasets/parts.json");
            var JsonCars = File.ReadAllText("../../../Datasets/cars.json");
            var JsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            var JsonSales = File.ReadAllText("../../../Datasets/customers.json");


            //#9  Console.WriteLine(ImportSuppliers(db, JsonStringSuppliers));
            //#10 Console.WriteLine(ImportParts(db, JsonStringParts));
            //#11 Console.WriteLine(ImportCars(db, JsonStringCars)); 
            //#12 Console.WriteLine(ImportCustomers(db, JsonStringCustomers));
            //#13 Console.WriteLine(ImportSales(db, JsonSales));
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var salesDTO = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

           // var sales = mapper.Map<IEnumerable<Sale>>(salesDTO);

            context.Sales.AddRange(salesDTO);

            context.SaveChanges();

            return $"Successfully imported {salesDTO.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)//12
        {
            InitializeMapper();

            var customersDTO = JsonConvert.DeserializeObject<IEnumerable<CustomersDTO>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDTO);

            context.Customers.AddRange(customers);
            
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)//10
        {
            InitializeMapper();

            var partsDTO = JsonConvert.DeserializeObject<IEnumerable<PartsDTO>>(inputJson).Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToList();

            var parts = mapper.Map<IEnumerable<Part>>(partsDTO).Where(S => S.SupplierId != 0).ToList();

            context.Parts.AddRange(parts);
            
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)//11
        {
            InitializeMapper();
            var carsDto = JsonConvert.DeserializeObject<CarsDTO[]>(inputJson);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();


            foreach (var carDto in carsDto)
            {

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }

            }

            context.Cars.AddRange(cars);

            context.PartCars.AddRange(carParts);

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)//9
        {
            InitializeMapper();

            var dtoSupplies = JsonConvert.DeserializeObject<IEnumerable<SuppliesDTO>>(inputJson);

            var supplies = mapper.Map<IEnumerable<Supplier>>(dtoSupplies);

            context.Suppliers.AddRange(supplies);
            context.SaveChanges();

            return $"Successfully imported {supplies.Count()}.";


        }
        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}