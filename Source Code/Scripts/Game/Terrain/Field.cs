public partial class Field : TileMap
{
	private Vector2I groundCords = new(0, 0);
	private Vector2I airCords = new(0, 1);
	private readonly float PropabilityK = 0.16F;
	private readonly float PropabilityB = 1.0F;
	private readonly int size = 5;

	public override void _Ready()
	{
		//Background
		for (int x = -size * 10; x < size * 10; x++)
		{
			for (int y = -size * 10; y < size * 10; y++)
			{
				SetCell(0, new Vector2I(x, y), 0, airCords);
			}
		}
		AddLayer(1);
		Generate();
	}
	private void OnTick()
	{
		for (int x = -size; x < size; x++)
		{
			for (int y = -size; y < size; y++)
			{
				Vector2I CordsOnField = new Vector2I(x, y);
				if (GetCellSourceId(1, CordsOnField, false) != -1)
				{
					Vector2I CellType = GetCellAtlasCoords(1, CordsOnField, false);
					if (CellType[1] == 0 && CellType[0] > 0 && CellType[0] < 8)
					{
						SetCell(1, CordsOnField, 0, new Vector2I(CellType[0] + 1, CellType[1]));
					}
					else if (CellType[1] == 0 && CellType[0] == 8)
					{
						SetCell(1, CordsOnField, 0, new Vector2I(0, 1));
					}
					else if (CellType[1] == 0 && CellType[0] == 0)
					{
						if (GD.Randf() < 0.01F)
						{
							SetCell(1, CordsOnField, 0, new Vector2I(1, 0));
						}
					}
				}
			}
		}
		if (Input.IsActionPressed("regenerate"))
			Generate();
	}
	public void Generate()
	{
		ClearLayer(1);
		for (int x = -size; x <= size; x++)
		{
			for (int y = -size; y <= size; y++)
			{
				SetCell(1, new Vector2I(x, y), 0, groundCords);
			}
		}
	}
}