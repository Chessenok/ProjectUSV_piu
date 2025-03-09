

namespace ProjectUSV_piu
{
    public class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public string VIN { get; private set; }

        public int Year { get; private set; }
        public string Complectation {  get; private set; }

        public Product[] Options { get; protected set; }

        public int kmOnBoard;
        public Car(string company, string model,string description,int price, Engine engine, string complectation, Product[] options) : base(company,description,price)
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
        }
        public virtual string GetFullName()
        {
            return $"{ProducerCompany} {Model}";
        }

    }
}
