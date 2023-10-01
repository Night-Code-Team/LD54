public abstract partial class Character : CharacterBody2D
{
	public abstract void Spawn();
	public abstract void Die();
	public abstract void Move();
	public abstract void Attack();
	public abstract void OnBodyEntered(Node2D body);
	public abstract void OnBodyExited(Node2D body);
	public abstract void Fall();
	public abstract int HP { get; set; }
	[Export]
	public abstract int Vel { get; set; }
}
