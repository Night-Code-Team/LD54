public partial class Key : Sprite2D
{
	[Export]
	private float Speed = 600.0F;
	private bool IsPickedUp = false;
	private Node2D Portal;
	
	public override void _Ready()
	{
		Portal = GetNode<Node2D>("portal");
	}
	public override void _Process(double delta)
	{
		if (IsPickedUp)
		{
			Vector2 CurrentPosition = Position;
			Position += (Portal.Position - CurrentPosition).Normalized() * Speed;
		}
	}
	private void OnPrayerEntered(Node2D body)
	{
		IsPickedUp = true;
	}
}
