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
	public override void _PhysicsProcess(double delta)
	{
		if (LostGround)
			FallTimer -= delta;
		if (FallTimer < 0.0F)
			Fall();
	}
	public override void OnBodyEntered(Node2D body)
	{
		LostGround = false;
		FallTimer = 0.1F;
	}
	public override void OnBodyExited(Node2D body)
	{
		LostGround = true;
		FallTimer = 0.1F;
	}
	public override void Fall()
	{
		Die();
	}
	public override int HP { get; set; } = 1;
	public override int Vel { get; set; }
	public override double FallTimer { get; set; } = 0.1;
	public override bool LostGround { get; set; } = false;
}
