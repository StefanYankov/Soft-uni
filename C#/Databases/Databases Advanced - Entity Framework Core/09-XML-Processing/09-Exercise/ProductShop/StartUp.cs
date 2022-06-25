using AutoMapper;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main()
        {
            var productShopContext = new ProductShopContext();

            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();

            //// Part one - Import data
            //// Problem 01 - Import users

            //var inputXmlUsers = File.ReadAllText("../../../Datasets/users.xml");
            //var resultUsers = ImportUsers(productShopContext, inputXmlUsers);
            ////Console.WriteLine(resultUsers);

            //// Problem 02 - Import Products
            //var inputXmlProducts = File.ReadAllText("../../../Datasets/products.xml");
            //var resultProducts = ImportProducts(productShopContext, inputXmlProducts);
            ////Console.WriteLine(resultProducts);

            //// Problem 03 - Import Categories
            //var inputXmlCategories = File.ReadAllText("../../../Datasets/categories.xml");
            //var resultCategories = ImportCategories(productShopContext, inputXmlCategories);
            ////Console.WriteLine(resultCategories);

            //// Problem 04 - Import Categories and Products
            //var inputXmlCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var resultCategoriesProducts = ImportCategoryProducts(productShopContext, inputXmlCategoriesProducts);
            ////Console.WriteLine(resultCategoriesProducts);

            // Part two - Query and Export Data
            // Problem 05 - Export products in range
            // Console.WriteLine(GetProductsInRange(productShopContext));

            // Problem 06 - Export Successfully Sold Products
            // Console.WriteLine(GetSoldProducts(productShopContext));

            // Problem 07 - Export Categories by Products Count
            // Console.WriteLine(GetCategoriesByProductsCount(productShopContext));

            // Problem 08 - Export Users and Products
            // Console.WriteLine(GetUsersWithProducts(productShopContext));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var dtoUsers = (UserInputModel[])xmlSerializer.Deserialize(stringReader);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlRoot = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), xmlRoot);

            using var stringReader = new StringReader(inputXml);

            var dotProducts = (ProductInputModel[])xmlSerializer.Deserialize(stringReader);

            var products = mapper.Map<IEnumerable<Product>>(dotProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlRoot = new XmlRootAttribute("Categories");
            var xmlSerializer = new XmlSerializer(typeof(CategoriyInputModel[]), xmlRoot);

            using var stringReader = new StringReader(inputXml);

            var dotCategories = (CategoriyInputModel[])xmlSerializer.Deserialize(stringReader);

            var categories = mapper.Map<IEnumerable<Category>>(dotCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var xmlRoot = new XmlRootAttribute("CategoryProducts");
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductInputModel[]), xmlRoot);

            using var stringReader = new StringReader(inputXml);

            var dotCategoriesProducts = (CategoryProductInputModel[])xmlSerializer.Deserialize(stringReader);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dotCategoriesProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            int bottomRange = 500;
            int topRange = 1000;
            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Products", typeof(ExportProductsInRangeDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var productsInRangeDtos = context
                .Products
                .Where(p => p.Price >= bottomRange && p.Price <= topRange)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(x => new ExportProductsInRangeDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .ToArray();

            xmlSerializer.Serialize(sw, productsInRangeDtos, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Users", typeof(ExportSoldProductsDto[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var usersDto = context
                .Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new ExportSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(p => new ExportProductInfoDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(sw, usersDto, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);

            XmlSerializer xmlSerializer = GenerateXmlSerializer("Categories", typeof(ExportCategoriesByProductsCount[]));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var categoriesDto = context
                .Categories
                .Select(x => new ExportCategoriesByProductsCount
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price),
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            xmlSerializer.Serialize(sw, categoriesDto, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Take(10)
                .Select(u => new UserInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    ProductsSold = new SoldProductsDto
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .OrderByDescending(p => p.Price)
                            .Select(p => new ProductInfoDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                    }
                })
                .ToArray();

            var usersAndProducts = new UsersOutputDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersWithProducts
            };

            var rootAttribute = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(UsersOutputDto), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, usersAndProducts, namespaces);

            return sb.ToString().TrimEnd();
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
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }

    }
}