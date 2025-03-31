using System;
using System.Linq;

namespace ProjectUSV_piu
{
    public class EnumConverter
    {
        public static string VehicleTypeToString(VehicleType type)
        {
            return type.ToString();
        }

        public static VehicleType StringToVehicleType(string str)
        {
            return Enum.TryParse(str, out VehicleType result) ? result : VehicleType.Other;
        }

        public static string GeneralOptionsToString(GeneralOptions options)
        {
            return string.Join(",", Enum.GetValues(typeof(GeneralOptions))
                .Cast<GeneralOptions>()
                .Where(opt => options.HasFlag(opt) && opt != 0)); // Ensures all flags are included
        }
        public static GeneralOptions StringToGeneralOptions(string str)
        {
            return str.Split(',')
                .Select(s => Enum.TryParse(s.Trim(), out GeneralOptions opt) ? opt : 0)
                .Aggregate((acc, next) => acc | next);
        }
        
        public static GeneralOptions AddGeneralOption(GeneralOptions baseOptions, string newOption)
        {
            if (Enum.TryParse(newOption, true, out GeneralOptions parsedOption))
            {
                return baseOptions | parsedOption; 
            }
    
            Console.WriteLine($"Warning: '{newOption}' is not a valid GeneralOptions value.");
            return baseOptions; 
        }
        
    }
}