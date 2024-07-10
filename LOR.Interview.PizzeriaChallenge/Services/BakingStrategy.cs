using System;
using PizzeriaChallenge.Interfaces;

namespace PizzeriaChallenge.Services
{
    public class StandardBakingStrategy : IBakingStrategy
    {
        public void Bake(string pizzaName)
        {
            if (pizzaName == "Margherita")
                Console.WriteLine("Baking pizza for 15 minutes at 200 degrees...");
            else
                Console.WriteLine("Baking pizza for 30 minutes at 200 degrees...");
        }
    }
}
