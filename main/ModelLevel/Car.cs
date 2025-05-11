

using System;
using System.Collections.Generic;

namespace ProjectUSV_piu
{
    public class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public string Color { get; private set; }
        public VehicleType Type { get; private set; }
        public string VIN { get; private set; }

        public int Year { get; private set; }

        public bool isAvailable { get; set; }
        
        public bool isUsed { get; protected set; }
        public string Complectation {  get; private set; }

        public List<Product> AddOptions { get; protected set; }

        public GeneralOptions Options;

        public int kmOnBoard { get; private set; }

        public Car(Car basic, string complectation, int price, string color, Engine engine, int year, GeneralOptions options, Product[] addOptions) : base(basic.ProducerCompany, basic.Description, price)
        {
            Model = basic.Model;
            Engine = engine;
            Year = year;
            Options = options;
            if (addOptions != null)
            {
                AddOptions = new List<Product>(addOptions);
            }
            else
            {
                AddOptions = new List<Product>();
            }
            Color = color;
            Options = options;
            VIN = VINGetter.GetNewVIN();
        }
    
        public Car(string company, string description, int price, int year, bool available, string model, string VIN, int kmOnBoard, Engine engine, string complectation, string color, VehicleType type, GeneralOptions options, Product[] addOptions) : base(company,description,price)
        {
            isAvailable = available;
            AddOptions = new List<Product>();
            Year = year;
            Model = model;
            Engine = engine;
            Type = type;
            Complectation = complectation;
            this.VIN = VIN;
            this.kmOnBoard = kmOnBoard;
            Options = options;
            Color = color;
            if(addOptions != null)
            {
                AddOptions = new List<Product>(addOptions);
            }
            

            if (kmOnBoard < 10)
                isUsed = false;
            else
                isUsed = true;
        }

       
        public void EditPrice(int price)
        {
            this.Price = price;
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
