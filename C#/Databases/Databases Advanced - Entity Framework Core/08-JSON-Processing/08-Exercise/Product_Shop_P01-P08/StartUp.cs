using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            /*productShopContext.Database.EnsureDeleted();
            productShopContext.Database.EnsureCreated();

            // Part one - Import data
            // Problem 01 - import users
            var inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            var resultUsers = ImportUsers(productShopContext, inputJsonUsers);

            // Problem 02 - import products
            var inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            var resultProducts = ImportProducts(productShopContext, inputJsonProducts);

            // Problem 03 - import categories
            var inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            var resultCategories = ImportCategories(productShopContext, inputJsonCategories);

            // Problem 04 - import categories and Products
            var inputJsonCategoriesAndProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            var resultCategoriesAndProducts = ImportCategoryProducts(productShopContext, inputJsonCategoriesAndProducts);*/

            // Part two - Export data
            // Problem 05 - Export products in range
            // Console.WriteLine(GetProductsInRange(productShopContext));

            // Problem 06 - Export Successfully Sold Products
            // Console.WriteLine(GetSoldProducts(productShopContext));

            // Problem 07 - Export Categories by Products Count
            // Console.WriteLine(GetCategoriesByProductsCount(productShopContext));

            // Problem 08 - Export Users and Products
            // Console.WriteLine(GetUsersWithProducts(productShopContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();
            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();
            var dtoCategoriesProducts = JsonConvert
                .DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            int bottomRange = 500;
            int topRange = 1000;
            var products = context
                .Products
                .Where(x => x.Price >= bottomRange && x.Price <= topRange)
                .OrderBy(x => x.Price)
                .Select( x => new
                {
                    x.Name,
                    x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToArray();


            string productsJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, 
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            });

            return productsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            /*var soldProducts = context
                .Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            p.Buyer.FirstName,
                            p.Buyer.LastName,

                        })
                        .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToArray();

            string soldProductsJson = JsonConvert.SerializeObject(soldProducts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            });

            return soldProductsJson;*/

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(user => new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    soldProducts = user.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                        {
                            name = b.Name,
                            price = b.Price,
                            buyerFirstName = b.Buyer.FirstName,
                            buyerLastName = b.Buyer.LastName,
                        })
                        .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);
            return result;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .OrderByDescending(x => x.productsCount)
                .ToArray();

            string categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return categoriesJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(ps => ps.BuyerId != null),
                        Products = x.ProductsSold
                            .Where(b => b.BuyerId != null)
                            .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Products.Count())
                .ToArray();

            var outputObject = new
            {
                UsersCount = context.Users.Count(x => x.ProductsSold.Any(b => b.BuyerId != null)),
                Users = users,
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
            };



            return JsonConvert.SerializeObject(outputObject,jsonSerializerSettings);
        }

        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}