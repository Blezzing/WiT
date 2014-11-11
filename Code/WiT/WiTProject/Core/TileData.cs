using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Grass = 0
    }

    public static class TileData
    {
        private static Dictionary<TileEnviroment, Dictionary<TileNumber, String>> _data = new Dictionary<TileEnviroment, Dictionary<TileNumber, string>>();

        public static readonly int TileSize = 200;
        public static readonly float TileScale = 0.5f;


        public static void Build()
        {
            //Grass enviroment
            _data.Add(TileEnviroment.Grass, new Dictionary<TileNumber, string>());
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
            _data[TileEnviroment.Grass].Add(TileNumber.InverseBottomRight, "");

        }

        public static string GetTile(TileEnviroment tileEnv, TileNumber tileNum)
        {
            return _data[tileEnv][tileNum];
        }
    }
}
