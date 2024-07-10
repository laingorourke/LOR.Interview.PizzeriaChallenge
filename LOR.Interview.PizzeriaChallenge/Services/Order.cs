using System.Collections.Generic;
using PizzeriaChallenge.Interfaces;
using PizzeriaChallenge.Models;

namespace PizzeriaChallenge.Services
{
    public class Order
    {
        private List<IPizza> pizzas = [];
        private Store store;

        public Order(Store store)
        {
            this.store = store;
        }

        public void AddPizza(IPizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void ProcessOrder()
        {
            foreach (var pizza in pizzas)
            {
                pizza.Prepare();
                pizza.Bake();
                pizza.Cut();
                pizza.Box();
                pizza.PrintReceipt();
            }
        }
    }
}
