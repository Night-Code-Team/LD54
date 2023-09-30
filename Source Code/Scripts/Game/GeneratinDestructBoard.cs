using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD54.Scripts.Game
{

    public partial class GeneratinDestructBoard : CollisionObject2D
    {
        
        //url Tile
        public TileData[,] _tiles { get; private set; } = new TileData[5,5];

    }
}
