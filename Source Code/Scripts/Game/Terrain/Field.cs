public partial class Field : TileMap
{
	[Export]
	private Vector2I groundCords = new(0, 0);
	[Export]
	private Vector2I airCords = new(0, 1);
	[Export]
	private float PropabilityK = 0.32F;
	[Export]
	private float PropabilityB = 1.0F;
	
	public override void _Ready()
	{
		//Background
		for (int x = -55; x < 55; x++)
		{
			for (int y = -55; y < 55; y++)
			{
				SetCell(0, new Vector2I(x, y), 0, airCords);
			}
		}
		AddLayer(1);
		Generate();
	}
	private void OnTick()
	{
		for (int x = -4; x < 4; x++)
		{
			for (int y = -4; y < 4; y++)
			{
				if (GetCellSourceId(1, new Vector2I(x, y), false) != -1)
				{
					
				}
			}
		}
		if (Input.IsActionPressed("regenerate"))
			Generate();
	}
	public void Generate()
	{
		ClearLayer(1);
		for (int x = -2; x <= 2; x++)
		{
			for (int y = -2; y <= 2; y++)
			{
				float distanceToCenter = Mathf.Sqrt(x * x + y * y);
				if (distanceToCenter < 1)
				{
					SetCell(1, new Vector2I(x, y), 0, groundCords);
				}
				else
				{
					float DestroyPropability = PropabilityK*(distanceToCenter - PropabilityB);
					if (GD.Randf() > DestroyPropability)
					{
						SetCell(1, new Vector2I(x, y), 0, groundCords);
					}
				}
			}
		}
	}
}



