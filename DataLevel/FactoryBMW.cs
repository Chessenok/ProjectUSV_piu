using System.Collections.Generic;

namespace ProjectUSV_piu
{
    public class FactoryBMW : Factory
    {
        #region consts

        private static readonly Engine b47 = new Engine("Diesel", 400, 190, "4 Cylinder Inline", 1998);
        private static readonly Engine b48 = new Engine("Benzin", 350, 185, "4 Cylinder Inline", 1998);
        private static readonly Engine b58 = new Engine("Benzin", 500, 340, "6 Cylinder Inline", 2998);
        private static readonly Engine b57 = new Engine("Diesel", 680, 320, "6 Cylinder Inline", 2998);
        private static readonly Engine s63 = new Engine("Benzin", 750, 625, "V8", 4400);
        public readonly Car Base5series = new Car("BMW", "5 series", "G30", 45200, b48, "520i", null);
        public readonly Car Base3series = new Car("BMW", "3 series", "G20", 35200, b48, "320i", null);
        
        #endregion

       public FactoryBMW()
        {
            complectations = new Dictionary<string, (int price,string model,string description, Engine engine)>
            {
                { "520i", (45200,"5 series","G30", b48) },
                { "520d", (48000, "5 series", "G30", b47) },
                { "530d", (54500, "5 series", "G30", b57) },
                { "540i", (59900, "5 series", "G30", b58) },               
                { "320i", (35200, "3 series", "G20", b48) },
                { "320d", (38000, "3 series", "G20", b47) },
                { "340i", (49900, "3 series", "G20", b58) }
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
