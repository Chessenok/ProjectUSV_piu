using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUSV_piu
{

    internal class Program
    {
        static FactoryBMW factory = new FactoryBMW();
        static Administrate_BMW_File admin = new Administrate_BMW_File("BmwDealer.txt", factory);
        
        static void Main(string[] args)
        {
            Console.WriteLine("loading zionist project");
            string x;
            do
            {
                GetAvailableCars();
                Console.WriteLine("Select option: \n A.Show available complectations for BMW 5 series \n B. Build a new 5 series \n C. Show all saved cars \n D. Show all available options \n E. Show available complectations for 3 series \n F. Build a new 3 series. \n X. Exit");
                x = Console.ReadLine();
                switch (x)
                {
                    case "A":
                        GetCompletations5Series();
                        break;
                    case "B":
                        BuildAndSave5Series();
                        break;
                    case "F":
                        BuildAndSave3Series();
                        break;
                    case "C":
                        GetAvailableCars();
                        break;
                    case "D":
                        GetOptions();
                        break;
                    case "E":
                        GetCompletations3Series();
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Unknown option");
                        break;

                }
            } while (x != "X" || x != "x");
            
            
        }

        public static void BuildAndSave5Series()
        {
            Console.WriteLine("Type complectation for car (example: 520d)");
            string completation = Console.ReadLine();
            string s;
            /*do
            {
                Console.WriteLine("Add options for car:");
                s = Console.ReadLine();

            }while ( s == "X"|| s == "x")*/ //this is will be later implemented

            admin.AddCar(factory.BuildNew5Series(completation, null));
            Console.WriteLine("Car added!");
        }       
        public static void BuildAndSave3Series()
        {
            Console.WriteLine("Type complectation for car (example: 320d)");
            string completation = Console.ReadLine();
            admin.AddCar(factory.BuildNew3Series(completation, null));
            Console.WriteLine("Car added!");
        }

        public static void GetAvailableCars()
        {
            Console.WriteLine("Available Cars: \n");
            int i = 0;
            Car[] cars = admin.GetAllCars();
            foreach (Car car in cars)
            {
                i++;
                Console.WriteLine($"{i}.{car.ProducerCompany} {car.Model} with {car.Engine.FuelType} engine.VIN:{car.VIN}");
            }
        }

        public static void GetCompletations5Series()
        {
            List<string> str = factory.GetAllComplectationsForDescription("G30");
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }
        }          
        public static void GetCompletations3Series()
        {
            List<string> str = factory.GetAllComplectationsForDescription("G20");
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }
        }        
        public static void GetOptions()
        {
            List<string> str = factory.GetAllOptions();
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }
        }
    }
}
