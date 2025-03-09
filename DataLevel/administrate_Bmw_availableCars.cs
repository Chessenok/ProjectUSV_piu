using System;
using System.Collections.Generic;

namespace ProjectUSV_piu
{
    public class administrate_Bmw_availableCars
    {
        private List<Car> _availableCars;
        private List<Car> _soldCars;
        private bool _instance;

       
        public administrate_Bmw_availableCars() {

            if (!_instance)
            {
                _availableCars = new List<Car>();
                _soldCars = new List<Car>();
                _instance = true;
            }
            else
                Console.WriteLine("Adding new existing instance of administrate car class. This is not allowed.");
        }
        public void AddAvailableCar(Car car)
        {
            if(car != null) 
                _availableCars.Add(car);
        }       
        public void AddSoldCar(Car car)
        {
            if(car != null) 
                _soldCars.Add(car);
        }

        public void RemoveAvailableCar(int carIndex)
        {
            _availableCars.RemoveAt(carIndex);
        }
        
        public Car GetAvailbleCar(int carIndex) 
        {
            return _availableCars[carIndex];
        }        
        public Car GetSoldCar(int carIndex) 
        {
            return _soldCars[carIndex];
        }

        public Car[] GetAllAvailableCars()
        {
            return _availableCars.ToArray();
        }       
        public Car[] GetAllSoldCars()
        {
            return _soldCars.ToArray();
        }

        public bool GetAllAvailbleCarsByModel(string model, out Car[] car)
        {
            List<Car> cars = new List<Car>();
            bool success = false;
            foreach (var c in _availableCars)        //LINQ should be used here, but it will be overkill for this project
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
        public bool GetAllSoldCarsByModel(string model, out Car[] car)
        {
            List<Car> cars = new List<Car>();
            bool success = false;
            foreach (var c in _availableCars)        //LINQ should be used here, but it will be overkill for this project
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
        public bool GetAvailbleCarByVIN(string vin, out Car car)
        { 
            foreach (var c in _availableCars)
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
        public bool GetSoldCarByVIN(string vin, out Car car)
        { 
            foreach (var c in _soldCars)
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
    
}
}
