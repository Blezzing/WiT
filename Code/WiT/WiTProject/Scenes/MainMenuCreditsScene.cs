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
    class MainMenuCreditsScene : Scene
    {
        string title = "W. i. T.",
               subTitle = "Wizards in Trouble",
               description = "cw";
        protected override void CreateScene()
        {
            FixedCamera2D camera2D = new FixedCamera2D("Main2DCamera");
            camera2D.BackgroundColor = Color.AliceBlue;

            CreateTitle();
            CreateButtons();

            EntityManager.Add(camera2D);
        }

        private void CreateTitle()
        {
            TextBlock titleBlock = new TextBlock("title")
            {
                Text = title,
                FontPath = "Content/Fonts/titleFont.spr",
                Width = 300,
                Foreground = Color.Black,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 25, 0, 0)
            };
            TextBlock subTitleBlock = new TextBlock("subTitle")
            {
                Text = subTitle,
                FontPath = "Content/Fonts/SUBtitleFont.spr",
                Width = 300,
                Foreground = Color.Black,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 175, 0, 0)
            };

            EntityManager.Add(titleBlock);
            EntityManager.Add(subTitleBlock);
        }

        private void CreateButtons()
        {
            Button backBut = new Button()
            {
                Text = "New Game!",
                Width = 250,
                Foreground = Color.Black,
                BackgroundColor = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 450, 0, 0),
            };

            EntityManager.Add(backBut);
        }
    }
}
