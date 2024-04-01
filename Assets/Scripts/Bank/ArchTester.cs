using System.Collections;
using UnityEngine;

namespace Architecture
{
    public class ArchTester : MonoBehaviour
    {
        private BankRepository _bankRepository;
        private BankInteractor _bankInteractor;

        public static InteractorsBase _interactorsBase;
        public static RepositoriesBase _repositoriesBase;

        private void Awake()
        {
            _bankRepository = new BankRepository();
            _bankRepository.Initialize();

            _bankInteractor = new BankInteractor();
            _bankInteractor.Initialize();
        }

        private void Start() => StartCoroutine(StartGameRoutine());

        private IEnumerator StartGameRoutine()
        {
            _interactorsBase = new InteractorsBase();
            _repositoriesBase = new RepositoriesBase();

            _interactorsBase.CreateAllInteractors();
            _repositoriesBase.CreateAllRepositories();

            yield return null;

            _interactorsBase.SendOnCreateToAllInteractors();

            yield return null;

            _interactorsBase.InitializeAllInteractors();
            _repositoriesBase.InitializeAllRepositories();

            yield return null;

            _interactorsBase.SendOnStartAllInteractors();

            yield return null;
        }

        private void Update()
        {
            if (!Bank.IsInitialized)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Bank.AddCoins(this, 5);
                Debug.Log($"add coins (5), {Bank.Coins}");
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Bank.Spend(this, 1);
                Debug.Log($"remove coins (1), {Bank.Coins}");
            }
        }
    }
}