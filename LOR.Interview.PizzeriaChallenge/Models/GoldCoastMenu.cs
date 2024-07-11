using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;
using PizzeriaChallenge.Models;

namespace PizzeriaChallenge.Services
{
    public class GoldCoastMenu : IStoreMenu
    {
        private Dictionary<string, decimal> pizzaPrices = new Dictionary<string, decimal>
        {
            { "Capriciosa", 25 },
            { "Florenza", 26 },
            { "Margherita", 27 },
            { "Inferno", 28 }
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
                "Inferno" => new List<string> { "chili peppers", "mozzarella", "chicken", "cheese" },
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
                "Inferno" => "chili peppers, mozzarella, chicken, cheese",
                _ => string.Empty
            };
        }
    }
}
