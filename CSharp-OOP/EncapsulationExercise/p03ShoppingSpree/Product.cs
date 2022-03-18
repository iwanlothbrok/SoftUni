
using System;

namespace p03ShoppingSpree
{
    public class Product
    {
        
        private string name;
        private decimal price;

        public Product(string name,decimal price)
        {
            Name = name;
            Price = price;
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
                this.name = value;
            }
        }
        public decimal Price
        {
            get => this.price;
            set
            {
                if (value < Exceptions.MIN_NUM)
                {
                    throw new ArgumentException(String.Format(Exceptions.NEGATIVE_MONEY));
                }
                this.price = value;
            }
        }
       
    }
}
