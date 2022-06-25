using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

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
            //var inputXmlSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var resultUsers = ImportSuppliers(context, inputXmlSuppliers);
            ////Console.WriteLine(resultUsers);

            //// Problem 10 - Import Parts
            //var inputXmlParts = File.ReadAllText("../../../Datasets/parts.xml");
            //var resultParts = ImportParts(context, inputXmlParts);
            //// Console.WriteLine(resultParts);

            //// Problem 11 - Import Cars
            //var inputXmlCars = File.ReadAllText("../../../Datasets/cars.xml");
            //var resultCars = ImportCars(context, inputXmlCars);
            //// Console.WriteLine(resultCars);

            //// Problem 12 - Import Customers
            //var inputXmlCustomers = File.ReadAllText("../../../Datasets/customers.xml");
            //var resultCustomers = ImportCustomers(context, inputXmlCustomers);
            //// Console.WriteLine(resultCustomers);

            //// Problem 13 - Import Sales
            //var inputXmlSales = File.ReadAllText("../../../Datasets/sales.xml");
            //var resultSales = ImportSales(context, inputXmlSales);
            //// Console.WriteLine(resultSales);

            // Part two - 3. Query and Export Data
            // Problem 14 - Cars With Distance
            // Console.WriteLine(GetCarsWithDistance(context));

            // Problem 15 - Cars from make BMW
            // Console.WriteLine(GetCarsFromMakeBmw(context));

            // Problem 16 - Export Local Suppliers
            // Console.WriteLine(GetLocalSuppliers(context));

            // Problem 17 - Export Cars With Their List Of Parts
            // Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // Problem 18 - Export Total Sales By Customer
            // Console.WriteLine(GetTotalSalesByCustomer(context));

            // Problem 19 - Sales with Applied Discount
            // Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            InitializeAutoMapper();
            const string root = "Suppliers";
            var suppliersDto = XmlConverter.Deserializer<SupplierInputModel>(inputXml, root);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}"; ;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            const string root = "Parts";
            var supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            // using standard way to serialize xml
            /*var xmlRoot = new XmlRootAttribute(root);
            var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), xmlRoot);

            using StringReader sr = new StringReader(inputXml);

            var partsDto = (PartInputModel[])xmlSerializer.Deserialize(sr);*/

            // using helper class
            var partsDto = XmlConverter.Deserializer<PartInputModel>(inputXml, root);

            var parts = mapper.Map<List<Part>>(partsDto).Where(x => supplierIds.Contains(x.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}"; ;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            const string root = "Cars";

            // using standard way to serialize xml
            //var xmlSerializer = GenerateXmlSerializer(root, typeof(CarInputModel[]));
            //using StringReader sr = new StringReader(inputXml);
            //var carsDto = (CarInputModel[])xmlSerializer.Deserialize(sr);

            var carsDto = XmlConverter.Deserializer<CarInputModel>(inputXml, root);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in carsDto)
            {
                var c = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                // nested object
                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();

                // check if part Id is unique
                foreach (var partId in carDto.Parts.Select(x => x.Id).Distinct())
                {
                    // check if part Id is in the parts list
                    Part part = context.Parts.Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = c,
                        Part = part
                    };

                    currentCarParts.Add(partCar);
                }

                c.PartCars = currentCarParts;
                cars.Add(c);

            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            const string root = "Customers";
            var customerDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);

            var customers = mapper.Map<IEnumerable<Customer>>(customerDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            const string root = "Sales";

            var salesDto = XmlConverter.Deserializer<SaleInputModel>(inputXml, root);
            var carIdList = context.Cars.Select(c => c.Id).ToList();
            var sales = mapper.Map<IEnumerable<Sale>>(salesDto).Where(x => carIdList.Contains(x.CarId));

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const int distance = 2_000_000;
            const string root = "cars";
            var cars = context.Cars
                .Where(x => x.TravelledDistance > distance)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            // default XML output
            //StringBuilder sb = new StringBuilder();
            //XmlSerializer xmlSerializer = GenerateXmlSerializer(root, typeof(CarOutputModel[]));
            //using StringWriter sw = new StringWriter(sb);
            //var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            //xmlSerializer.Serialize(sw, cars, namespaces);
            //return sb.ToString().TrimEnd();

            // XML output with XmlConverter class
            return XmlConverter.Serialize(cars, root);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string make = "BMW";
            const string root = "cars";

            var bmwCars = context.Cars
                .Where(x => x.Make == make)
                .Select(x => new BmwCarOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToArray();


            return XmlConverter.Serialize(bmwCars, root);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string root = "suppliers";
            var localSuppliers = context
                .Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Select(x => x.Quantity).Count(),
                })
                .ToArray();


            return XmlConverter.Serialize(localSuppliers, root);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string root = "cars";
            var carsWithParts = context
                .Cars
                .Select(x => new CarsWithPartsOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    PartList = x.PartCars.Select(y => new PartListOutputModel
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();
            return XmlConverter.Serialize(carsWithParts, root);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string root = "customers";
            var totalSalesByCustomer = context
                .Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new TotalSalesByCustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Select(c => c.Car).SelectMany(x => x.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            // SpentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(pc => pc.Part.Price))

            return XmlConverter.Serialize(totalSalesByCustomer, root);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string root = "sales";
            var salesWithAppliedDiscount = context
                .Sales
                .Select(x => new SalesWithAppliedDiscountOutputModel
                {
                    Car = new CarAttributeOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(pc => pc.Part.Price) -
                                        (x.Car.PartCars.Sum(pc => pc.Part.Price) * x.Discount / 100)
                })
                .ToArray();
            return XmlConverter.Serialize(salesWithAppliedDiscount, root);
        }


        private static XmlSerializer GenerateXmlSerializer(string rootName, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);
            return xmlSerializer;
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