using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using System;

namespace LD54.Scripts.Game
{
    public partial class GenerationBoar : Node2D
    {
        

    
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        [Export(PropertyHint.Range, "0,100,5")]
        int iniChance;


        [Export(PropertyHint.Range, "1,8,1")]
        int birthLimit;

        [Export(PropertyHint.Range, "1,8,1")]
        int deathLimit;


        [Export(PropertyHint.Range, "1,10,1")]
        int numR;

        [Export]
        public Godot.TileMap topMap, bottomMap;
        [Export]
        public int TopTile, BotTile;
        [Export]
        public Vector2 tMapSize;


        int width, height;
        Random rnd;

        Vector2[] BoundsInt;
        int[,] terrainMap;




        // Called when the node enters the scene tree for the first tllime.
        public override void _Ready()
        {
            rnd = new Random();
            BoundsInt = new Vector2[9];
            topMap = GetChild(0) as Godot.TileMap;
            bottomMap = GetChild(1) as Godot.TileMap;



            int j = 0;
            for (int i = -1; i < 2; i++)
            {
                BoundsInt[j] = new Vector2(i, -1);
                BoundsInt[j + 1] = new Vector2(i, 0);
                BoundsInt[j + 2] = new Vector2(i, 1);

                j += 3;

            }


        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public void _Process(float delta)
        {

            if (Input.IsActionJustPressed("Mouse_left"))
            {
                doSim(numR);

            }

            if (Input.IsActionJustPressed("Mouse_right"))
            {
                PackedScene packed_scene = new PackedScene();
                packed_scene.Pack(GetTree().CurrentScene);
                ResourceSaver.Save(packed_scene, $"res://Assets/Scenes/Game/GameMap.tscn");

            }
            if (Input.IsActionJustPressed("Mouse_middle"))
            {
                clearMap(true);

            }


        }


        public void doSim(int numR)
        {
            clearMap(false);
            width = (int)tMapSize.X;
            height = (int)tMapSize.Y;
            if (terrainMap == null)
            {
                terrainMap = new int[width, height];
                initPos();
            }

            for (int i = 0; i < numR; i++)
            {
                terrainMap = neighbCheck(terrainMap);
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //if (terrainMap[x, y] == 1)
                    //{
                    //    topMap.SetCell(-x + width / 2, -y + height / 2, TopTile);
                    //    topMap.SetCell(-x + width / 2, -y + height / 2, TopTile);
                    //}
                    //bottomMap.SetCell(-x + width / 2, -y+ height / 2, BotTile);

                }
                //topMap.UpdateBitmaskRegion(new Vector2(-width / 2, -height / 2), new Vector2(width / 2, height / 2));

            }






        }

        private int[,] neighbCheck(int[,] oldPos)
        {
            int[,] newPos = new int[width, height];
            int neighb;

            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    neighb = 0;
                    foreach (Vector2 b in BoundsInt)
                    {
                        if (b.X == 0 && b.Y == 0) continue;
                        if (x + b.X >= 0 && x + b.X < width && y + b.Y >= 0 && y + b.Y < height)
                        {
                            neighb += oldPos[x + (int)b.X, y + (int)b.Y];
                        }
                        else
                        {
                            neighb++;
                        }

                        if (oldPos[x, y] == 1)
                        {
                            if (neighb < deathLimit) newPos[x, y] = 0;
                            else
                            {
                                newPos[x, y] = 1;

                            }

                        }

                        if (oldPos[x, y] == 0)
                        {
                            if (neighb > birthLimit) newPos[x, y] = 1;
                            else
                            {
                                newPos[x, y] = 0;

                            }

                        }

                    }




                }

            }



            return newPos;

        }




        private void initPos()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    terrainMap[x, y] = rnd.Next(1, 101) < iniChance ? 1 : 0;

                }

            }

        }




        public void clearMap(bool complete)
        {
            topMap.Clear();
            bottomMap.Clear();

            if (complete)
            {
                terrainMap = null;
            }


        }






    }

}

