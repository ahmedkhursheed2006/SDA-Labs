using System;
using System.Collections.Generic;

namespace AdapterApp
{
    class MainApp
    {
        static void Main()
        {
            TwoPinSocket twoPinSocket = new SocketAdapter(); //Target targetVariable = new AdapterClass();
            twoPinSocket.ProvidePower();
            Console.ReadKey();
        }
    }

    // Target Class
    public class TwoPinSocket
    {
        public virtual void ProvidePower()
        {
            Console.WriteLine("Power provided through two pin plug");
        }
    }

    // Adaptee Class
    public class ThreeToTwoPinAdapter
    {
        public void ConnectThreePinPlug()
        {
            Console.WriteLine("Three pin plug connected to Adapter");
        }
    }

    // Adapter Class
    public class SocketAdapter : TwoPinSocket
    {
        private ThreeToTwoPinAdapter threeToTwoPinAdapter = new();

        public override void ProvidePower()
        {
            threeToTwoPinAdapter.ConnectThreePinPlug();
            Console.WriteLine("Power provided through three pin to two pin adapter");
        }
    }
}
