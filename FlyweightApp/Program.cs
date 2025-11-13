using System;
using System.Collections.Generic;

namespace FlyweightApp
{
    /// <summary>
    /// Flyweight Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Arbitrary extrinsic state
            AngryBirdFactory AngryBird = new AngryBirdFactory();
            // Work with different flyweight instances
            Flyweight RedAngryBird = AngryBird.GetColorFlyweight("red");
            RedAngryBird = AngryBird.GetColorFlyweight("red");
            Flyweight BlueAngryBird = AngryBird.GetColorFlyweight("blue");
            Flyweight YellowAngryBird = AngryBird.GetColorFlyweight("yellow");
            Flyweight BlackAngryBird = AngryBird.GetColorFlyweight("black");
        
            RedAngryBird.Operation(10);
            BlueAngryBird.Operation(20);
            BlackAngryBird.Operation(30);
            YellowAngryBird.Operation(40);
            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    public class AngryBirdFactory
    {
        private readonly Dictionary<string, Flyweight> AngryBirds = new();


        public Flyweight GetColorFlyweight(string color)
        {
            if (!AngryBirds.ContainsKey(color))
            {
                AngryBirds[color] = new ConcreteAngryBirdFlyweight(color);
                Console.WriteLine($"Created new AngryBird flyweight for color: {color}");
            }
            else
            {
                Console.WriteLine($"Reusing existing AngryBird flyweight for color: {color}");
            }

            return AngryBirds[color];
        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    /// <summary>
    /// The 'ConcreteAngryBirdFlyweight' class
    /// </summary>
    public class ConcreteAngryBirdFlyweight : Flyweight
    {

        private readonly string _color;

        public ConcreteAngryBirdFlyweight(string color)
        {
            _color = color;
        }
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"[{_color}] Angry Bird is flying at position {extrinsicstate}");
        }
    }

    /// <summary>
    /// The 'UnsharedConcreteAngryBirdFlyweight' class
    /// </summary>
    public class UnsharedConcreteAngryBirdFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"Unshared Angry Bird is flying at position {extrinsicstate}");
        }
    }
}
