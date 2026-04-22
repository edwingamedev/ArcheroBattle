namespace EdwinGameDev.Combat.Attacks
{
    public interface IAttack
    {
        void Execute();
        float AttackSpeed { get; }
    }
}