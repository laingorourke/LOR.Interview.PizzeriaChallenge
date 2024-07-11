using PizzeriaChallenge.Interfaces;

namespace PizzeriaChallenge.Models
{
    public class Store
    {
        public string Location { get; }
        public IStoreMenu Menu { get; }

        public Store(string location, IStoreMenu menu)
        {
            Location = location;
            Menu = menu;
        }
    }
}
