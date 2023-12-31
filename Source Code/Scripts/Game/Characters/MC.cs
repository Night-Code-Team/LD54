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
		GetNode<Camera2D>("/root/Game/Camera").Position = Position;
		Vector2 mousePos = GetViewport().GetMousePosition();
		GetNode<ColorRect>("Aim").Position = new(mousePos.X - 980, mousePos.Y - 560);
		if (LostGround)
			FallTimer -= delta;
		if (FallTimer < 0.0F)
			Fall();
	}
	public override void Spawn()
	{

	}
	public override void Die()
	{
		GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
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
			Pizdyulina pizdyulina = GD.Load<PackedScene>("res://Assets/Templates/Objects/Pizdyulina.tscn").Instantiate<Pizdyulina>();
			pizdyulina.Position = Position;
			Vector2 aimPos = GetViewport().GetMousePosition();
			float angle = GetAngleTo(new(aimPos.X + Position.X - 960, aimPos.Y + Position.Y - 540));
			pizdyulina.Rotation = angle;
			pizdyulina.Scale = new(0.5f, 0.5f);
			pizdyulina.Velocity = new(pizdyulina.Vel * (float)Math.Cos(angle), pizdyulina.Vel * (float)Math.Sin(angle));
			GetNode("/root/Game/Field").AddChild(pizdyulina);
		}
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
	public void OnShieldTimerElapsed()
	{
		Shielded = false;
		GetNode<ColorRect>("Shield").Hide();
	}
	public override int HP { get; set; } = 3;
	public override int Vel { get; set; } = 200;
	public override double FallTimer { get; set; } = 0.1F;
	public override bool LostGround { get; set; } = false;
	public bool Shielded { get; set; } = false;
}
