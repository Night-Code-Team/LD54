public abstract partial class Character : CharacterBody2D
{
    public abstract void Spawn();
    public abstract void Die();
    public abstract void Move();
    public abstract void Attack();
    public abstract int HP { get; set; }
    public abstract int Vel { get; set; }
}
