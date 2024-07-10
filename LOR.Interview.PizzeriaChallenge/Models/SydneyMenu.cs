using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;
using PizzeriaChallenge.Models;

namespace PizzeriaChallenge.Services
{
    public class SydneyMenu : IStoreMenu
    {
        private Dictionary<string, decimal> pizzaPrices = new Dictionary<string, decimal>
        {
            { "Capriciosa", 30 },
            { "Inferno", 31 }
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
                "Inferno" => "chili peppers, mozzarella, chicken, cheese",
                _ => string.Empty
            };
        }
    }
}
