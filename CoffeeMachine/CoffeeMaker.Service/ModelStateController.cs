using System;
using CoffeeMaker.API;
using System.Linq;
namespace CoffeeMaker.Service
{
    internal class ModelStateController : IModelStateController
    {
        private readonly ISystemMonitor monitor;
        private readonly ISystemControlCommands controller;
        private readonly CoffeeMakerAPI api;
        private readonly IModelStateMapper mapper;


        public ModelStateController(ISystemMonitor monitor,
                                    ISystemControlCommands controller,
                                    IModelStateMapper mapper,
                                    CoffeeMakerAPI api)
        {
            this.monitor = monitor;
            this.controller = controller;
            this.mapper = mapper;
            this.api = api;
        }

        public IModelState GetNextState(IModelState currentState)
        {
            var systemState = this.monitor.GetSystemState();
            var actions = currentState.GetTransitionActions(systemState, api);
            foreach (var a in actions)
                a();
            return mapper.GetNominalStateOrCurrentState(currentState, systemState);
        }

    }
}
