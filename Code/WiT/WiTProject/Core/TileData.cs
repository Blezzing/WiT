#region Using Statements
using System;
using System.Collections.Generic;
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
    public enum TileNumber
    {
        TopLeft = 0,
        TopMiddle,
        TopRight,
        MiddleLeft,
        MiddleMiddle,
        MiddleRight,
        BottomLeft,
        BottomMiddle,
        BottomRight,
        InverseTopLeft,
        InverseTopRight,
        InverseBottomLeft,
        InverseBottomRight,
        InverseMiddleMiddle
    }

    public enum TileEnviroment
    {
        Debug = 0,
        Grass
    }

    public static class TileData
    {
        private static Dictionary<TileEnviroment, Dictionary<TileNumber, Texture2D>> _data = new Dictionary<TileEnviroment, Dictionary<TileNumber, Texture2D>>();

        public static readonly int TileSize = 200;
        public static readonly float TileScale = 1f;


        public static void Build()
        {
            /*//Grass enviroment
            _data.Add(TileEnviroment.Grass, new Dictionary<TileNumber, Texture2D>());
            _data[TileEnviroment.Grass].Add(TileNumber.TopLeft,            "");
            _data[TileEnviroment.Grass].Add(TileNumber.TopMiddle,          "");
            _data[TileEnviroment.Grass].Add(TileNumber.TopRight,           "");
            _data[TileEnviroment.Grass].Add(TileNumber.MiddleLeft,         "");
            _data[TileEnviroment.Grass].Add(TileNumber.MiddleMiddle,       "");
            _data[TileEnviroment.Grass].Add(TileNumber.MiddleRight,        "");
            _data[TileEnviroment.Grass].Add(TileNumber.BottomLeft,         "");
            _data[TileEnviroment.Grass].Add(TileNumber.BottomMiddle,       "");
            _data[TileEnviroment.Grass].Add(TileNumber.BottomRight,        "");
            _data[TileEnviroment.Grass].Add(TileNumber.InverseMiddleMiddle,"");
            _data[TileEnviroment.Grass].Add(TileNumber.InverseTopLeft,     "");
            _data[TileEnviroment.Grass].Add(TileNumber.InverseTopRight,    "");
            _data[TileEnviroment.Grass].Add(TileNumber.InverseBottomLeft,  "");
            _data[TileEnviroment.Grass].Add(TileNumber.InverseBottomRight, "");*/

            //Debug enviroment
            Dictionary<TileNumber, Texture2D> debugDict = new Dictionary<TileNumber, Texture2D>();  
            _data.Add(TileEnviroment.Debug, debugDict);
            _data[TileEnviroment.Debug].Add(TileNumber.TopLeft, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/TopLeft.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.TopMiddle, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/TopMiddle.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.TopRight, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/TopRight.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.MiddleLeft, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/MiddleLeft.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.MiddleMiddle, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/MiddleMiddle.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.MiddleRight, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/MiddleRight.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.BottomLeft, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/BottomLeft.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.BottomMiddle, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/BottomMiddle.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.BottomRight, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/BottomRight.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.InverseMiddleMiddle, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/InverseMiddleMiddle.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.InverseTopLeft, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/InverseTopLeft.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.InverseTopRight, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/InverseTopRight.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.InverseBottomLeft, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/InverseBottomLeft.png"));
            _data[TileEnviroment.Debug].Add(TileNumber.InverseBottomRight, WaveServices.Assets.Global.LoadAsset<Texture2D>("Content/Assets/Sprites/Tiles/Debug/InverseBottomRight.png"));

        }

        public static Texture2D GetTile(TileEnviroment tileEnv, TileNumber tileNum)
        {
            return _data[tileEnv][tileNum];
        }
    }
}
