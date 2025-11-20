using System;
namespace Memento.Structural
{
    /// <summary>
    /// Memento Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            TransactionManager o = new()
            {
                State = true
            };
            // Store internal state
            Table c = new()
            {
                Memento = o.CreateMemento()
            };
            // Continue changing TransactionManager Randomly
            o.State = new Random().Next(2) != 0;
            // Restore saved state
            o.SetMemento(c.Memento);
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'TransactionManager' class
    /// </summary>
    public class TransactionManager
    {
        private bool state;
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }
        // Creates memento
        public Memento CreateMemento()
        {
            return new Memento(state);
        }
        // Restores original state
        public void SetMemento(Memento memento)
        {
            if (state == false)
            {

                Console.WriteLine("Failure, Rollback state...");
                State = memento.State;
            }
            else
            {
                Console.WriteLine("Success, No need to rollback state.");
            }
        }
    }
    /// <summary>
    /// The 'Memento' class
    /// </summary>
    public class Memento(bool state)
    {
        readonly bool state = state;

        public bool State
        {
            get { return state; }
        }
    }
    /// <summary>
    /// The 'Table' class
    /// </summary>
    public class Table
    {
        Memento memento;
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
}
