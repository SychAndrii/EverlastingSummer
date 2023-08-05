using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Base
{
    interface IObservable
    {
        void NotifyObservers();
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }
}
