using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        private bool first = true;

        private Temperature last;
        
        private IObservable provider;

        public void StartReporting(IObservable provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature value)
        {
            Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}");
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {value.Degrees - last.Degrees}° in " +
                    $"{value.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}