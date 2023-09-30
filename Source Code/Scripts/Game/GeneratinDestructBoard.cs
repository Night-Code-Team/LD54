using Aardvark.Base.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD54.Scripts.Game
{

    public partial class GeneratinDestructBoard : Spatial 
    {
        
        //url Tile
        public TileData[,] _tiles { get; private set; } = new TileData[5,5];

        public void GennerationBoardTiles()
        {
            for (int i = 0; i < 5; i++)
                for (int d = 0; d < 5; d++)
                {
                    ColorRect tile = GD.Load<ColorRect>($"res://Assets/Templates/tile1.tscn");
                    tile.Material = GD.Load<Material>($"res://Assets/Templates/tile1.tscn");
                    tile.MarginTop
                }
            
        }
        private void RandomGenerator()
        {

        }

    }
}
