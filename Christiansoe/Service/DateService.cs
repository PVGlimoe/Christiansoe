using System;

namespace Christiansoe.Service 
{
    public class DateService
    {
        public static Boolean monthBetween(int startMonth, int endMonth, int month)
        {
            if (startMonth == 0 || endMonth == 0)
            {
                return true;
            }
            while (startMonth != month)
            {
                if (startMonth == endMonth)
                {
                    return false;
                }
                if (startMonth == 12)
                {
                    startMonth = 1;
                }
                else
                {
                    startMonth += 1;
                }
            }
            return true;
        }
    }
}
