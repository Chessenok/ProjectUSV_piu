using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace ProjectUSV_piu
{
    public abstract class Factory
    {
        public string Company {  get; protected set; }
        protected Dictionary<string, (int price, string model, string description,VehicleType vehicleType, Engine engine, GeneralOptions options)> complectations = new Dictionary<string, (int price, string model, string description, VehicleType vehicleType, Engine engine, GeneralOptions options)>();
        protected List<Product> optionList = new List<Product>();
        protected int addPrice;
        protected Product[] options;
        protected bool packageFlag;
        protected Dictionary<string, List<string>> optionsForComplectation = new Dictionary<string, List<string>>(); 
        protected List<string> colors = new List<string>();
        protected Dictionary<string, Func<GeneralOptions, GeneralOptions>> _logic = new Dictionary<string,Func<GeneralOptions, GeneralOptions>>();


        #region consts

        public const char MAIN_SEPARATOR = ';';
        private const char OPTION_SEPARATOR = '|';//generalOption Separator = ','
        private const char INTEROPTION_SEPARATOR = '.';

        private const int PRODUCER_COMPANY_INDEX = 0;
        private const int DESCRIPTION_INDEX = 1;
        private const int PRICE_INDEX = 2;
        private const int YEAR_INDEX = 3;
        public const int VIN_INDEX = 4; 
        private const int KM_ON_BOARD_INDEX = 5;
        private const int COMPLECTATION_INDEX = 6;
        private const int COLOR_INDEX = 7;
        private const int TYPE_INDEX = 8;
        private const int OPTIONS_INDEX = 10;
        private const int ADDOPTIONS_INDEX = 11;
        private const int ISAVAILABLE_INDEX = 9;

        #endregion


        protected Dictionary<string, Engine> _engines = new Dictionary<string, Engine>();

        protected virtual Car GetCarAndPriceByDescription(Car BasicCar, string index, int price,string color, Product[] allOptions )
        {
            if (complectations.TryGetValue(index, out var data))
            {
                return new Car(BasicCar, index, price, color, GetEngineForComplectation(index), 2024, complectations[index].options,allOptions);
            }
            
            return null;
        }


        public int GetPriceForComplectation(string index)
        {
            return complectations[index].price;
        }

        public List<string> GetColors()
        {
            return colors;
        }

        public Engine GetEngineForComplectation(string complectation)
        {
            return _engines[complectation];
        }

        public List<string> GetModelsForType(string type)
        {
            VehicleType Type = EnumConverter.StringToVehicleType(type);
            List<string> models = new List<string>();
            foreach (var n in complectations)
            {
                if (n.Value.vehicleType == Type && (models.Contains(n.Value.model) == false))
                    models.Add(n.Value.model);
            }
            return models;
        }

        public List<string> GetComplectationsForModelAndType(string model, string type) 
        {
            VehicleType Type = EnumConverter.StringToVehicleType(type);
            List<string> comps = new List<string>();
            foreach(var n in complectations)
            {
                if(n.Value.vehicleType == Type && (comps.Contains(n.Value.model) == false)) 
                    comps.Add(n.Key);
            }
            return comps;
        }
        public bool ComplectationExists(string s)
        {
            return complectations.ContainsKey(s);   
        }


        public virtual List<string> GetAvailableOptionsForComplectation(string c)
        {
            return null;//nigga

        }

       /* public void SetOptionPackage(Product[] options, int price)
        {
            this.options = options;
            this.addPrice = price;
            packageFlag = true;
        }nigga*/

        public void ImplementOption(ref Car car,string option)
        {
            Product Option = optionList.Where(p => p.Description == option).FirstOrDefault();
            car.AddOptions.Add(Option);
            if (_logic.ContainsKey(option))
            {
                _logic.TryGetValue(option, out var applyOption);
                applyOption(car.Options);
            }

        }


        Product FindProductByDescription(List<Product> products, string description)
        {
            return products.FirstOrDefault(p => p.Description == description);
        }
        


        protected int GetPriceForOptions(Product[] options)
        {
            int addedPrice = 0;
            if (options != null)
            {
                foreach (Product product in options)
                {
                    addedPrice += product.Price;
                }
            }
            return addedPrice;
        }
        public virtual List<Product> GetAllOptions()
        {
            return optionList;
        }


        #region toStringStuffForFiles

        
        public virtual List<string> GetAllComplectationsForDescription(string targetDescription)
        {
              List<string> result = new List<string> ();
              foreach (var item in complectations)
              {
                  if(item.Value.description == targetDescription)
                {
                    result.Add ($"Complectation {item.Key} has {item.Value.engine.GetVolume()}cm3 volume and {item.Value.engine.MaxHP} horsepower. Available from {item.Value.price.ToString()}$.");
                }
              }
            return result;
        }
        public virtual List<string> GetAllComplectationsForModel(string targetmodel)
        {
            List<string> result = new List<string>();
            foreach (var item in complectations)
            {
                if (item.Value.model == targetmodel)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }


        private string GetModelFromDescription(string d)
        {
            foreach(var item in complectations)
            {
                if(item.Value.description == d)
                {
                    return item.Value.model; //returns first model found
                }
            }
            return "Unknown Model";
        }

        public virtual string GetStringFromCar(Car car)
        {
            //govnocod on
            if (string.IsNullOrEmpty(StringFromOptions(car)))
            {
                return string.Format(
                    "{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{1}{10}{1}{11}",
                    car.ProducerCompany,
                    MAIN_SEPARATOR,
                    car.Description,

                    car.Price,
                    car.Year,

                    car.VIN,
                    car.kmOnBoard,
                    car.Complectation,

                    car.Color,
                    car.Type,
                    ConvertBoolToString(car.isAvailable),

                    EnumConverter.GeneralOptionsToString(car.Options)
                    
                );
            }
            return string.Format(
                "{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{1}{10}{1}{11}{1}{12}",
                car.ProducerCompany,
                MAIN_SEPARATOR,
                car.Description,
                
                car.Price,
                car.Year,

                car.VIN,
                car.kmOnBoard,
                car.Complectation,
                
                car.Type,
                car.Color,
                ConvertBoolToString(car.isAvailable),

                EnumConverter.GeneralOptionsToString(car.Options),
                StringFromOptions(car) 
                


            );
            //govnocod off
        }

        public virtual Car BuildCarFromString(string str)
        {
            var data = str.Split(MAIN_SEPARATOR);
            if (data.Length == ADDOPTIONS_INDEX)
            {
                return new Car(
                    data[PRODUCER_COMPANY_INDEX],
                    data[DESCRIPTION_INDEX],
                    int.Parse(data[PRICE_INDEX]),
                    int.Parse(data[YEAR_INDEX]),
                    ConvertStringToBool(data[ISAVAILABLE_INDEX]),
                    GetModelFromDescription(data[DESCRIPTION_INDEX]),
                    data[VIN_INDEX],
                    int.Parse(data[KM_ON_BOARD_INDEX]),
                    complectations[data[COMPLECTATION_INDEX]].engine,
                    data[COMPLECTATION_INDEX],
                    data[COLOR_INDEX],

                    EnumConverter.StringToVehicleType(data[TYPE_INDEX]),
                    EnumConverter.StringToGeneralOptions(data[OPTIONS_INDEX]),
                null);
            }
            
            return new Car(
                data[PRODUCER_COMPANY_INDEX],
                data[DESCRIPTION_INDEX],
                int.Parse(data[PRICE_INDEX]),
                int.Parse(data[YEAR_INDEX]),
                ConvertStringToBool(data[ISAVAILABLE_INDEX]),
                GetModelFromDescription(data[DESCRIPTION_INDEX]),
                data[VIN_INDEX],
                int.Parse(data[KM_ON_BOARD_INDEX]),
                complectations[data[COMPLECTATION_INDEX]].engine,
                data[COMPLECTATION_INDEX],
                data[COLOR_INDEX],
                EnumConverter.StringToVehicleType(data[TYPE_INDEX]),
                EnumConverter.StringToGeneralOptions(data[OPTIONS_INDEX]), 
                GetAddOptionsFromString(data[ADDOPTIONS_INDEX]) 
            );
        }
        protected virtual string StringFromOptions(Car car)
        {
            string s = string.Empty;
            if(car.AddOptions == null)
            {
                return string.Empty;
            }
            foreach (var item in car.AddOptions)
            {
                s += string.Format("{0}{1}{2}{1}{3}", item.ProducerCompany, INTEROPTION_SEPARATOR, item.Description, item.Price.ToString()) + OPTION_SEPARATOR.ToString();
            }

            if (s.Length > 0)
            {
                s = s.TrimEnd(OPTION_SEPARATOR);
            }
            return s;
        }
        private Product[] GetAddOptionsFromString(string optionsString)
        {
            if (string.IsNullOrEmpty(optionsString))  return null; 
            string[] optionStrings = optionsString.Split(OPTION_SEPARATOR);
            Product[] optionsArray = new Product[optionStrings.Length];
       
            for (int i = 0; i < optionStrings.Length; i++)
            { 
                string[] optionParts = optionStrings[i].Split(INTEROPTION_SEPARATOR);

                if (optionParts.Length == 3)
                { 
                    string producerCompany = optionParts[0];
                    string description = optionParts[1];
                    int price = int.Parse(optionParts[2]); 

                    optionsArray[i] = new Product(producerCompany, description, price);
                }
            }

            return optionsArray;
        }

        #endregion


        protected bool ConvertStringToBool(string value)
        {
            if(value == "1")
                return true;
            else
                return false;//pohui
        }

        public void ApplyAddOptionsToCar(Car car) //nigga
        {
            foreach (var kvp in _logic)
            {
            
            }

        }
        protected string ConvertBoolToString(bool value)
        {
            if (value) return "1";
            else return "0";
        }


        public Car BuildNew(string complectation,string color, Product[] addOptions, int price,bool available)
        {
            return new Car(Company, complectations[complectation].description, price, 2025, available, complectations[complectation].model, VINGetter.GetNewVIN(), 0, complectations[complectation].engine, complectation, color, complectations[complectation].vehicleType, complectations[complectation].options,addOptions);
        }
       

        public virtual Car BuildNew(Car basicCar,string complectation, Product[] addOptions,string color) //unsolved BUT USED. Resolve or remove for similar functions.
        {
            int price = 0;


            Product[] opts = null;
            if (packageFlag)
            {
                price += addPrice;
                opts = new Product[options.Length + addOptions.Length];
                options.CopyTo(opts, 0);
                addOptions.CopyTo(opts, options.Length);
                packageFlag = false;
                addOptions = null;
                addPrice = 0;
            }
            else
            {
                if (addOptions != null)
                {
                    opts = new Product[addOptions.Length];
                    addOptions.CopyTo(opts, 0);
                }
            }
            price += GetPriceForOptions(addOptions);
            return GetCarAndPriceByDescription(basicCar, complectation,price,color ,opts);
        }
    }
}
