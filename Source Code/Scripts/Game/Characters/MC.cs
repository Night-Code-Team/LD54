public partial class MC : Character
{
	private int Rotate()
	{
		if (Input.IsActionPressed("w"))
			return 1;
		if (Input.IsActionPressed("s"))
			return 2;
		if (Input.IsActionPressed("a"))
			return 3;
		if (Input.IsActionPressed("d"))
			return 4;
		return 0;
	}
	public override void _PhysicsProcess(double delta)
	{
		Move();
		Attack();
		GetNode<Camera2D>("/root/Game/Field/Camera").Position = Position;
		Vector2 mousePos = GetViewport().GetMousePosition();
		GetNode<ColorRect>("Aim").Position = new(mousePos.X - 980, mousePos.Y - 560);
	}
	public override void Spawn()
	{

	}
	public override void Die()
	{

	}
	public override void Move()
	{
		Vector2 inputDirection = Input.GetVector("a", "d", "w", "s");
		Velocity = inputDirection * Vel;
		GetNode<AnimatedSprite2D>("Texture").Frame = Rotate();
		MoveAndSlide();
	}
	public override void Attack()
	{
		if (Input.IsActionJustPressed("ЛКМ"))
		{
			CharacterBody2D pizdyulina = GD.Load<PackedScene>("res://Assets/Templates/Objects/Pizdyulina.tscn").Instantiate<CharacterBody2D>();
			pizdyulina.Position = Position;
			Vector2 aimPos = GetViewport().GetMousePosition();
			float angle = GetAngleTo(new(aimPos.X + Position.X - 960, aimPos.Y + Position.Y - 540));
			pizdyulina.Rotation = angle;
			pizdyulina.Velocity = new(1000 * (float)Math.Cos(angle), 1000 * (float)Math.Sin(angle));
			GetNode("/root/Game/Field").AddChild(pizdyulina);
		}
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
	public override int HP { get; set; } = 3;
	public override int Vel { get; set; } = 400;
}
