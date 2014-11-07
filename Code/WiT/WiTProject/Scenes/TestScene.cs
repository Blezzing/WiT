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

        protected override void CreateScene()
        {
            //Setup spawner
            _spawner = new Spawner(this);

            // Create a 2D camera
            var camera2D = new FixedCamera2D("Camera2D") { BackgroundColor = Color.LightGreen}; // Transparent background need this clearFlags.
            EntityManager.Add(camera2D);

            //Add player
            _spawner.Player(50, 50);


        }

        protected override void Start()
        {
            base.Start();

            // This method is called after the CreateScene and Initialize methods and before the first Update.
        }
    }
}
