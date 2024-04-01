using System;

namespace Architecture
{
    public static class Bank
    {
        public static event Action OnBankInitializeEvent;

        public static bool IsInitialized { get; private set; }

        private static BankInteractor _bankInteractor;

        public static int Coins
        {
            get
            {
                CheckClass();
                return _bankInteractor.Coins;
            }
        }

        public static void Initialize(BankInteractor interactor)
        {
            _bankInteractor = interactor;
            IsInitialized = true;
            OnBankInitializeEvent?.Invoke();
        }

        public static bool IsEnoughCoins(int value)
        {
            CheckClass();
            return _bankInteractor.IsEnoughCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.AddCoins(sender, value);
        }

        public static void Spend(object sender, int value)
        {
            CheckClass();
            _bankInteractor.Spend(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Bank is not initialize yet");
        }
    }
}