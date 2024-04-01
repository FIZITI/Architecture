using UnityEngine;

namespace Architecture {

    public class BankRepository : Repository
    {
        private const string _key = "BANK_KEY";

        public int Coins { get; set; }

        public override void Initialize()
        {
            Coins = PlayerPrefs.GetInt(_key, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(_key, Coins);
        }
    }
}