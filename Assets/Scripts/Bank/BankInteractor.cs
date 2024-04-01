namespace Architecture
{
    public class BankInteractor : Interactor
    {
        public BankRepository _repository;

        public int Coins => _repository.Coins;

        public override void OnCreate()
        {
            _repository = ArchTester._repositoriesBase.GetRepositories<BankRepository>();
        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnoughCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
            _repository.Coins += value;
            _repository.Save();
        }

        public void Spend(object sender, int value)
        {
            _repository.Coins -= value;
            _repository.Save();
        }
    }
}