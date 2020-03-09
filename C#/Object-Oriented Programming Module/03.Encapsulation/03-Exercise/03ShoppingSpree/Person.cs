using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public List<Product> Bag
        {
            get => this.bag;
            private set => this.bag = value;
        }

        public string Buy(Product product)
        {
            if (this.Money - product.Cost >= 0m)
            {
                this.Money -= product.Cost;
                this.Bag.Add(product);
                return $"{this.name} bought {product.Name}";
            }
            else
            {
                return $"{this.name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.bag.Count == 0)
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }
            else
            {
                List<string> productsNames = new List<string>();

                this.bag.ForEach(p => productsNames.Add(p.Name));

                sb.Append($"{this.Name} - {string.Join(", ", productsNames)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}