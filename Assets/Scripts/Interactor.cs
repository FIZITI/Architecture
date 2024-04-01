namespace Architecture
{
    public abstract class Interactor
    {
        public virtual void Initialize() { }
        public virtual void OnCreate() { }
        public virtual void OnStart() { }
    }
}