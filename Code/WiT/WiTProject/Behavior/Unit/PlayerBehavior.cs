#region Using Statements
using System;
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
#endregion


namespace WiTProject
{
    public class PlayerBehavior 
        : Behavior,
        ICanDie
    {
        //config vars
        private float _moveForce;

        //input vars
        private KeyboardState _currKS;
        private MouseState _currMS;
        private Vector2 _inputDirection;

        //quality of life
        private RigidBody2D _body;
        private Transform2D _transform;

        //constructor
        public PlayerBehavior(float moveForce)
            : base()
        {
            this._moveForce = moveForce;
        }

        protected override void Initialize()
        {
            _body = Owner.FindComponent<RigidBody2D>();
            _transform = Owner.FindComponent<Transform2D>();
        }

        //update overrice
        protected override void Update(TimeSpan gameTime)
        {
            UpdateInput();
            Movement();
            RotateTowardsMouse();
        }

        private void UpdateInput()
        {
            _currKS = WaveServices.Input.KeyboardState;
            _currMS = WaveServices.Input.MouseState;
        }

        private void Movement()
        {
            if (!_currKS.Equals(null))
            {
                //reset
                _inputDirection = Vector2.Zero;

                //calculate
                if (_currKS.W == ButtonState.Pressed)
                    _inputDirection.Y -= 1f;
                if (_currKS.S == ButtonState.Pressed)
                    _inputDirection.Y += 1f;
                if (_currKS.A == ButtonState.Pressed)
                    _inputDirection.X -= 1f;
                if (_currKS.D == ButtonState.Pressed)
                    _inputDirection.X += 1f;

                //normalize
                if (_inputDirection != Vector2.Zero)
                    _inputDirection.Normalize();

                //viddersend
                _body.ApplyLinearImpulse(_inputDirection * new Vector2(_moveForce));

            }
            else
                throw new NullReferenceException("Baka! input blev ikke updated før movement() blev kaldt");
        }

        private void RotateTowardsMouse()
        {
            Vector2 playerPos = _transform.Position;
            Vector2 mousePos = new Vector2(_currMS.X,_currMS.Y);
            Vector2 dif = mousePos-playerPos;
            dif.Normalize();

            _body.Rotation = (float) (Math.Atan2(dif.Y,dif.X));
        }

        public void CheckForDeath()
        {
        }

        public void Die()
        {
            Console.WriteLine("i'm fucking dead.");
        }
    }
}
