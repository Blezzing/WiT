#region Using Statements
using System;
using System.Collections.Generic;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Common.Input;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Managers;
#endregion


namespace WiTProject
{
    public class FightJudge
    {
        private List<ICanDie> _goodGuys = new List<ICanDie>();
        private List<ICanDie> _badGuys = new List<ICanDie>();

        private Scene _scene;

        public FightJudge(Scene scene)
        { 
            _scene = scene;
        }

        public void AddGoodGuy(ICanDie goodGuy)
        {
            _goodGuys.Add(goodGuy);
        }

        public void AddBadGuy(ICanDie badGuy)
        {
            _badGuys.Add(badGuy);
        }

        public void NoteDeath(ICanDie deadGuy)
        {
            if (_goodGuys.Contains(deadGuy))
            {
                _goodGuys.Remove(deadGuy);
                CheckForDefeat();
            }
            
            if (_badGuys.Contains(deadGuy))
            {
                _badGuys.Remove(deadGuy);
                CheckForVictory();
            }
        }

        private void CheckForDefeat()
        {
            if (_goodGuys.Count == 0)
                AnnounceDefeat();
        }
        
        private void CheckForVictory()
        {
            if (_goodGuys.Count == 0)
                AnnounceVictory();
        }

        private void AnnounceDefeat()
        {
        }
        
        private void AnnounceVictory()
        {
        }
    }
}
