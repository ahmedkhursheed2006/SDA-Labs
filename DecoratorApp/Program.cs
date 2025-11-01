using System;

namespace DecoratorApp
{
    public class Program
    {
        public static void Main()
        {
            PlainPizza plainPizza = new();
            ChickenBarbeque chickenBarbeque = new();
            GrilledChicken grilledChicken = new();
            chickenBarbeque.SetComponent(plainPizza);
            grilledChicken.SetComponent(chickenBarbeque);
            grilledChicken.Operation();
            // Wait for user
            Console.ReadKey();
        }
    }

    public abstract class Pizza //Component
    {
        public abstract void Operation();
    }

    public class PlainPizza : Pizza //ConcreteComponent
    {
        public override void Operation()
        {
            Console.WriteLine("PlainPizza.Operation()");
        }
    }

    public abstract class Toppings : Pizza //Decorator
    {
        protected Pizza pizza;

        public void SetComponent(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override void Operation()
        {
            if (pizza != null)
            {
                pizza.Operation();
            }
        }
    }

    public class ChickenBarbeque : Toppings //ConcreteDecorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ChickenBarbeque.Operation()");
        }
    }

    public class GrilledChicken : Toppings //ConcreteDecorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("GrilledChicken.Operation()");
        }
    }
}
