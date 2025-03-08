using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUSV_piu
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("BMW","520d","New BMW 5 series.",53200,new Engine("Diesel",400f,190f,"4 Cylinder Inline"),"520d RWD",new string[] {"Head-Up Display","LED Light", "Traffic Jam", "Keyless Go","Leather Seats"});
            
            Console.WriteLine($"Car {c1.GetFullName()} has {c1.Engine.MaxHP} horsepower and {c1.Engine.MaxTorque} N*M. It sells at price {c1.Price}$.");

            Console.ReadKey();
        }
    }
}
