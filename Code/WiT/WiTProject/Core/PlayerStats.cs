using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiTProject
{
    static public class PlayerStats
    {
        //vars
        private static int _health;
        private static int _healthMax;
        private static int _level;
        private static int _exp;
        private static int _expReq;
        private static int _currency;

        public static int Health
        {
            get { return _health; }
            private set { _health = value;}
        }

        public static int HealthMax
        {
            get { return _healthMax; }
            private set { _healthMax = value; }
        }

        public static int Level
        {
            get { return _level; }
            private set { _level = value; }
        }

        public static int Experience
        {
            get { return _exp; }
            private set { _exp = value; }
        }


        public static int ExperienceRequirement
        {
            get { return _expReq; }
            private set { _expReq = value; }
        }

        public static int Currency
        {
            get { return _currency; }
            private set { _currency = value; }
        }

        //todo: funktioner :p
    }
}
