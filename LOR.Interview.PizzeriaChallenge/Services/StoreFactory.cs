using PizzeriaChallenge.Interfaces;
using PizzeriaChallenge.Models;

namespace PizzeriaChallenge.Services
{
    public static class StoreFactory
    {
        public static Store CreateStore(string location)
        {
            switch (location?.ToLower())
            {
                case "brisbane":
                    return new Store("Brisbane", new BrisbaneMenu());
                case "sydney":
                    return new Store("Sydney", new SydneyMenu());
                case "gold coast":
                    return new Store("Gold Coast", new GoldCoastMenu());
                default:
                    return null;
            }
        }
    }
}
