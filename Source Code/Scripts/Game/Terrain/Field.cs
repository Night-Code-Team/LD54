public partial class Field : TileMap
{
	[Export]
	private PackedScene PackedPortal;
	
	[Export]
	private PackedScene PackedKey;
	
	private Node2D Portal;
	
	private List<Node2D> Keys = new List<Node2D>();
	
	private Vector2I GroundCords = new(0, 0);
	
	private Vector2I AirCords = new(0, 1);
	
	private readonly int Size = 4;
	
	private const float CellSize = 250;
	
	private const int KeyNumber = 3;

	public override void _Ready()
	{
		for (int x = -Size * 10; x < Size * 10; x++)
		{
			for (int y = -Size * 10; y < Size * 10; y++)
			{
				SetCell(0, new Vector2I(x, y), 0, AirCords);
			}
		}
		GenerateBase();
		Portal = PackedPortal.Instantiate<Node2D>();
		Portal.Position = Scale*CellSize/2;
		AddChild(Portal);
		float keysSpawnDirection = GD.Randf()*Mathf.Pi;
		for (int i = 0; i < KeyNumber; i++)
		{
			Keys.Add(PackedKey.Instantiate<Node2D>());
			float distanceFromCenter = (float)((Mathf.Sqrt(GD.Randf()/4)+0.4)*Size*CellSize);
			Keys[i].Position = new Vector2(Mathf.Sin(keysSpawnDirection), Mathf.Cos(keysSpawnDirection)) * distanceFromCenter;
			AddChild(Keys[i]);
			keysSpawnDirection += Mathf.Pi*2/KeyNumber;
		}
	}
	
	private void OnTick()
	{
		for (int x = -Size; x < Size; x++)
		{
			for (int y = -Size; y < Size; y++)
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
	}
	
	public void GenerateBase()
	{
		AddLayer(1);
		ClearLayer(1);
		for (int x = -Size; x <= Size; x++)
		{
			for (int y = -Size; y <= Size; y++)
			{
				SetCell(1, new Vector2I(x, y), 0, GroundCords);
			}
		}
	}
}
