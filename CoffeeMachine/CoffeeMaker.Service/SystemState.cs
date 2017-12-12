using System;
using CoffeeMaker.API;

namespace CoffeeMaker.Service
{ 
    internal class SystemState : ISystemState
    {
        public SystemState(WarmerPlateStatus warmerPlateStatus,
                           BoilerStatus boilerStatus,
                           BrewButtonStatus brewButtonStatus,
                           BoilerState boilerState,
                           WarmerState warmerState,
                           IndicatorState indicatorState,
                           ReliefValveState reliefValveState)
        {
            this.WarmerPlateStatus = warmerPlateStatus;
            this.BoilerStatus = boilerStatus;
            this.BrewButtonStatus = brewButtonStatus;
            this.BoilerState = boilerState;
            this.WarmerState = warmerState;
            this.IndicatorState = indicatorState;
            this.ReliefValveState = reliefValveState;
        }

        public WarmerPlateStatus WarmerPlateStatus { get; }

        public BoilerStatus BoilerStatus { get; }

        public BrewButtonStatus BrewButtonStatus { get; }

        public BoilerState BoilerState { get; }

        public IndicatorState IndicatorState { get; }

        public ReliefValveState ReliefValveState { get; }

        public WarmerState WarmerState { get; }

        public bool Equals(ISystemState other)
        {
            if (other == null)
                return false;
            return this.WarmerPlateStatus == other.WarmerPlateStatus &&
                       this.BoilerStatus == other.BoilerStatus &&
                       this.BrewButtonStatus == other.BrewButtonStatus &&
                       this.BoilerState == other.BoilerState &&
                       this.IndicatorState == other.IndicatorState &&
                       this.ReliefValveState == other.ReliefValveState &&
                       this.WarmerState == other.WarmerState;
        }
    }
}
