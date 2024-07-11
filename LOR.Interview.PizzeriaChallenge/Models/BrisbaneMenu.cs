using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;
using PizzeriaChallenge.Models;

namespace PizzeriaChallenge.Services
{
    public class BrisbaneMenu : IStoreMenu
    {
        private Dictionary<string, decimal> pizzaPrices = new Dictionary<string, decimal>
        {
            { "Capriciosa", 20 },
            { "Florenza", 21 },
            { "Margherita", 22 }
        };

        public void DisplayMenu()
        {
            foreach (var item in pizzaPrices)
            {
                System.Console.WriteLine($"{item.Key} - {GetIngredients(item.Key)} - {item.Value} AUD");
            }
        }

        public IPizza CreatePizza(string pizzaType)
        {
            if (!pizzaPrices.ContainsKey(pizzaType))
                return null;

            var ingredients = pizzaType switch
            {
                "Capriciosa" => new List<string> { "mushrooms", "cheese", "ham", "mozzarella" },
                "Florenza" => new List<string> { "olives", "pastrami", "mozzarella", "onion" },
                "Margherita" => new List<string> { "mozzarella", "onion", "garlic", "oregano" },
                _ => null
            };

            return new Pizza(pizzaType, ingredients, pizzaPrices[pizzaType], new StandardBakingStrategy());
        }

        private string GetIngredients(string pizzaType)
        {
            return pizzaType switch
            {
                "Capriciosa" => "mushrooms, cheese, ham, mozzarella",
                "Florenza" => "olives, pastrami, mozzarella, onion",
                "Margherita" => "mozzarella, onion, garlic, oregano",
                _ => string.Empty
            };
        }
    }
}
