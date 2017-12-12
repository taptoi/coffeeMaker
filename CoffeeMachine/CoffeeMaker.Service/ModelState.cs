using System;
namespace CoffeeMaker.Service
{
    internal class ModelState : IEquatable<ModelState>
    {

        public string Id { get; }
        public ISystemState NominalState { get; }

        public ModelState(string id, ISystemState systemState)
        {
            this.Id = id;
            this.NominalState = systemState;
        }

        public bool Equals(ModelState other)
        {
            if (other == null) return false;
            return this.Id == other.Id &&
                   this.NominalState == other.NominalState;
        }
    }
}
