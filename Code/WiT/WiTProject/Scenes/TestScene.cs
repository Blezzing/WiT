#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
#endregion

namespace WiTProject
{
    public class TestScene : Scene
    {
        private Spawner _spawner;
        private FightJudge _judge;

        protected override void CreateScene()
        {
            //Setup
            _judge = new FightJudge(this);
            _spawner = new Spawner(this, _judge);

            //Spawn stuff
            _spawner.SpawnCamera2D();
            //_spawner.SpawnFocusCamera2D();
            _spawner.SpawnPlayer(50, 50);

            _spawner.SpawnIdleEntity("IdleDood", 200, 200);
        }

        protected override void Start()
        {
            base.Start();
        }
    }
}
