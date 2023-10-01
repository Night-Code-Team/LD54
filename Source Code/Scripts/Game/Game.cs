public partial class Game : Node2D
{
	public override void _Ready()
	{
		TileMap map = GD.Load<PackedScene>("res://Assets/Templates/Terrain/Field.tscn").Instantiate<TileMap>();
	}
}
