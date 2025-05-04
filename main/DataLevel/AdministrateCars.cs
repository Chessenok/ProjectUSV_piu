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
            //car.Sold();
        }
        public Car[] GetAllCars()
        {
            return _carsList.ToArray();
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