using Godot;
using System;

public partial class Island : TileMap
{
	[Export]
	int startRadius = 25;
	[Export]
	Vector2I groundCords = new Vector2I(0, 0);
	[Export]
	Vector2I airCords = new Vector2I(8, 0);
	
	public override void _Ready()
	{
		for (int x=-55; x<55; x++)
		{
			for (int y=-55; y<55; y++)
			{
				float distanceToCenter = Mathf.Sqrt(x*x + y*y);
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

	public override void _Process(double delta)
	{
	}
}
