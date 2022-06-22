using CarDealer.Converter;
using CarDealer.Data;
using CarDealer.InputDtos;
using CarDealer.Models;
using CarDealer.OutputDtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var xmlSuppliers = File.ReadAllText(@"C:\Users\cmi\Desktop\New folder\CarDealer\Datasets\suppliers.xml");
            var xmlParts = File.ReadAllText(@"C:\Users\cmi\Desktop\New folder\CarDealer\Datasets\parts.xml");
            var xmlCars = File.ReadAllText(@"C:\Users\cmi\Desktop\New folder\CarDealer\Datasets\cars.xml");
            var xmlCustomers = File.ReadAllText(@"C:\Users\cmi\Desktop\New folder\CarDealer\Datasets\customers.xml");
            var xmlSales = File.ReadAllText(@"C:\Users\cmi\Desktop\New folder\CarDealer\Datasets\sales.xml");

            ImportSuppliers(db, xmlSuppliers);
            ImportParts(db, xmlParts);
            ImportCars(db, xmlCars);
            ImportCustomers(db, xmlCustomers);
            ImportSales(db, xmlSales);
            GetCarsWithDistance(db);
            GetCarsFromMakeBmw(db);
            Console.WriteLine(GetLocalSuppliers(db));
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplies = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliesDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            const string root = "suppliers";

            var result = XmlConverter.Serialize(supplies, root);

            return result;

        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BMWCarsDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelDistance = x.TravelledDistance
                }).OrderBy(m => m.Model)
                .ThenByDescending(tr => tr.TravelDistance)
                .ToList();

            const string root = "cars";

            var result = XmlConverter.Serialize(cars, root);

            return result;

        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars.Where(x => x.TravelledDistance > 2_000_000)
                                   .Select(x => new OutputCarsDto
                                   {
                                       Make = x.Make,
                                       Model = x.Model,
                                       TravelDistance = x.TravelledDistance
                                   }).OrderBy(m => m.Make).ThenBy(m => m.Model).Take(10).ToList();

            const string root = "cars";

            var result = XmlConverter.Serialize(cars, root);
            return result;
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";
            var salesDtos = XmlConverter.Deserializer<SalesDTO>(inputXml, root);

            var carsId = context.Cars.Select(x => x.Id).ToList();

            var neededSales = salesDtos.Where(x => carsId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount,
                }).ToList();

            context.Sales.AddRange(neededSales);
            context.SaveChanges();

            return $"Successfully imported {neededSales.Count}";

        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            var customersDtos = XmlConverter.Deserializer<CustomersDTO>(inputXml, root);

            var neededCustomers = customersDtos.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            }).ToList();

            context.Customers.AddRange(neededCustomers);
            context.SaveChanges();

            return $"Successfully imported {neededCustomers.Count}";

        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";
            var carsDtos = XmlConverter.Deserializer<CarsDTO>(inputXml, root);

            var partsId = context.Parts.Select(x => x.Id).ToList();


            var carsNeeded = carsDtos.Select(x => new Car
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelDistance,
                PartCars = x.Parts
                            .Select(x => x.Id)
                            .Distinct()
                            .Intersect(partsId)
                            .Select(a => new PartCar
                            {
                                PartId = a
                            }).ToList()
            }).ToList();

            context.Cars.AddRange(carsNeeded);
            context.SaveChanges();

            var a = context.Cars.Where(a => a.Make == "BMW");

            return $"Successfully imported {carsNeeded.Count}";

        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            var partsDto = XmlConverter.Deserializer<PartsDTO>(inputXml, root);

            var neededId = context.Suppliers.Select(x => x.Id).ToList();

            var partsNeeded = partsDto
                                .Where(x => neededId.Contains(x.SupplierId))
                                .Select(x => new Part
                                {
                                    Name = x.Name,
                                    Price = x.Price,
                                    Quantity = x.Quantity,
                                    SupplierId = x.SupplierId,
                                }).ToList();

            context.Parts.AddRange(partsNeeded);
            context.SaveChanges();

            return $"Successfully imported {partsNeeded.Count}";

        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var suppliesDTO = XmlConverter.Deserializer<SuppliersDTO>(inputXml, root);

            var suppliesNeeded = suppliesDTO.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            }).ToList();

            context.Suppliers.AddRange(suppliesNeeded);
            context.SaveChanges();

            return $"Successfully imported {suppliesNeeded.Count}";

        }
    }
}