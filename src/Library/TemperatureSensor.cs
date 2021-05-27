using System.Threading;
using System;
using System.Collections.Generic;

namespace Observer
{
    public class TemperatureSensor : IObservable<Temperature>
    {
        List<IObserver<Temperature>> observers = new List<IObserver<Temperature>>();

        public Temperature Current { get; private set; }

        public void Subscribe(IObserver <Temperature> observer)
        {
            if (! observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver<Temperature> observer)
        {
            if (observers.Contains(observer))
            {
                this.observers.Remove(observer);
            }
        }

        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps = {14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m, 15.4m, 15.45m };
            // Store the previous temperature, so notification is only sent after at least .1 change.
            Nullable<Decimal> previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m ))
                    {
                        this.Current = new Temperature(temp.Value, DateTime.Now);
                        foreach (var observer in observers)
                        {
                            observer.Update(this.Current);
                        }
                        previous = temp;
                        if (start)
                        {
                            start = false;
                        }
                    }
                }
            }
        }
    }
}
