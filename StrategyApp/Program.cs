using System;
namespace StrategyApp
{
    /// <summary>
    /// Strategy Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Context context;
            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
            // Wait for user
            Console.ReadKey();
        }
    }
    // l
    /// <summary>
    /// The 'Strategy' abstr
    /// </summary>
    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
            "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class Context(Strategy strategy)
    {
        readonly Strategy strategy = strategy;

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}