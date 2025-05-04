

using System;

namespace ProjectUSV_piu
{
    public class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public VehicleType Type { get; private set; }
        public string VIN { get; private set; }

        public int Year { get; private set; }

        public bool isAvailable { get; private set; }
        
        public bool isUsed { get; protected set; }
        public string Complectation {  get; private set; }

        public Product[] AddOptions { get; protected set; }

        public GeneralOptions Options;

        public int kmOnBoard { get; private set; }
        public Car(string company,string description,int price,int year,bool available, string model,string VIN, int kmOnBoard, Engine engine, string complectation,VehicleType type,GeneralOptions options, Product[] addOptions) : base(company,description,price)
        {
            isAvailable = available;
            Year = year;
            Model = model;
            Engine = engine;
            Type = type;
            Complectation = complectation;
            this.VIN = VIN;
            this.kmOnBoard = kmOnBoard;
            Options = options;
            if(addOptions != null)
            {
                AddOptions = new Product[addOptions.Length];
                AddOptions.CopyTo(addOptions, 0);
            }
            

            if (kmOnBoard < 10)
                isUsed = false;
            else
                isUsed = true;
        }

        public Car(Car basicCar, Engine engine, int price,string complectation, Product[] options):base(basicCar.ProducerCompany,basicCar.Description,price) //used by Constructor
        {
            isAvailable = false;
            Model=basicCar.Model;
            Engine = engine;
            VIN = VINandTime.GetNewVIN();
            Year = basicCar.Year;
            Options = basicCar.Options;
            Type = basicCar.Type;
            Complectation = complectation;
            if (options != null)
            {
                AddOptions = new Product[options.Length];
                AddOptions.CopyTo(options, 0);
            }

            isUsed = false;
        }
        public virtual string GetFullName()
        {
            return $"{ProducerCompany} {Model}";
        }

        public string GetBasicOptions()
        {
            string selected = "";
            foreach (GeneralOptions opt in Enum.GetValues(typeof(GeneralOptions)))
            {
                if (opt != 0 && Options.HasFlag(opt))
                {
                    selected += opt + ",";
                }
            }
            return selected;
        }

        public string GetAddOptions() 
        { 
            string s = string.Empty;
            if(AddOptions == null)
                return s;
            foreach (var item in AddOptions)
            {
                s += item.Description + ",";
            }
            return s;

        }

    }
}
