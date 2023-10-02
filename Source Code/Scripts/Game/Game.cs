public partial class Game : Node2D
{
	public override void _Ready()
	{
		TileMap map = GD.Load<PackedScene>("res://Assets/Templates/Terrain/Field.tscn").Instantiate<TileMap>();
		GetTree().Paused = false;
		Spawn();
	}
	private void Spawn()
	{
		for (int i = 0; i < 10; i++)
		{
			Bydlo bydlo = GD.Load<PackedScene>("res://Assets/Templates/Characters/Bydlo.tscn").Instantiate<Bydlo>();
			AddChild(bydlo);
		}
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("esc"))
		{
			GetNode<Control>("/root/Game/Camera/Pause Menu").Show();
			GetTree().Paused = true;
		}
	}
	private void OnSpawnElapsed()
	{
		Spawn();
	}
}
