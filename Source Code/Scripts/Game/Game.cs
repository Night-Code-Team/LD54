public partial class Game : Node2D
{
	public override void _Ready()
	{
		TileMap map = GD.Load<PackedScene>("res://Assets/Templates/Terrain/Field.tscn").Instantiate<TileMap>();
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("esc"))
		{
			GetNode<Control>("/root/Game/Camera/Pause Menu").Show();
			GetTree().Paused = true;
		}
	}
}
