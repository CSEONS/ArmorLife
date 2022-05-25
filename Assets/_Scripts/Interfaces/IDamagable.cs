public interface IDamagable
{
    float Health { get; set; }

    void ApplyDamage(float damage);
}
