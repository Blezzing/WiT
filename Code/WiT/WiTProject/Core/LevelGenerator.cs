using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiTProject
{
    public static class LevelGenerator
    {

        public static Level RandomGeneratedLevel()
        {
            return new Level(new MapDesign());
        }

        public static Level SpecificLevel(int levelNumber)
        {
            throw new NotImplementedException();
        }
    }
}
