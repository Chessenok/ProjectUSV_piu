namespace ProjectUSV_piu
{
    class Car : Product
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }

        public string Complectation {  get; private set; }

        public string[] Options { get; protected set; }

        public int kmOnBoard;
        public Car(string company, string model,string description,int price, Engine engine, string complectation, string[] options) : base(company,description,price)
        {
            Model = model;
            Engine = engine;
            Complectation = complectation;
            Options = options;
        }

        public string GetFullName()
        {
            return $"{ProducerCompany} {Model}";
        }

    }
}
