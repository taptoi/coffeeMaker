using CoffeeMaker.Interface;
using System.Threading;
using System.Threading.Tasks;
using CoffeeMaker.API;
using System.ComponentModel.Composition;

namespace CoffeeMaker.Service
{

    [Export(typeof(ICoffeeMakerService)), PartCreationPolicy(CreationPolicy.Shared)]
    public class CoffeeMakerService : ICoffeeMakerService
    {
        private bool running = false;
        [Import]
        public CoffeeMakerAPI Api { get; set; }
        private IModelStateController modelStateController;
        private SystemControl systemControl;
        private ISystemMonitor monitor;

        [ImportingConstructor]
        public CoffeeMakerService()
        {

        }

        public void Start(int intervalMs)
        {
            Initialize();
            if (!running)
            {
                running = true;
                Task.Run(() => UpdateStateLoop(intervalMs));
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void UpdateStateLoop(int intervalMs)
        {
            var state = new ModelStateContract().GetById("IdleEmpty");
            while(running)
            {
                state = modelStateController.GetNextState(state);
                Thread.Sleep(intervalMs);
            }
        }

        private void Initialize()
        {
            if (systemControl == null)
                systemControl = new SystemControl(Api,
                                                  BoilerState.OFF,
                                                  IndicatorState.OFF,
                                                  ReliefValveState.CLOSED);
            if (monitor == null)
                monitor = new SystemMonitor(Api, systemControl);
            if (modelStateController == null)
                modelStateController = new ModelStateController(monitor, 
                                                                systemControl, 
                                                                new ModelStateContract(), 
                                                                Api);
        }
    }
}
