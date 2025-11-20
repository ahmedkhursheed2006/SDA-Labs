using System;


namespace ObserverApp
{

    class Program
    {
        public static void Main()
        {
            ConcreteSubject subject = new();

            ConcreteObserver PieChart = new(subject, "Pie Chart");
            ConcreteObserver BarChart = new(subject, "Bar Chart");

            subject.Attach(PieChart);
            subject.Attach(BarChart);

            int newData = new Random().Next(1, 100);

            subject.SubjectState = newData.ToString();
            subject.Notify();
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public class ConcreteObserver(ConcreteSubject subject, string name) : Observer
    {
        private string name = name;
        private string observerState;
        private ConcreteSubject subject = subject;

        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine($"Observer {name} updated with new state: {observerState}");
        }

        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }

    public class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        private string subjectState;

        public string SubjectState
        {
            get { return subjectState; }
            set
            {
                subjectState = value;
            }
        }
    }
}