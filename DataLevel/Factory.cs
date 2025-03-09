using System;

using System.Collections.Generic;
using System.Linq;


namespace ProjectUSV_piu
{
    public abstract class Factory
    {
        protected Dictionary<string, (int price,string model,string description, Engine engine)> complectations = new Dictionary<string, (int price,string model,string description, Engine engine)>();
        protected List<Product> optionList = new List<Product>();
        protected int addPrice = 0;
        protected Product[] options = null;
        protected bool packageFlag;


        protected virtual Car GetCarAndPriceByComplectation(Car BasicCar, string index, int price, Product[] allOptions )
        {
            if (complectations.TryGetValue(index, out var data))
            {
                return new Car(BasicCar, data.engine, data.price + price, index, allOptions);
            }

            price = 0;
            return null; // error
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

        public virtual Car BuildNew(Car basicCar,string complectation, Product[] addOptions)
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
            return GetCarAndPriceByComplectation(basicCar, complectation,price, opts);
        }
    }
}
