using System;

namespace Observer
{
    public struct Temperature
    {
        private decimal degrees;

        private DateTime date;

        public Temperature(decimal temperature, DateTime dateAndTime)
        {
            this.degrees = temperature;
            this.date = dateAndTime;
        }

        public decimal Degrees
        {
            get
            {
                return this.degrees;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }
    }
}