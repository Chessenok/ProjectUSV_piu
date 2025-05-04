using System.Collections.Generic;

namespace ProjectUSV_piu
{
    public class FactoryBMW : Factory
    {
        #region consts


        public readonly Car Base5series;
        public readonly Car Base3series; 
        
        public static GeneralOptions BMW_20 = GeneralOptions.Klima | GeneralOptions.AirConditioning | GeneralOptions.RearCamera | GeneralOptions.SeatsHeat;

        public static readonly GeneralOptions BMW_30 = BMW_20 | GeneralOptions.Parktronic;

        public static readonly GeneralOptions BMW_40 = BMW_30 | GeneralOptions.Camera360 | GeneralOptions.TrafficAssistant;

        
        #endregion

       public FactoryBMW()
        {
            _engines = new Dictionary<string, Engine>
        {
            { "B47", new Engine("Diesel", 400, 190, "4 Cylinder Inline","B47", 1998) },
            { "B48", new Engine("Benzin", 350, 185, "4 Cylinder Inline","B48", 1998) },
            { "B58", new Engine("Benzin", 500, 340, "6 Cylinder Inline","B58", 2998) },
            { "B57", new Engine("Diesel", 680, 320, "6 Cylinder Inline","B57", 2998) },
            { "S63", new Engine("Benzin", 750, 625, "V8","S63", 4400) }
        };
            complectations = new Dictionary<string, (int price,string model,string description, Engine engine, GeneralOptions options)>
            {
                { "520i", (45200,"5 series","G30", _engines["B48"],BMW_20) },
                { "520d", (48000, "5 series", "G30", _engines["B47"],BMW_20) },
                { "530d", (54500, "5 series", "G30", _engines["B57"],BMW_30) },
                { "540i", (59900, "5 series", "G30", _engines["B58"],BMW_40) },               
                { "320i", (35200, "3 series", "G20", _engines["B48"],BMW_20) },
                { "320d", (38000, "3 series", "G20", _engines["B47"],BMW_20) },
                { "340i", (49900, "3 series", "G20", _engines["B58"],BMW_40) }
            };
            optionList = new List<Product>
            {
                new Product("BMW Options","xDrive",2500),
                new Product("BMW Options","Head-Up Display",750),
                new Product("BMW Options","Keyless Go",500),
                new Product("BMW Options","Leather Seats",1250),
                new Product("BMW Options","Assistant Professional",2000),
                new Product("BMW Options","Traffic Jam",1000)
            };
           Base5series = new Car("BMW","G30", 45200,2020,false,"5 series",VINandTime.GetNewVIN(),0, _engines["B48"], "520i",VehicleType.Sedan,complectations["520i"].options , null);
           Base3series = new Car("BMW", "G20", 35200,2020,false, "3 series",VINandTime.GetNewVIN() ,0, _engines["B48"], "320i",VehicleType.Sedan,complectations["320i"].options, null);
        }

        public Car BuildNew3Series(string complectation, Product[] options)
        {
           return BuildNew(Base3series, complectation, options);
        }      
        public Car BuildNew5Series(string complectation, Product[] options)
        {
           return BuildNew(Base5series, complectation, options);
        }





        

    

    }
}
