public partial class Field : TileMap
{
	private readonly float startRadius = 2.5F;
	[Export]
	private Vector2I groundCords = new(0, 0);
	[Export]
	private Vector2I airCords = new(8, 0);

	public override void _Ready()
	{
		for (int x = -55; x < 55; x++)
		{
			for (int y = -55; y < 55; y++)
			{
				float distanceToCenter = Mathf.Sqrt(x * x + y * y);
				if (distanceToCenter < startRadius)
				{
					SetCell(0, new Vector2I(x, y), 0, groundCords);
				}
				else
				{
					SetCell(0, new Vector2I(x, y), 0, airCords);
				}
			}
		}
	}
}
