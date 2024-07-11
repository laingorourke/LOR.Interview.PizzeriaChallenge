using System;
using PizzeriaChallenge.Models;
using PizzeriaChallenge.Services;
using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;

namespace PizzeriaChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string storeLocation;
            Store store;

            // Prompt for valid store location
            while (true)
            {
                Console.WriteLine("Welcome to LOR Pizzeria! Please select the store location: Brisbane, Sydney, or Gold Coast");
                storeLocation = Console.ReadLine();

                store = StoreFactory.CreateStore(storeLocation);
                if (store != null)
                {
                    break;
                }
                Console.WriteLine("Invalid store location. Please try again.");
            }

            Console.WriteLine("MENU");
            store.Menu.DisplayMenu();

            int pizzaCount;
            // Prompt for valid number of pizzas
            while (true)
            {
                Console.WriteLine("How many pizzas would you like to order?");
                if (int.TryParse(Console.ReadLine(), out pizzaCount) && pizzaCount > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid number of pizzas. Please enter a positive number.");
            }

            var order = new Order(store);
            for (int i = 0; i < pizzaCount; i++)
            {
                IPizza pizza = null;
                // Prompt for valid pizza type
                while (pizza == null)
                {
                    Console.WriteLine($"What can I get you for pizza #{i + 1}?");
                    var pizzaType = Console.ReadLine();
                    pizza = store.Menu.CreatePizza(pizzaType);
                    if (pizza == null)
                    {
                        Console.WriteLine("Invalid pizza type. Please try again.");
                    }
                }

                Console.WriteLine("Would you like any extra toppings? (yes/no)");
                var extraToppingsResponse = Console.ReadLine();
                if (extraToppingsResponse?.ToLower() == "yes")
                {
                    pizza = AddExtraToppings(pizza);
                }

                order.AddPizza(pizza);
            }

            order.ProcessOrder();

            Console.WriteLine("\nYour order is ready!");
        }

        static IPizza AddExtraToppings(IPizza pizza)
        {
            var toppingPrices = new Dictionary<string, decimal>
            {
                { "Extra Cheese", 2.00m },
                { "Mayo", 1.50m },
                { "Olive Oil", 1.00m }
            };

            Console.WriteLine("Available toppings: Extra Cheese (2.00 AUD), Mayo (1.50 AUD), Olive Oil (1.00 AUD)");
            Console.WriteLine("Please enter the toppings you want, separated by commas:");

            var toppings = Console.ReadLine().Split(',');
            foreach (var topping in toppings)
            {
                var trimmedTopping = topping.Trim();
                if (toppingPrices.ContainsKey(trimmedTopping))
                {
                    pizza.AddTopping(trimmedTopping);
                    pizza.BasePrice += toppingPrices[trimmedTopping];
                }
                else
                {
                    Console.WriteLine($"Invalid topping: {trimmedTopping}. It will not be added.");
                }
            }

            return pizza;
        }
    }
}
