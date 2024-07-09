using System.Collections.Generic;

namespace LOR.Interview.PizzeriaChallenge.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to LOR Pizzeria! Please select the store location: Brisbane OR Sydney");
            var Store = System.Console.ReadLine();

            System.Console.WriteLine("MENU");
            if (Store == "Brisbane")
            {
                System.Console.WriteLine("Capriciosa - mushrooms, cheese, ham, mozarella - 20 AUD");
                System.Console.WriteLine("Florenza - olives, pastrami, mozarella, onion - 21 AUD");
                System.Console.WriteLine("Margherita - mozarella, onion, garlic, oregano - 22 AUD");
            }
            else if (Store == "Sydney")
            {
                System.Console.WriteLine("Capriciosa - mushrooms, cheese, ham, mozarella - 30 AUD");
                System.Console.WriteLine("Inferno - chili peppers, mozzarella, chicken, cheese - 31 AUD");
            }



            System.Console.WriteLine("What can I get you?");

            var pizzaType = System.Console.ReadLine();


            var pizza = new Pizza();
            switch(pizzaType)
            {
                case "Capriciosa":
                    var capriciosaPrice = 0;
                    if (Store == "Brisbane") capriciosaPrice = 20;
                    if (Store == "Sydney") capriciosaPrice = 30;

                    pizza = new Pizza(){ Name = "Capriciosa", Ingredients = new List<string>{ "mushrooms", "cheese", "ham", "mozarella" }, BasePrice = capriciosaPrice};
                    break;
                case "Florenza":
                    pizza = new Pizza() { Name = "Florenza", Ingredients = new List<string> { "olives", "pastrami", "mozarella", "onion" }, BasePrice = 21};
                    break;
                case "Margherita":
                    pizza = new Pizza() { Name = "Margherita", Ingredients = new List<string> { "mozarella", "onion", "garlic", "oregano" }, BasePrice = 22};
                    break;
                case "Inferno":
                    pizza = new Pizza() { Name = "Inferno", Ingredients = new List<string> { "chili peppers", "mozzarella", "chicken", "cheese" }, BasePrice = 31};
                    break;
                default:
                    break;
            }
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            pizza.PrintReceipt();

            System.Console.WriteLine("\nYour pizza is ready!");
        }
    }

    public class Pizza
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal BasePrice { get; set; }

        public void Prepare()
        {
            System.Console.WriteLine("Preparing " + Name + "...");
            System.Console.Write("Adding ");
            foreach (var i in Ingredients)
            {
                System.Console.Write(i + " ");
            }
            System.Console.WriteLine();
        }

        public void Bake()
        {
            if(Name == "Margherita")
            System.Console.WriteLine("Baking pizza for 15 minutes at 200 degrees...");
            else
            {
                System.Console.WriteLine("Baking pizza for 30 minutes at 200 degrees...");
            }
        }

        public void Cut()
        {
            if (Name == "Florenza")
                System.Console.WriteLine("Cutting pizza into 6 slices with a special knife...");
            else
            {
                System.Console.WriteLine("Cutting pizza into 8 slices...");
            }
        }

        public void Box()
        {
            System.Console.WriteLine("Putting pizza into a nice box...");
        }


        public void PrintReceipt()
        {
            System.Console.WriteLine("Total price: " + BasePrice);
        }
    }
}
