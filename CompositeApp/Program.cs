using System;
using System.Collections.Generic;

namespace ComponentApp
{
    /// <summary>
    /// Component Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a tree structure
            Component computerSystem = new("Computer System");
            computerSystem.Add(new Device("Monitor"));
            computerSystem.Add(new Device("Keyboard"));
            computerSystem.Add(new Device("Mouse"));
            computerSystem.Add(new Device("Speakers"));

            Component motherBoard = new("Mother Board");
            motherBoard.Add(new Device("Ram"));
            motherBoard.Add(new Device("Hard Drive"));
            computerSystem.Add(motherBoard);
            // Add and remove a device

            Device device = new("Device D");
            computerSystem.Add(device);
            computerSystem.Remove(device);
            // Recursively display tree
            computerSystem.Display(1);
            // Wait for user
            Console.ReadKey();
        }
    }

    public abstract class ComputerDevice //Component
    {
        protected string name;

        // Constructor
        public ComputerDevice(string name)
        {
            this.name = name;
        }

        public abstract void Add(ComputerDevice computerDevice);
        public abstract void Remove(ComputerDevice computerDevice);
        public abstract void Display(int depth);
    }

    public class Component : ComputerDevice //Composite
    {
        List<ComputerDevice> computerDevices = new List<ComputerDevice>();

        // Constructor
        public Component(string name)
            : base(name) { }

        public override void Add(ComputerDevice computerDevice)
        {
            computerDevices.Add(computerDevice);
        }

        public override void Remove(ComputerDevice computerDevice)
        {
            computerDevices.Remove(computerDevice);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Recursively display child nodes
            foreach (ComputerDevice computerDevice in computerDevices)
            {
                computerDevice.Display(depth + 2);
            }
        }
    }

    public class Device : ComputerDevice //Leaf
    {
        // Constructor
        public Device(string name)
            : base(name) { }

        public override void Add(ComputerDevice c)
        {
            Console.WriteLine("Cannot add to a device");
        }

        public override void Remove(ComputerDevice c)
        {
            Console.WriteLine("Cannot remove from a device");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
