using MuhammetAliDemir.TP.Net.Homework.Data;
using MuhammetAliDemir.TP.Net.Homework.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MuhammetAliDemir.TP.Net.Homework.Extensions
{
    public static class CustomPremiumDriverExtension
    {
        public static bool IsPremiumDriver(this Driver driver)
        {
            if (driver.Championship > 0 && driver.Podiums > 50 && driver.RaceEntered > 100)
                return true;

            return false;
        }
    }
}