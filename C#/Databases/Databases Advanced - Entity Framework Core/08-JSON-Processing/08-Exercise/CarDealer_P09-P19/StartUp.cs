using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //// Part one - Import data
            //// Problem 09 - Import Suppliers
            //var inputJsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //var resultUsers = ImportSuppliers(context, inputJsonSuppliers);
            //// Console.WriteLine(resultUsers);

            //// Problem 10 - Import PartsId
            //var inputJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            //var resultParts = ImportParts(context, inputJsonParts);
            //// Console.WriteLine(resultParts);

            //// Problem 11 - Import Cars
            //var inputJsonCars = File.ReadAllText("../../../Datasets/cars.json");
            //var resultCars = ImportCars(context, inputJsonCars);
            //// Console.WriteLine(resultCars);

            //// Problem 12 - Import Customers

            //var inputJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //var resultCustomers = ImportCustomers(context, inputJsonCustomers);
            //// Console.WriteLine(resultCustomers);

            //// Problem 13 - Import Sales
            //var inputJsonSales = File.ReadAllText("../../../Datasets/sales.json");
            //var resultSales = ImportSales(context, inputJsonSales);
            //// Console.WriteLine(resultSales);

            // Part two - Export data
            // Problem 14 - Export Ordered Customers
            //  Console.WriteLine(GetOrderedCustomers(context));

            // Problem 15 - Export Cars From Make Toyota
            // Console.WriteLine(GetCarsFromMakeToyota(context));

            // Problem 16 - Export Local Suppliers
            // Console.WriteLine(GetLocalSuppliers(context));

            // Problem 17 - Export Cars with Their List of Parts
            // Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // Problem 18 - Export Total Sales By Customer
            // Console.WriteLine(GetTotalSalesByCustomer(context));

            // Problem 19 - Export Sales with Applied Discount
            // Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count()}."; ;
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var suppliersIds = context.Suppliers.Select(x => x.Id).ToList();
            var dtoParts = JsonConvert
                .DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => suppliersIds.Contains(x.SupplierId));
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var carsDto = JsonConvert
                .DeserializeObject<IEnumerable<CarInputModel>>(inputJson);
            var listOfCars = new List<Car>();
            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }
                listOfCars.Add(currentCar);
            }
            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCustomers = JsonConvert
                .DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}."; ;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var dtoSales = JsonConvert
                .DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToArray();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(x => x.Make.Equals("Toyota"))
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance,
                })
                .ToArray();

            return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<LocalSupplierOutputDto>(mapper.ConfigurationProvider);

            var mappedSuppliers = mapper.Map<IEnumerable<LocalSupplierOutputDto>>(localSuppliers);
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(mappedSuppliers, jsonSettings);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars.Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                },
                parts = c.PartCars.Select(pc => new
                {
                    Name = pc.Part.Name,
                    Price = pc.Part.Price.ToString("F2")
                }).ToArray()
            }).ToArray();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context
                .Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
            };

            return JsonConvert.SerializeObject(sales, jsonSerializerSettings);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("F2"),
                price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                priceWithDiscount = ((s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m))
                    .ToString("f2")
            }).Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);

        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}