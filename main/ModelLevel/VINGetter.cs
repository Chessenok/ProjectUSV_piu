using System;
using System.Collections.Generic;


namespace ProjectUSV_piu
{
    public class VINGetter
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
       // public int Year {  get; private set; }
        private static List<string> _allVINs = new List<string>();//for internal purposes
        private static VINGetter _instance;
        private static readonly object _lock = new object(); 

        public static VINGetter Instance
        {
            get
            {
                if (_instance == null) 
                {
                    lock (_lock) 
                    {
                        if (_instance == null) 
                        {
                            _instance = new VINGetter();
                        }
                    }
                }
                return _instance;
            }
        }
 
        public static string GetNewVIN()//17 symbols
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
    }
}
