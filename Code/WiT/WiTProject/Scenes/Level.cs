#region Using Statements
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

            //Funktionskald
            _spawner.SpawnFloor(_mapDesign);
            EntityManager.Add(new FreeCamera2D("test") { BackgroundColor = Color.White });
            _spawner.SpawnPlayer(300,300);
        }
    }
}
