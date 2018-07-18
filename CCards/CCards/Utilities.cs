using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCards
{
    public static class Utilities
    {
        public static int IsPrime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            if (i == number)
            {
                return 1;
            }
            return 0;
        }

        public const string Card_UnKnown = "Unknown";
        public const string Card_JCB = "JCB";
        public const string Card_Visa = "Visa";
        public const string Card_MasterCard = "Master";
        public const string Card_Amex = "Amex";

        public const string Result_NotFound = "Does not exist";
        public const string Result_Valid = "Valid";
        public const string Result_Invalid = "Invalid";
    }
}