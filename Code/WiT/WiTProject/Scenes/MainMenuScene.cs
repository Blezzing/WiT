#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion


namespace WiTProject
{
    class MainMenuScene : Scene
    {
        string title = "W.i.T.", subTitle = "Wizards in Trouble";
        protected override void CreateScene()
        {
            TextBlock titleBlock    = new TextBlock(title);
            TextBlock subTitleBlock = new TextBlock(subTitle);

            EntityManager.Add(titleBlock);
            EntityManager.Add(subTitleBlock);
        }
    }
}
