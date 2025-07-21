using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Helpers
{
    public static class FeedValidationUtils
    {
        public static int DecimalPlaces(decimal number)
        {
            var str = number.ToString(CultureInfo.InvariantCulture);
            var dot = str.IndexOf('.');

            return dot < 0 ? 0 : str.Length - dot - 1;
        }
    }
}
