
using System;

namespace p04PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');
                string pizzaName = pizzaInfo[1];
                string[] doughtInfo = Console.ReadLine().Split(' ');
                string flourType = doughtInfo[1];
                string toppingType = doughtInfo[2];
                int weight = int.Parse(doughtInfo[3]);
                Dough dough = new Dough(flourType, toppingType, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string cmd = Console.ReadLine();

                while (cmd != "END")
                {
                    string[] tokens = cmd.Split(' ');
                    string toppingName = tokens[1];
                    int weightTopping = int.Parse(tokens[2]);
                    Topping topping = new Topping(toppingName, weightTopping);
                   pizza.AddToppings(topping);
                    cmd = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
}
