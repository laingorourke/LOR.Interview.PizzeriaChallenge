using System.Collections.Generic;

namespace PizzeriaChallenge.Interfaces
{
    public interface IPizza
    {
        string Name { get; }
        List<string> Ingredients { get; }
        decimal BasePrice { get; set; }

        void AddTopping(string topping);
        void Prepare();
        void Bake();
        void Cut();
        void Box();
        void PrintReceipt();
    }
}
