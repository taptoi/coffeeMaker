using System;
using CoffeeMaker.API;

namespace CoffeeMaker.Service
{
    internal class SystemMonitor : ISystemMonitor
    {
        private CoffeeMakerAPI api;
        private ISystemControlState systemControlState;

        public SystemMonitor(CoffeeMakerAPI api,
                             ISystemControlState systemControlState)
        {
            this.api = api;
            this.systemControlState = systemControlState;
        }

        public ISystemState GetSystemState() =>
            new SystemState(api.GetWarmerPlateStatus(),
                            api.GetBoilerStatus(),
                            api.GetBrewButtonStatus(),
                            systemControlState.BoilerState,
                            systemControlState.WarmerState,
                            systemControlState.IndicatorState,
                            systemControlState.ReliefValveState);

    }
}
