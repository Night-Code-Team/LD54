public partial class Bydlo : Character
{
	public override void Spawn()
	{

	}
	public override void Die()
	{

	}
	public override void Move()
	{

	}
	public override void Attack()
	{

	}
	public override void OnBodyEntered(Node2D body)
	{
	}
	public override void OnBodyExited(Node2D body)
	{
		Fall();
	}
	public override void Fall()
	{
		Die();
	}
	public override int HP { get; set; } = 1;
	public override int Vel { get; set; }
}
