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
        private FightJudge _judge;

        //basic setup vars
        private const float normalMass = 10f;
        private const float normalDamping = 1f;
        private const float normalMoveForce = 2f;

        //constructor
        public Spawner(Scene scene, FightJudge judge)
        {
            _scene = scene;
            _judge = judge;
            _spriteDictionary.Add("PlayerSprite", "Content/Assets/Sprites/spinner.png"); //FIX
        }

        public void SpawnPlayer(float posX, float posY)
        {
            Entity player = new Entity("Player")
                .AddComponent(new Transform2D() { Position = new Vector2(posX, posY) })
                .AddComponent(new RigidBody2D() { IgnoreGravity = true, Mass = normalMass, Damping = normalDamping})
                .AddComponent(new Sprite(_spriteDictionary["PlayerSprite"]))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                .AddComponent(new CircleCollider())
                .AddComponent(new PlayerBehavior(normalMoveForce));
            _scene.EntityManager.Add(player);
        }

        public void SpawnCamera2D()
        {
            var camera2D = new FixedCamera2D("Camera2D") { BackgroundColor = Color.LightGreen};
            _scene.EntityManager.Add(camera2D);
        }
    }
}
