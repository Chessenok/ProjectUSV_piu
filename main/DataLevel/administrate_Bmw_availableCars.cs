using System;
using System.Collections.Generic;

namespace ProjectUSV_piu
{
    public class administrate_Bmw_availableCars : AdministrateCars
    {
        public administrate_Bmw_availableCars()
        { 
            
            if (!_instance)
            {
                _carsList = new List<Car>();
                _instance = true;
            }
            else
                Console.WriteLine("Adding new existing instance of administrate car class. This is not allowed.");
        } 
        
    }
}
