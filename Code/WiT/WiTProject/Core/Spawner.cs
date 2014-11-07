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
    public class Spawner
    {
        //dictionary over sprites
        private Dictionary<string, string> _spriteDictionary = new Dictionary<string, string>();

        //vars
        private Scene _scene;

        //constructor
        public Spawner(Scene scene)
        {
            _scene = scene;
            _spriteDictionary.Add("PlayerSprite", "Content/Assets/Sprites/spinner.png"); //FIX
        }

        public void Player(float posX, float posY)
        {
            Entity player = new Entity("Player")
                .AddComponent(new Transform2D() { Position = new Vector2(posX, posY) })
                .AddComponent(new RigidBody2D() { IgnoreGravity = true })
                .AddComponent(new Sprite(_spriteDictionary["PlayerSprite"]))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new CircleCollider())
                .AddComponent(new PlayerBehavior());
            _scene.EntityManager.Add(player);
        }
    }
}
