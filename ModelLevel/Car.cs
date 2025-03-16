

namespace ProjectUSV_piu
{
    public class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public string VIN { get; private set; }

        public int Year { get; private set; }
        
        public bool isSold { get; protected set; }
        public string Complectation {  get; private set; }

        public Product[] Options { get; protected set; }

        public int kmOnBoard { get; private set; }
        public Car(string company,string description,int price, string model,string VIN, int kmOnBoard, Engine engine, string complectation, Product[] options) : base(company,description,price)
        {
            Model = model;
            Engine = engine;
            Complectation = complectation;
           this.VIN = VIN;
            if(options != null)
            {
                Options = new Product[options.Length];
                Options.CopyTo(options, 0);
            }
            

            if (kmOnBoard < 10)
                isSold = false;
            else
                isSold = true;
        }        
        public Car(string company,string description,int price, string model, int kmOnBoard, Engine engine, string complectation, Product[] options) : base(company,description,price)
        {
            Model = model;
            Engine = engine;
            Complectation = complectation;
            if(options != null)
            {
                Options = new Product[options.Length];
                Options.CopyTo(options, 0);
            }
            
            VIN = VINandTime.Instance.GetNewVIN();
            Year = VINandTime.Instance.Year;
            if (kmOnBoard < 10)
                isSold = false;
            else
                isSold = true;
        }

        public Car(Car basicCar, Engine engine, int price,string complectation, Product[] options):base(basicCar.ProducerCompany,basicCar.Description,price) 
        {
            Model=basicCar.Model;
            Engine = engine;
            VIN = VINandTime.Instance.GetNewVIN();
            Year = VINandTime.Instance.Year;
            Complectation = complectation;
            if (options != null)
            {
                Options = new Product[options.Length];
                Options.CopyTo(options, 0);
            }

            isSold = false;
        }
        public virtual string GetFullName()
        {
            return $"{ProducerCompany} {Model}";
        }

    }
}
