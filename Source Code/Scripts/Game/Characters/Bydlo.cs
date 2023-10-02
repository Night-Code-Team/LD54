public partial class Bydlo : Character
{
	private static readonly Random rng = new();
	private Vector2 direction;
	public override void _Ready()
	{
		Spawn();
	}
	public override void Spawn()
	{
		Position = new(rng.Next(-1408, 1408), rng.Next(-1408, 1408));
	}
	public override void Die()
	{
		QueueFree();
	}
	public override void Move()
	{
		Vector2 dest = GetNode<CharacterBody2D>("/root/Game/Field/MC").Position;
		direction = (dest - Position).Normalized() * 4;
	}
	public override void Attack()
	{

	}
	public override void _PhysicsProcess(double delta)
	{
		Move();
		KinematicCollision2D collide = MoveAndCollide(direction);
		if (collide != null)
		{

		}

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
	public override int Vel { get; set; } = 180;
	public override double FallTimer { get; set; } = 0.1;
	public override bool LostGround { get; set; } = false;
}
