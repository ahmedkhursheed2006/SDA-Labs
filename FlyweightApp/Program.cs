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
            AngryBirdFactory AngryBird = new();
            // Work with different flyweight instances
            Flyweight ColouredAngryBird = new();
            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    public class AngryBirdFactory
    {
        private Dictionary<string, Flyweight> AngryBirds { get; set; } = [];

        // Constructor
        public AngryBirdFactory()
        {
            AngryBirds.Add("red", new ConcreteAngryBirdFlyweight());
            AngryBirds.Add("blue", new ConcreteAngryBirdFlyweight());
            AngryBirds.Add("yellow", new ConcreteAngryBirdFlyweight());
        }

        public Flyweight GetColorFlyweight(string key)
        {
            return AngryBirds[key];
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
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteAngryBirdFlyweight: " + extrinsicstate);
        }
    }

    /// <summary>
    /// The 'UnsharedConcreteAngryBirdFlyweight' class
    /// </summary>
    public class UnsharedConcreteAngryBirdFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteAngryBirdFlyweight: " + extrinsicstate);
        }
    }
}
