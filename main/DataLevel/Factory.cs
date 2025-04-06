using System;

using System.Collections.Generic;
using System.Linq;


namespace ProjectUSV_piu
{
    public abstract class Factory
    {
        protected Dictionary<string, (int price, string model, string description, Engine engine, GeneralOptions options)> complectations = new Dictionary<string, (int price, string model, string description, Engine engine, GeneralOptions options)>();
        protected List<Product> optionList = new List<Product>();
        protected int addPrice;
        protected Product[] options;
        protected bool packageFlag;
        



        #region consts

        private const char MAIN_SEPARATOR = ';';
        private const char OPTION_SEPARATOR = '|';//generalOption Separator = ','
        private const char INTEROPTION_SEPARATOR = '.';

        private const int PRODUCER_COMPANY_INDEX = 0;
        private const int DESCRIPTION_INDEX = 1;
        private const int PRICE_INDEX = 2;
        private const int YEAR_INDEX = 3;
        private const int VIN_INDEX = 4; 
        private const int KM_ON_BOARD_INDEX = 5;
        private const int COMPLECTATION_INDEX = 6;
        private const int TYPE_INDEX = 7;
        private const int OPTIONS_INDEX = 8;
        private const int ADDOPTIONS_INDEX = 9;

        #endregion


        protected Dictionary<string, Engine> _engines = new Dictionary<string, Engine>();

        protected virtual Car GetCarAndPriceByDescription(Car BasicCar, string index, int price, Product[] allOptions )
        {
            if (complectations.TryGetValue(index, out var data))
            {
                return new Car(BasicCar, data.engine, data.price + price, index, allOptions);//багов будет дохуя))))
            }
            
            return null;
        }

        public bool ComplectationExists(string s)
        {
            if(complectations.ContainsKey(s))
                return true;
            return false;   
        }

        public void SetOptionPackage(Product[] options, int price)
        {
            this.options = options;
            this.addPrice = price;
            packageFlag = true;
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
        public virtual List<string> GetAllOptions()
        {
            List<string> result = new List<string>();
            foreach (var option in optionList)
            {
                result.Add($"Option {option.Description} is available for {option.Price.ToString()}$");
            }
            return result;
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
                    "{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}",
                    car.ProducerCompany,
                    MAIN_SEPARATOR,
                    car.Description,
                
                    car.Price,
                    car.Year,
                    
                    car.VIN,
                    car.kmOnBoard,
                    car.Complectation,
                
                    car.Type,
                    EnumConverter.GeneralOptionsToString(car.Options)
                );
            }
            return string.Format(
                "{0}{1}{2}{1}{3}{1}{4}{1}{5}{1}{6}{1}{7}{1}{8}{1}{9}{1}{10}",
                car.ProducerCompany,
                MAIN_SEPARATOR,
                car.Description,
                
                car.Price,
                car.Year,

                car.VIN,
                car.kmOnBoard,
                car.Complectation,
                
                car.Type,
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
                    GetModelFromDescription(data[DESCRIPTION_INDEX]),
                    data[VIN_INDEX],
                    int.Parse(data[KM_ON_BOARD_INDEX]),
                    complectations[data[COMPLECTATION_INDEX]].engine,
                    data[COMPLECTATION_INDEX],
                    EnumConverter.StringToVehicleType(data[TYPE_INDEX]),
                    EnumConverter.StringToGeneralOptions(data[OPTIONS_INDEX]),
                null);
            }
            
            return new Car(
                data[PRODUCER_COMPANY_INDEX],
                data[DESCRIPTION_INDEX],
                int.Parse(data[PRICE_INDEX]),
                int.Parse(data[YEAR_INDEX]),
                GetModelFromDescription(data[DESCRIPTION_INDEX]),
                data[VIN_INDEX],
                int.Parse(data[KM_ON_BOARD_INDEX]),
                complectations[data[COMPLECTATION_INDEX]].engine,
                data[COMPLECTATION_INDEX],
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


        protected virtual Car BuildNew(Car basicCar,string complectation, Product[] addOptions) //unsolved BUT USED. Resolve or remove for similar functions.
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
            return GetCarAndPriceByDescription(basicCar, complectation,price, opts);
        }
    }
}
