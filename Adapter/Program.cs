using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop = new Laptop("Legion 5");
            StandardEuSocket euTypeSocket = new StandardEuSocket();
            Charger.Charge(laptop, euTypeSocket);

            /**
             * I added GB type socket and want to charge my laptop that has a EU type plug.
             * 
             * The problem: 
             * Without changing Charger class I need to make adjustments in program and 
             * demonstrate how to charge Laptop using GB type of socket.
             * 
             * I implemented GB to EU adapter. 
             * GbToEuAdapter implements the interface of a Class that I want to adapt to.
             * (So that it can have all the methods I need)
             * Adapter class takes in the constructor an object that needs to be adapted/wrapped
             * Then in my adapter class I can do what ever it takes to make the GB Socket class work with 
             * my Charger exactly like my EU Socket class does.
             */

            IEuSocket wrappedGbSocket = new GbToEuAdapter(new StandardGbSocket());
            Charger.Charge(laptop, wrappedGbSocket);
        }
    }
    public interface IEuSocket
    {
        string giveEuCurrent();
    }
    public class StandardEuSocket : IEuSocket
    {
        public string giveEuCurrent()
        {
            return "current from EU socket";
        }
    }
    public interface IGbSocket
    {
        public string giveGbCurrent();
    }
    public class StandardGbSocket : IGbSocket
    {
        public string giveGbCurrent()
        {
            return "current from GB socket";
        }
    }
    public class GbToEuAdapter : IEuSocket
    {
        private readonly IGbSocket gbSocket;
        public GbToEuAdapter(IGbSocket gbSocket)
        {
            this.gbSocket = gbSocket;
        }
        public string giveEuCurrent()
        {
            return $" {gbSocket.giveGbCurrent()}. (Poked the earth pin hole and made it work like eu socket.) ";
        }
    }
    public class Laptop
    {
        private string Name;
        public Laptop(string name)
        {
            this.Name = name;
        }
        public string getName()
        {
            return this.Name;
        }
    }
    public static class Charger
    {
        public static void Charge(Laptop laptop, IEuSocket socket)
        {
            Console.WriteLine($"Charging laptop {laptop.getName()} with {socket.giveEuCurrent()}.");
        }
    }

}
