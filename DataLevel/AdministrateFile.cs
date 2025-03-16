using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProjectUSV_piu
{
    public class AdministrateFile : AdministrateCars
    {
        private string _fileName;
        private Factory _factory;
        public AdministrateFile(string FileName, Factory factory)
        {
            _fileName = FileName;
            Stream streamFisierText = File.Open(FileName, FileMode.OpenOrCreate);
            streamFisierText.Close();
            _factory = factory;
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

        public async Task<List<Car>> ReadFromFileAsync()
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
        }

        public async Task WriteCarToFileAsync(Car car)
        {
            using (var streamWriter = new StreamWriter(_fileName, append: true))
            { 
                string carString = _factory.GetStringFromCar(car);

                await streamWriter.WriteLineAsync(carString);
            }
        }


    }
}
