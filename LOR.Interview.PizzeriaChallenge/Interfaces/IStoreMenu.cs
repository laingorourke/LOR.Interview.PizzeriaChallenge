namespace PizzeriaChallenge.Interfaces
{
    public interface IStoreMenu
    {
        void DisplayMenu();
        IPizza CreatePizza(string pizzaType);
    }
}
