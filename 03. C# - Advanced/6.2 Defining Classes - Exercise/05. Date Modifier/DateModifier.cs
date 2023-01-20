using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double Difference { get; set; }

        public double CalculateDifference(string firstDate, string secondDate)
        {
            DateTime date1 = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            return Math.Abs((date1 - date2).TotalDays);
        }
    }
}
