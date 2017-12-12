using System;
using System.Linq;
using System.Collections.Generic;
using CoffeeMaker.API;

namespace CoffeeMaker.Service
{
    internal class ModelStateContract : IModelStateMapper
    {
        private readonly List<IModelState> modelStateMap =
            new List<IModelState>
        {
            new ModelState("IdleEmpty",
                           new SystemState(WarmerPlateStatus.WARMER_EMPTY,
                                           BoilerStatus.EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.OFF,
                                           WarmerState.OFF,
                                           IndicatorState.ON,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("IdlePot",
                           new SystemState(WarmerPlateStatus.POT_EMPTY,
                                           BoilerStatus.EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.OFF,
                                           WarmerState.OFF,
                                           IndicatorState.ON,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("ReadyToBrew",
                           new SystemState(WarmerPlateStatus.POT_EMPTY,
                                           BoilerStatus.NOT_EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.OFF,
                                           WarmerState.OFF,
                                           IndicatorState.ON,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("StartBrewingRequested",
                           new SystemState(WarmerPlateStatus.POT_EMPTY,
                                           BoilerStatus.NOT_EMPTY,
                                           BrewButtonStatus.PUSHED,
                                           BoilerState.OFF,
                                           WarmerState.OFF,
                                           IndicatorState.ON,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("BrewingNotSustaining",
                           new SystemState(WarmerPlateStatus.POT_EMPTY,
                                           BoilerStatus.NOT_EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.ON,
                                           WarmerState.OFF,
                                           IndicatorState.OFF,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("BrewingSustaining",
                           new SystemState(WarmerPlateStatus.POT_NOT_EMPTY,
                                           BoilerStatus.NOT_EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.ON,
                                           WarmerState.ON,
                                           IndicatorState.OFF,
                                           ReliefValveState.CLOSED)) as IModelState,
            new ModelState("Interrupted",
                           new SystemState(WarmerPlateStatus.WARMER_EMPTY,
                                           BoilerStatus.NOT_EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.ON,
                                           WarmerState.OFF,
                                           IndicatorState.OFF,
                                           ReliefValveState.OPEN)) as IModelState,
            new ModelState("CoffeeReady",
                           new SystemState(WarmerPlateStatus.POT_NOT_EMPTY,
                                           BoilerStatus.EMPTY,
                                           BrewButtonStatus.NOT_PUSHED,
                                           BoilerState.OFF,
                                           WarmerState.ON,
                                           IndicatorState.ON,
                                           ReliefValveState.CLOSED)) as IModelState
            
        };

        public IModelState GetById(string id)
        {
            return this.modelStateMap.SingleOrDefault(s => s.StateId == id);
        }

        public IModelState GetNominalStateOrCurrentState(
            IModelState currentModelState, 
            ISystemState currentSystemState)
        {
            var newModelState = 
                this.modelStateMap.SingleOrDefault(s => s.NominalState == currentSystemState);
            if (newModelState != null)
                return newModelState;
            return currentModelState;
        }
    }
}
