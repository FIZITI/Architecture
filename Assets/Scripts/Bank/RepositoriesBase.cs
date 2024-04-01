using System;
using System.Collections.Generic;

namespace Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> _repositoriesMap;

        public RepositoriesBase() => _repositoriesMap = new Dictionary<Type, Repository>();

        public void CreateAllRepositories()
        { 
            CreateRepositories<BankRepository>();
        }

        private void CreateRepositories<T>() where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            _repositoriesMap[type] = repository;
        }

        public void InitializeAllRepositories()
        {
            var allRepositories = _repositoriesMap.Values;
            foreach (var interactor in allRepositories)
                interactor.Initialize();
        }

        public T GetRepositories<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)_repositoriesMap[type];
        }
    }
}