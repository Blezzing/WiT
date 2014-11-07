#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Components.Transitions;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace WiTProject
{
    class MainMenuOptionsScene : Scene
    {
        private ScreenTransition transition = new CrossFadeTransition(new TimeSpan(0, 0, 0, 1, 200));
        string title    = "W. i. T.",
               subTitle = "Wizards in Trouble";
        protected override void CreateScene()
        {
            FixedCamera2D camera2D = new FixedCamera2D("Camera2D");
            camera2D.BackgroundColor = Color.AliceBlue;

            CreateTitle();
            CreateOptions();
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

        private void CreateOptions()
        {
            TextBlock volumeBlock = new TextBlock("VolumeBlock")
            {
                Width               = 200,
                Text                = "Master volume:",
                Foreground          = Color.Black,
                TextAlignment       = TextAlignment.Right,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin              = new Thickness(-150, 300, 0, 0),
            };
            Slider volumeSlider = new Slider("VolumeSlider")
            {
                Width               = 200,
                TextColor           = Color.Black,
                Value               = 75,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin              = new Thickness(100, 300, 0, 0),
            };

            EntityManager.Add(volumeBlock);
            EntityManager.Add(volumeSlider);
        }

        private void CreateButtons()
        {
            Button backBut = new Button()
            {
                Text = "Return",
                Width = 250,
                Foreground = Color.Black,
                BackgroundColor = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 600, 0, 0),
            };
            backBut.Click += backBut_Click;

            EntityManager.Add(backBut);
        }

        void backBut_Click(object sender, EventArgs e)
        {
            WaveServices.ScreenContextManager.To(new ScreenContext(new MainMenuScene()), transition, true);
        }
    }
}
