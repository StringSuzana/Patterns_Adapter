using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop = new Laptop("Legion 5");
            StandardEuSocket fTypeSocket = new StandardEuSocket();
            Charger.Charge(laptop, fTypeSocket);
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
