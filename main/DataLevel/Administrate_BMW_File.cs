using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUSV_piu
{
   public class Administrate_BMW_File : AdministrateFile
    {

        public Administrate_BMW_File(string fileName, Factory factory) : base(fileName, factory)
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
