

namespace ProjectUSV_piu
{
    public class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public VehicleType Type { get; private set; }
        public string VIN { get; private set; }

        public int Year { get; private set; }
        
        public bool isSold { get; protected set; }
        public string Complectation {  get; private set; }

        public Product[] AddOptions { get; protected set; }

        public GeneralOptions Options;

        public int kmOnBoard { get; private set; }
        public Car(string company,string description,int price,int year, string model,string VIN, int kmOnBoard, Engine engine, string complectation,VehicleType type,GeneralOptions options, Product[] addOptions) : base(company,description,price)
        {
            Year = year;
            Model = model;
            Engine = engine;
            Type = type;
            Complectation = complectation;
            this.VIN = VIN;
            Options = options;
            if(addOptions != null)
            {
                AddOptions = new Product[addOptions.Length];
                AddOptions.CopyTo(addOptions, 0);
            }
            

            if (kmOnBoard < 10)
                isSold = false;
            else
                isSold = true;
        }

        public Car(Car basicCar, Engine engine, int price,string complectation, Product[] options):base(basicCar.ProducerCompany,basicCar.Description,price) 
        {
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

            isSold = false;
        }
        public virtual string GetFullName()
        {
            return $"{ProducerCompany} {Model}";
        }

    }
}
