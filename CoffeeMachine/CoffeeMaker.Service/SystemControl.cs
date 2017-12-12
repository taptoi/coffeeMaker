using System;
using CoffeeMaker.API;

namespace CoffeeMaker.Service
{
    public class SystemControl : ISystemControlCommands, ISystemControlState
    {
        private readonly CoffeeMakerAPI api;
        public BoilerState BoilerState { get; private set; }

        public IndicatorState IndicatorState { get; private set; }

        public ReliefValveState ReliefValveState { get; private set; }

        public WarmerState WarmerState { get; private set; }

        public SystemControl(CoffeeMakerAPI api,
                             BoilerState boilerState,
                     IndicatorState indicatorState,
                     ReliefValveState reliefValveState)
        {
            this.api = api;
            this.BoilerState = boilerState;
            this.IndicatorState = indicatorState;
            this.ReliefValveState = reliefValveState;
        }

        public void SetBoilerState(BoilerState s)
        {
            if(this.BoilerState != s)
            {
                api.SetBoilerState(s);
                this.BoilerState = s;
            }
        }

        public void SetIndicatorState(IndicatorState s)
        {
            if(this.IndicatorState != s)
            {
                api.SetIndicatorState(s);
                this.IndicatorState = s;
            }
        }

        public void SetReliefValveState(ReliefValveState s)
        {
            if(this.ReliefValveState != s)
            {
                api.SetReliefValveState(s);
                this.ReliefValveState = s;
            }
        }

        public void SetWarmerState(WarmerState s)
        {
            if (this.WarmerState != s)
            {
                api.SetWarmerState(s);
                this.WarmerState = s;
            }
        }
    }
}
