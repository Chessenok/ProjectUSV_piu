using System.Collections.Generic;
using System.Linq;

namespace ProjectUSV_piu
{
    public class FactoryBMW : Factory
    {
        #region consts


        public readonly Car Base5series;
        public readonly Car Base3series; 
        public readonly Car Base1series; 
        
        public static GeneralOptions BMW_20 = GeneralOptions.Klima | GeneralOptions.AirConditioning | GeneralOptions.RearCamera | GeneralOptions.SeatsHeat | GeneralOptions.Parktronic;

        public static readonly GeneralOptions BMW_30 = BMW_20 | GeneralOptions.Camera360;

        public static readonly GeneralOptions BMW_40 = BMW_30 | GeneralOptions.SeatsConditioning | GeneralOptions.TrafficAssistant;

        
        #endregion

       public FactoryBMW()
        {
            Company = "BMW";
            _logic = new Dictionary<string, System.Func<GeneralOptions, GeneralOptions>>
            {
                ["Luxury Leather Seats"] = options =>
                {
                    return options | GeneralOptions.SeatsConditioning;
                },
                ["Panorama Roof"] = options =>
                {
                    options &= ~GeneralOptions.Sunroof;
                    return options | GeneralOptions.Panorama;
                },
                ["Assistant Professional"] = options =>
                {
                    return options | GeneralOptions.TrafficAssistant | GeneralOptions.Camera360;
                },
                ["Head-Up Display"] = options =>
                {
                    return options | GeneralOptions.HUD;
                },
                ["Keyless Go"] = options =>
                {
                    return options | GeneralOptions.KeylessGo;
                }
            };
            _engines = new Dictionary<string, Engine>
        {
            { "B47B20", new Engine("Diesel", 400, 190, "4 Cylinder Inline","B47B20", 1998) },
            { "B47B30", new Engine("Diesel", 480, 252, "4 Cylinder Inline","B47B30", 1998) },
            { "B48B20", new Engine("Benzin", 350, 185, "4 Cylinder Inline","B48B20", 1998) },
            { "B48B30", new Engine("Benzin", 400, 252, "4 Cylinder Inline","B48B30", 1998) },
            { "B58", new Engine("Benzin", 500, 340, "6 Cylinder Inline","B58", 2998) },
            { "B57", new Engine("Diesel", 680, 320, "6 Cylinder Inline","B57", 2998) },
            { "N63TU3", new Engine("Benzin", 650, 440, "V8","N63TU3", 4398) },
            { "S63", new Engine("Benzin", 750, 625, "V8","S63", 4400) }

        };
            

            optionsForComplectation = new Dictionary<string, List<string>> {
                {"520i", optionList.Select(p => p.Description).ToList()},
                {"320i", optionList.Select(p => p.Description).ToList()},
                {"120i", optionList.Select(p => p.Description).ToList()},
                {"520d", optionList.Select(p => p.Description).ToList()},
                {"320d", optionList.Select(p => p.Description).ToList()},
                {"120d", optionList.Select(p => p.Description).ToList()},
            };
            colors = new List<string> {"Cosmic Black","Pearl White","Navy Blue","Dark Gray","Woody Brown","Cheery Red","Autumn Orange" };

            complectations = new Dictionary<string, (int price,string model,string description,VehicleType vehicleType, Engine engine, GeneralOptions options)>
            {
                { "520i", (45200,"5 series","G30",VehicleType.Sedan , _engines["B48B20"],BMW_20) },
                { "520d", (47000, "5 series", "G30",VehicleType.Sedan ,_engines["B47B20"],BMW_20) },
                { "530i", (48000, "5 series", "G30",VehicleType.Sedan ,_engines["B48B30"],BMW_30) },
                { "530d", (51500, "5 series", "G30", VehicleType.Sedan, _engines["B57"], BMW_30) },
                { "540i", (59900, "5 series", "G30",VehicleType.Sedan ,_engines["B58"],BMW_40) },               
                { "320i", (35200, "3 series", "G20",VehicleType.Sedan ,_engines["B48B20"],BMW_20) },
                { "320d", (38000, "3 series", "G20",VehicleType.Sedan ,_engines["B47B20"],BMW_20) },
                { "340i", (49900, "3 series", "G20",VehicleType.Sedan, _engines["B58"],BMW_40) },
                { "330i", (43900, "3 series", "G20",VehicleType.Sedan, _engines["B48B30"],BMW_30) },
                { "120i", (20900, "1 series", "F70",VehicleType.Hatchback, _engines["B48B20"],BMW_20) },
                { "X5 40i", (79900, "X5", "G05",VehicleType.SUV, _engines["B58"],BMW_40) },
                { "X5 40d", (82900, "X5", "G05",VehicleType.SUV, _engines["B57"],BMW_40) },
                { "X3 30i", (52900, "X3", "G01",VehicleType.SUV, _engines["B48B30"],BMW_30) },
                { "X3 30d", (54900, "X3", "G01",VehicleType.SUV, _engines["B57"],BMW_30) },
                { "X7 40i", (89900, "X7", "G07",VehicleType.SUV, _engines["B58"],BMW_40) },
                { "X7 40d", (90900, "X7", "G07",VehicleType.SUV, _engines["B58"],BMW_40) },
               // { "730d", (90900, "X7", "G07",VehicleType.SUV, _engines["B57"],BMW_30) },
                { "730i", (70900, "7 series", "G11",VehicleType.Sedan, _engines["B48B30"],BMW_30) },
                { "730d", (72900, "7 series", "G11",VehicleType.Sedan, _engines["B57"],BMW_30) },
                { "740d", (82900, "7 series", "G11",VehicleType.Sedan, _engines["B57"],BMW_40) },
                { "740i", (80900, "7 series", "G11",VehicleType.Sedan, _engines["B58"],BMW_40) },
                { "740Li", (84900, "7 series", "G12",VehicleType.Sedan, _engines["B58"],BMW_40) },
                { "740Ld", (85900, "7 series", "G12",VehicleType.Sedan, _engines["B58"],BMW_40) },
                { "750Li", (90900, "7 series", "G12",VehicleType.Sedan, _engines["N63TU3"],BMW_40) },
                { "750i", (87900, "7 series", "G11",VehicleType.Sedan, _engines["N63TU3"],BMW_40) }

                
            };
            optionList = new List<Product>
            {
                new Product("BMW Options","xDrive",2500),
                new Product("BMW Options","Head-Up Display",750),
                new Product("BMW Options","Keyless Go",500),
                new Product("BMW Options","Leather Seats",1250),
                new Product("BMW Options","Luxury Leather Seats",2550),
                new Product("BMW Options","Assistant Professional",2000),
                new Product("BMW Options","Panorama Roof",500)
               // new Product("BMW Options","",2000),
                
            };



           Base5series = new Car("BMW", "G30", complectations["520i"].price, 2020, false, "5 series", VINGetter.GetNewVIN(), 0, _engines["B48B20"], "520i", "Dark Gray", complectations["520i"].vehicleType, complectations["520i"].options, null);
           Base3series = new Car("BMW", "G20", complectations["320i"].price, 2020,false, "3 series",VINGetter.GetNewVIN() ,0, _engines["B48B20"], "320i","Dark Gray", complectations["320i"].vehicleType, complectations["320i"].options, null);
           Base1series = new Car("BMW", "F70", complectations["120i"].price,2024,false, "1 series",VINGetter.GetNewVIN() ,0, _engines["B48B20"], "120i","Dark Gray", complectations["120i"].vehicleType, complectations["120i"].options, null);
        }

       










    }
}
