using System;
using System.Collections.Generic;

namespace Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> _interactorsMap;

        public InteractorsBase() => _interactorsMap = new Dictionary<Type, Interactor>();

        public void CreateAllInteractors()
        {
            CreateInteractor<BankInteractor>();
        }

        private void CreateInteractor<T>() where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);
            _interactorsMap[type] = interactor;
        }

        public void SendOnCreateToAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
                interactor.OnCreate();
        }

        public void InitializeAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
                interactor.Initialize();
        }

        public void SendOnStartAllInteractors()
        {
            var allInteractors = _interactorsMap.Values;
            foreach (var interactor in allInteractors)
                interactor.OnStart();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T)_interactorsMap[type];
        }
    }
}