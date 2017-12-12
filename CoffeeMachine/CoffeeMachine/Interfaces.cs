using System;

namespace CoffeeMaker.Interface
{
    public interface ICoffeeMakerService
    {
        void Start(int updateIntervalMilliseconds);
        void Stop();
    }
}
