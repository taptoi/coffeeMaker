using System;
namespace CoffeeMaker.Service
{
    public class ModelStateProvider : IModelStateProvider
    {
        public ModelStateProvider()
        {
        }

        public ModelState CurrentState => throw new NotImplementedException();
    }
}
