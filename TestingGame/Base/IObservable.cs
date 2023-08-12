using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Base
{
    interface IObservable<T>
    {
        void NotifyObservers();
        void AddObserver(IObserver<T> observer);
        void RemoveObserver(IObserver<T> observer);
    }
}
