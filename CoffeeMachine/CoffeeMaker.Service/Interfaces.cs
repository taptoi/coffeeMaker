using System;
using System.Collections.Generic;
using CoffeeMaker.API;

namespace CoffeeMaker.Service
{
    
    internal interface ISystemControlCommands
    {
        void SetBoilerState(BoilerState s);
        void SetWarmerState(WarmerState s);
        void SetIndicatorState(IndicatorState s);
        void SetReliefValveState(ReliefValveState s);
    }


    internal interface IModelStateController
    {
        IModelState GetNextState(IModelState currentState);
    }

    internal interface IModelStateMapper
    {
        IModelState GetNominalStateOrCurrentState(
            IModelState currentModelState, 
            ISystemState currentSystemState);
    }

    internal interface IModelState
    {
        string StateId { get; }
        ISystemState NominalState { get; }
        IList<Action> GetTransitionActions(
            ISystemState currentState,
            CoffeeMakerAPI api);
    }


    internal interface ISystemControlState
    {
        BoilerState BoilerState { get; }
        IndicatorState IndicatorState { get; }
        ReliefValveState ReliefValveState { get; }
        WarmerState WarmerState { get; }

    }

    internal interface ISensorState
    {
        WarmerPlateStatus WarmerPlateStatus { get; }
        BoilerStatus BoilerStatus { get; }
        BrewButtonStatus BrewButtonStatus { get; }
    }

    internal interface ISystemState : ISystemControlState, 
                                      ISensorState,
                                      IEquatable<ISystemState>
    {}

    internal interface ISystemMonitor
    {
        ISystemState GetSystemState();
    }

}
