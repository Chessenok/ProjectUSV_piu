namespace ProjectUSV_piu
{

    public class Engine
    {
        public string FuelType { get; private set; }

        public float MaxTorque { get; private set; }
        public float MaxHP { get; private set; }

        private string _engineType;
        public string EngineIndex { get; private set; }

        private int _volume;

        public Engine(string fuelType, float maxTorque, float maxHP, string engineType, string engineIndex)
        {
            FuelType = fuelType;
            MaxTorque = maxTorque;
            MaxHP = maxHP;
            _engineType = engineType;
            EngineIndex = engineIndex;
        }        
        public Engine(string fuelType, float maxTorque, float maxHP, string engineType,string engineIndex, int volume)
        {
            FuelType = fuelType;
            MaxTorque = maxTorque;
            MaxHP = maxHP;
            _engineType = engineType;
            EngineIndex = engineIndex;
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