

using System;
using System.Collections.Generic;
using System.Linq;

namespace p03ShoppingSpree
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;
        public Engine()
        {
            persons = new List<Person>();
            products = new List<Product>();
        }
        public void Run()
        {
            string[] personArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                AddPerson(personArgs);
                AddProduct(productsArgs);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] tokens = cmd.Split(' ');
                string personName = tokens[0];
                string productName = tokens[1];
                try
                {
                    Person person = this.persons.First(n => n.Name == personName);
                    Product product = this.products.First(n => n.Name == productName);
                    person.BuyProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (ArgumentException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }


                cmd = Console.ReadLine();
            }
            persons.ForEach(p => Console.WriteLine(p));
        }


        private void AddProduct(string[] productsArgs)
        {
            for (int i = 0; i < productsArgs.Length; i++)
            {
                string[] tokens = productsArgs[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string nameOfProduct = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                Product product = new Product(nameOfProduct, price);
                products.Add(product);
            }
        }

        private void AddPerson(string[] personArgs)
        {
            for (int i = 0; i < personArgs.Length; i++)
            {
                string[] tokens = personArgs[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);
                Person person = new Person(name, money);
                persons.Add(person);
            }
        }
    }
}
