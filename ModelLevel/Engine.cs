namespace ProjectUSV_piu
{

    public class Engine
    {
        public string FuelType { get; private set; }

        public float MaxTorque { get; private set; }
        public float MaxHP { get; private set; }

        private string _engineType;

        private int _volume;

        public Engine(string fuelType, float maxTorque, float maxHP, string engineType)
        {
            FuelType = fuelType;
            MaxTorque = maxTorque;
            MaxHP = maxHP;
            _engineType = engineType;
        }        
        public Engine(string fuelType, float maxTorque, float maxHP, string engineType, int volume)
        {
            FuelType = fuelType;
            MaxTorque = maxTorque;
            MaxHP = maxHP;
            _engineType = engineType;
            _volume = volume;
        }

        
        public int GetVolume() {
            if (FuelType != "Electric")
                return _volume;
            else
                return -1;
        }
        public string EngineType()
        {
            if(FuelType == "Electric" || string.IsNullOrEmpty(_engineType))
            {
                return FuelType;
            }
            return _engineType;
        }
    }
}