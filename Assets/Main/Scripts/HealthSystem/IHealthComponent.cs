using UniRx;

namespace TestGame.HealthSystem
{
    public interface IHealthComponent
    {
        void Damage(int amount);
        ISubject<Unit> OnDead {  get; }
        float Health { get; }
    }
}