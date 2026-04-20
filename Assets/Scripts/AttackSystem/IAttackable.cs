public interface IAttackable
{
    void TakeDamage(int amount);
    bool IsAlive { get; }
}