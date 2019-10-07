using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public int GetDateDifference(string firstDate, string secondDate)
        {
            this.startDate = DateTime.Parse(firstDate);
            this.endDate = DateTime.Parse(secondDate);

            int result = (int)((this.startDate - this.endDate).TotalDays);
            return Math.Abs(result);
        }
    }
}
