public interface IDamageable
{
    public bool IsAvailibleToDamage { get; }
    public void TakeDamage(float damage);
}
