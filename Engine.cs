namespace ProjectUSV_piu
{

    class Engine
    {
        public string FuelType { get; private set; }

        public float MaxTorque { get; private set; }
        public float MaxHP { get; private set; }

        private string _engineType;

        public Engine(string fuelType, float maxTorque, float maxHP, string engineType)
        {
            FuelType = fuelType;
            MaxTorque = maxTorque;
            MaxHP = maxHP;
            _engineType = engineType;
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