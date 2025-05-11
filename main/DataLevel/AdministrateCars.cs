using System.Collections.Generic;

namespace ProjectUSV_piu {

    public abstract class AdministrateCars
    {
        protected List<Car> _carsList;
        protected static bool _instance;
        public virtual void AddCar(Car car)
        {
            if (car != null)
                _carsList.Add(car);
        }

        public void SoldCar(Car car)
        {
            bool flag = false;
            foreach (var c in _carsList)
            {
                if (c.VIN == car.VIN)
                {
                    c.isAvailable = false;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                car.isAvailable = false;
                AddCar(car);
            }
        }
        public virtual List<Car> GetAllCars()
        {
            return _carsList;
        }

        public virtual void ModifyAndSaveCar(Car car) 
        {
            foreach (Car c in _carsList)
            {
                if (c.VIN == car.VIN)
                {
                    int index = _carsList.IndexOf(c);
                    _carsList[index] = car;
                    break;
                }
            }
        }

        public bool GetAllCarsByModel(string model, out Car[] car)
        {
            List<Car> cars = new List<Car>();
            bool success = false;
            foreach (var c in _carsList)        
            {
                if (c.Model == model)
                {
                    cars.Add(c);
                    success = true;
                }
            }
            car = cars.ToArray();
            return success;
        }

        public bool GetCarsByIndex(string index, out List<Car> cars, bool available)
        {
            cars = new List<Car>();
            foreach (var c in _carsList)
            {
                if (c.Description == index && c.isAvailable == available)
                {
                    cars.Add(c);
                }
            }
            if (cars.Count == 0)
            {
                return false;
            }
            else
                return true;
        }
        public bool GetCarByVIN(string vin, out Car car)
        {
            foreach (var c in _carsList)
            {
                if (c.VIN == vin)
                {
                    car = c;
                    return true;
                }
            }
            car = null;
            return false;
        }
    } }