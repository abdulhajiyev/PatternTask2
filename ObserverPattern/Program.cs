using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Product Laptop = new Product("HP", 1000);
            Console.WriteLine("Customer 1 and Customer 2 is subscribed to the laptop Product");


            Customer customer1 = new ("Customer 1");
            Laptop.Subscribe(customer1);


            Customer customer2 = new ("Customer 2");
            Laptop.Subscribe(customer2);
            Laptop.Price = 800;

            Console.WriteLine("Customer 2 is unsubscribed and customer 3 is subscribed to the laptop Product");

            Laptop.Unsubscribe(customer2);
            Customer customer3 = new ("Customer 3");
            Laptop.Subscribe(customer3);
            Laptop.Price = 900;
            Console.ReadLine();
        }
    }

    interface IProduct
    {
        void Subscribe(Customer customer);
        void Unsubscribe(Customer customer);
        void Notify();
    }

    public class Product : IProduct
    {
        float _basePrice;

        List<Customer> customers = new();

        public Product(string name, float basePrice)
        {
            Name = name;
            _basePrice = basePrice;
            CurrentPrice = basePrice;
        }

        public float Price
        {
            get => CurrentPrice;
            set
            {
                CurrentPrice = value;
                if (value <= _basePrice)
                    Notify();
            }
        }
        public void Subscribe(Customer customer)
        {
            customers.Add(customer);
        }

        public void Unsubscribe(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Notify()
        {
            foreach (Customer observer in customers)
            {
                observer.Update(this);
            }
        }

        public string Name { get; }

        public float Discount => (_basePrice - CurrentPrice) * 100 / _basePrice;

        public float CurrentPrice { get; private set; }
    }

    interface ICustomer
    {
        void Update(Product product);
    }

    public class Customer : ICustomer
    {
        string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public void Update(Product product)
        {
            Console.WriteLine($"{_name}: {product.Name} Laptop is now available at {product.CurrentPrice}; Discount = {product.Discount}%");
        }
    }
}
