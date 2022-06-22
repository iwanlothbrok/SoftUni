using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();
            var userJsonStringUsers = File.ReadAllText("../../../Datasets/users.json");
            var userJsonStringProducts = File.ReadAllText("../../../Datasets/products.json");
            var userJsonStringCategories = File.ReadAllText("../../../Datasets/categories.json");
            var userJsonStringCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            //var result = ImportUsers(db, userJsonStringUsers);//#1
            //var result1 = ImportProducts(db, userJsonStringProducts);//#2
            //var result2 = ImportCategories(db, userJsonStringCategories);//#3
            //var result = ImportCategoryProducts(db, userJsonStringCategoriesProducts);//#4
            //Console.WriteLine(GetProductsInRange(db));//#5
            //Console.WriteLine(GetSoldProducts(db));//#6
            //Console.WriteLine(GetCategoriesByProductsCount(db));//#7
            Console.WriteLine(GetUsersWithProducts(db));//#8
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersInfo = context.Users
                .Include(x=>x.ProductsSold)
                .ToList()
                .Where(p => p.ProductsSold.Any(a => a.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(a => a.BuyerId != null).Count(),
                        products = x.ProductsSold.Where(a => a.BuyerId != null).Select(pr => new
                        {
                            name = pr.Name,
                            price = pr.Price,
                        })
                    }
                }).OrderByDescending(b => b.soldProducts.products.Count()).ToList();

            var resultObj = new

            {
                usersCount = usersInfo.Count(),
                users = usersInfo
            };


            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(resultObj,Formatting.Indented,jsonSettings);

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)//#7
        {
            var categories = context.Categories.Select(ct => new
            {
                category = ct.Name,
                productCount = ct.CategoryProducts.Count(),
                averagePrice = ct.CategoryProducts.Count == 0 ?
                              0.ToString("f2") :
                              ct.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                totalRevenue = ct.CategoryProducts.Sum(p => p.Product.Price).ToString("f2"),
            }).OrderByDescending(c => c.productCount).ToList();


            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
        public static string GetSoldProducts(ProductShopContext context)//#6
        {
            var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .Select(x => new
            {
                firstName = x.FirstName,
                lastName = x.LastName,
                soldProducts = x.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                {
                    name = b.Name,
                    price = b.Price,
                    buyerFirstName = b.Buyer.FirstName,
                    buyerLastName = b.Buyer.LastName
                })
                .ToList()
            })
            .OrderBy(x => x.lastName)
            .ThenBy(x => x.firstName)
            .ToList();



            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }
        public static string GetProductsInRange(ProductShopContext context)//#5
        {
            var products = context.Products.Where(x => x.Price > 500 && x.Price < 1000)
                                           .Select(p => new
                                           {
                                               name = p.Name,
                                               price = p.Price,
                                               seller = p.Seller.FirstName + " " + p.Seller.LastName
                                           }).OrderBy(pr => pr.price).ToArray();



            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)//#4
        {
            InitializeMapper();
            var ctgProDtos = JsonConvert.DeserializeObject<List<CategoriesProductsDto>>(inputJson);

            var categoriesProducts = mapper.Map<List<CategoryProduct>>(ctgProDtos);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)//#3
        {
            InitializeMapper();

            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<CategoriesDto>>(inputJson)
                .Where(n => n.Name != null).ToList();

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();


            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)//#2
        {
            InitializeMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductsDto>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)//#1
        {
            InitializeMapper();

            var dtoUser = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUser);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}