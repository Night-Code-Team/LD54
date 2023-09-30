public partial class HPBar : Control
{
	public override void _Ready()
	{
		for (int i = 0; i < 3; i++)
		{
			ColorRect HP = GD.Load<PackedScene>("res://Assets/Templates/Interface/HP.tscn").Instantiate<ColorRect>();
			HP.Position = new Vector2(60 * i, 0);
			AddChild(HP);
		}
	}
}
