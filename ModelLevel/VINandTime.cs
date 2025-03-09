using System;
using System.Collections.Generic;


namespace ProjectUSV_piu
{
    public class VINandTime
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public int Year {  get; private set; }
        private List<string> _allVINs = new List<string>();//for internal purposes
        private static VINandTime _instance;
        private static readonly object _lock = new object(); 

        public static VINandTime Instance
        {
            get
            {
                if (_instance == null) 
                {
                    lock (_lock) 
                    {
                        if (_instance == null) 
                        {
                            _instance = new VINandTime();
                        }
                    }
                }
                return _instance;
            }
        }
 
        public string GetNewVIN()//17 symbols
        {
            Random random = new Random();
            char[] str = new char[17];
            for (int i = 0; i < 17; i++)
            {
                str[i] = chars[random.Next(chars.Length)];
            }
            _allVINs.Add(new string(str));
            return new string(str);
        }
        public void HappyNewYear()
        {
            Year++;
        }
    }
}
