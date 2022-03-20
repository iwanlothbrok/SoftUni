
using System;
using System.Collections.Generic;
using System.Linq;

namespace p03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person()
        {
            bag = new List<Product>();
        }
        public Person(string name,decimal money)
            : this()
        {
            Name = name;
            Money = money;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(Exceptions.NAME_IS_INCORRECT));
                }
                name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < Exceptions.MIN_NUM)
                {
                    throw new ArgumentException(String.Format(Exceptions.NEGATIVE_MONEY));
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bags => this.bag.AsReadOnly();
        public void BuyProduct(Product product)
        {
            decimal currentMoney = Money;
            decimal currentCost = product.Price;

            if (currentMoney < currentCost)
            {
                throw new ArgumentException(string.Format(Exceptions.NOT_ENOUGHT_MONEY, Name, product.Name));
            }
            Money -= currentCost;
            bag.Add(product);

        }
        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.bag.Select(p => p.Name))}";
        }
    }
}
