using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
namespace ProjectUSV_piu
{
    public class AdministrateFile : AdministrateCars
    {
        private string _fileName;
        public Factory Factory { get; protected set; }
        public AdministrateFile(string FileName, Factory factory)
        {
            _fileName = FileName;
            Stream streamFisierText = File.Open(FileName, FileMode.OpenOrCreate);
            streamFisierText.Close();
            Factory = factory;
            OnInitialise();
        }

        private async void OnInitialise()
        {
            _carsList = await ReadFromFileAsync();
        }

        public override async void AddCar(Car car)
        {
            await AddCarAsync(car);
        }
        private async Task AddCarAsync(Car car)
        {
            base.AddCar(car);

            await WriteCarToFileAsync(car);
        }

        public override void ModifyAndSaveCar(Car car)
        {
            base.ModifyAndSaveCar(car);
            UpdateFile();
        }

        /* public async Task<List<Car>> ReadFromFileAsync()
         {
             var cars = new List<Car>();
             using (var streamReader = new StreamReader(_fileName))
             {
                 string line;
                 while ((line = await streamReader.ReadLineAsync()) != null)
                 {
                     if (!string.IsNullOrWhiteSpace(line))
                     {
                         Car car = _factory.BuildCarFromString(line);
                         cars.Add(car);
                     }
                 }
             }

             return cars;
         }*/

        public async Task<List<Car>> ReadFromFileAsync()
       {
           var cars = new List<Car>();

           using (var streamReader = new StreamReader(_fileName))
           {
               string line;
               while ((line = await streamReader.ReadLineAsync()) != null)
               {
                   if (string.IsNullOrWhiteSpace(line))
                       continue;

                   try
                   {
                       Car car = Factory.BuildCarFromString(line);
                       cars.Add(car);
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine($"Error parsing line: {line} - {ex.Message}");
                   }
               }
           }

           return cars;
       }

    public void UpdateCar(Car c)
        {
           for(int i = 0; i < _carsList.Count; i++)
            {
                Car car = _carsList[i];
                if(car.VIN == c.VIN)
                {
                    _carsList[i] = c;
                }
            }
            UpdateFile();
        }

        public void UpdateFile()
        {
            var lines = _carsList.Select(Factory.GetStringFromCar).ToList();
            File.WriteAllLines(_fileName, lines);
            return;
        }

        public async Task WriteCarToFileAsync(Car car)
        {
            using (var streamWriter = new StreamWriter(_fileName, append: true))
            { 
                string carString = Factory.GetStringFromCar(car);

                await streamWriter.WriteLineAsync(carString);
            }
        }


    }
}