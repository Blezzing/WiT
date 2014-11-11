﻿#region Using Statements
using System;
using System.Collections.Generic;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Managers;
#endregion

namespace WiTProject
{
    public class Level : Scene
    {
        private MapDesign _mapDesign;
        private Spawner _spawner;
        private FightJudge _judge;

        public Level(MapDesign mapDesign) : base()
        {
            _mapDesign = mapDesign;
        }

        protected override void CreateScene()
        {
            //Setup
            _judge = new FightJudge(this);
            _spawner = new Spawner(this, _judge);

            this.PaintFloor();
            _spawner.SpawnCamera2D();
            _spawner.SpawnPlayer(300,300);
        }

        private void PaintFloor()
        {
            for (int y = 0; y < _mapDesign.FloorHeight; y++)
            {
                for (int x = 0; x < _mapDesign.FloorWidth; x++)
                {
                    MakeFloorTile(x, y, _mapDesign.TileFloor[y, x]);
                }
            }
        }

        private void MakeFloorTile(int posX, int posY, TileNumber tileNum)
        {

            EntityManager.Add(
                new Entity()
                    .AddComponent(new Transform2D() { Origin = Vector2.Center, Position = new Vector2(posX * TileData.TileSize, posY * TileData.TileSize) })
                    .AddComponent(new Sprite(TileData.GetTile(TileEnviroment.Grass, tileNum)))
                    .AddComponent(new SpriteRenderer(DefaultLayers.Additive)));
        }
    }
}