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
        string title    = "W. i. T.", 
               subTitle = "Wizards in Trouble";
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
            Button newGameBut = new Button()
            {
                Text  = "New Game!",
                Width = 250,
                Foreground          = Color.Black,
                BackgroundColor     = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin              = new Thickness(0, 450, 0, 0),
            };
            Button loadGameBut = new Button()
            {
                Text = "Load Game!",
                Width = 250,
                Foreground = Color.Black,
                BackgroundColor = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 500, 0, 0),
            };
            Button creditsBut = new Button()
            {
                Text = "Credits!",
                Width = 250,
                Foreground = Color.Black,
                BackgroundColor = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 550, 0, 0),
            };
            Button quitBut = new Button()
            {
                Text = "Quit :(",
                Width = 250,
                Foreground = Color.Black,
                BackgroundColor = Color.Gainsboro,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 600, 0, 0),
            };

            EntityManager.Add(newGameBut);
            EntityManager.Add(loadGameBut);
            EntityManager.Add(creditsBut);
            EntityManager.Add(quitBut);

            newGameBut.Click  += newGameBut_Click;
            loadGameBut.Click += loadGameBut_Click;
            creditsBut.Click  += creditsBut_Click;
            quitBut.Click     += quitBut_Click;
        }

        void newGameBut_Click(object sender, EventArgs e)
        {
            WaveServices.ScreenContextManager.To(new ScreenContext(new TestScene()));
        }

        void loadGameBut_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void creditsBut_Click(object sender, EventArgs e)
        {
            WaveServices.ScreenContextManager.To(new ScreenContext(new MainMenuCreditsScene()));
        }

        void quitBut_Click(object sender, EventArgs e)
        {
            WaveServices.Platform.Exit();
        }
    }
}
