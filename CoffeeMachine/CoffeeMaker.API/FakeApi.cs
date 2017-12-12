using System;
using System.ComponentModel.Composition;

namespace CoffeeMaker.API
{
    [Export(typeof(CoffeeMakerAPI)), PartCreationPolicy(CreationPolicy.Shared)]
    public class FakeApi : CoffeeMakerAPI
    {
        [ImportingConstructor]
        public FakeApi()
        {
            
        }

        public BoilerStatus GetBoilerStatus()
        {
            return BoilerStatus.NOT_EMPTY;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            return BrewButtonStatus.NOT_PUSHED;
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            return WarmerPlateStatus.POT_EMPTY;
        }

        public void SetBoilerState(BoilerState s)
        {

        }

        public void SetIndicatorState(IndicatorState s)
        {

        }

        public void SetReliefValveState(ReliefValveState s)
        {

        }

        public void SetWarmerState(WarmerState s)
        {

        }
    }
}
