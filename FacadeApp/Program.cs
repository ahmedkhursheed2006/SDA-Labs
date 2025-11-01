using System;
using System.Collections.Generic;

namespace FacadeApp
{
    class MainApp
    {
        static void Main()
        {
            Facade facade = new();
            facade.Bootup();
            facade.ShutDown();
            Console.ReadKey();
        }
    }

    public abstract class SubSystem
    {
        public abstract void Bootup();
        public abstract void ShutDown();
    }

    public class Ram : SubSystem
    {
        public override void Bootup()
        {
            Console.WriteLine("\nRam is Booting Up!");
        }

        public override void ShutDown()
        {
            Console.WriteLine("\nRam is Shutting Down!");
        }
    }

    public class Cpu : SubSystem
    {
        public override void Bootup()
        {
            Console.WriteLine("\nCPU is Booting Up!");
        }

        public override void ShutDown()
        {
            Console.WriteLine("\nCPU is Shutting Down!");
        }
    }

    public class Storage : SubSystem
    {
        public override void Bootup()
        {
            Console.WriteLine("\nHark Disk / SSD is Booting Up!");
        }

        public override void ShutDown()
        {
            Console.WriteLine("\nHark Disk / SSD is Shutting Down!");
        }
    }

    public class Facade : SubSystem
    {
        Ram ram;
        Cpu cpu;
        Storage storage;

        public Facade()
        {
            ram = new Ram();
            cpu = new Cpu();
            storage = new Storage();
        }

        public override void Bootup()
        {
            Console.WriteLine("\nFacade/System is Booting up!!");
            ram.Bootup();
            cpu.Bootup();
            storage.Bootup();
        }

        public override void ShutDown()
        {
            Console.WriteLine("\nFacade/System is Shutting Down!");
            ram.ShutDown();
            cpu.ShutDown();
            storage.ShutDown();
        }
    }
}
