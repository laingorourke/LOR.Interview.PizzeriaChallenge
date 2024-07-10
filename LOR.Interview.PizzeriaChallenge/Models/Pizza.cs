using System;
using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;

namespace PizzeriaChallenge.Models
{
    public class Pizza : IPizza
    {
        public string Name { get; }
        public List<string> Ingredients { get; }
        public decimal BasePrice { get; set; }
        public IBakingStrategy BakingStrategy { get; }

        public Pizza(string name, List<string> ingredients, decimal basePrice, IBakingStrategy bakingStrategy)
        {
            Name = name;
            Ingredients = ingredients;
            BasePrice = basePrice;
            BakingStrategy = bakingStrategy;
        }

        public void AddTopping(string topping)
        {
            Ingredients.Add(topping);
        }

        public void Prepare()
        {
            Console.WriteLine("Preparing " + Name + "...");
            Console.Write("Adding ");
            foreach (var ingredient in Ingredients)
            {
                Console.Write(ingredient + " ");
            }
            Console.WriteLine();
        }

        public void Bake()
        {
            BakingStrategy.Bake(Name);
        }

        public void Cut()
        {
            if (Name == "Florenza")
                Console.WriteLine("Cutting pizza into 6 slices with a special knife...");
            else
                Console.WriteLine("Cutting pizza into 8 slices...");
        }

        public void Box()
        {
            Console.WriteLine("Putting pizza into a nice box...");
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Total price: " + BasePrice + " AUD");
        }
    }
}
