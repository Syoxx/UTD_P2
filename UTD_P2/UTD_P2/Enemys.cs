using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
	public class Enemys : Sprite
	{
        private Queue<Vector2> waypoints = new Queue<Vector2>();

        protected float startHealth;
        protected float currentHealth;
        float healthPercentage;

        protected bool alive = true;
        
        protected float speed = 0.5f;
        protected int bountyGiven;
        
        public Vector2 position;

        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public bool IsDead
        {
            get { return currentHealth <= 0; }
        }
        public int BountyGiven
        {
            get { return bountyGiven; }
        }

        // Check wheter enemy has reached it's next waypoint
        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }

        //private float speedModifier;
        //private float modifierDuration;
        //private float modifierCurrentTime;

        //public float SpeedModifier
        //{
        //    get { return speedModifier; }
        //    set { speedModifier = value; }
        //}

        //public float ModifierDuration
        //{
        //    get { return modifierDuration; }
        //    set
        //    {
        //        modifierDuration = value;
        //        modifierCurrentTime = 0;
        //    }
        //}



        public Enemys(Texture2D texture, Vector2 position, float health, int bountyGiven, float speed) : base(texture, position)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;

            this.bountyGiven = bountyGiven;
            this.speed = speed;
        }
        
        public void SetWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
            {
                this.waypoints.Enqueue(waypoint);
            }
            this.position = this.waypoints.Dequeue();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < speed)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }
                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();

                    velocity = Vector2.Multiply(direction, speed);

                    position += velocity;
                }
            }
            else
                alive = false;

            if (currentHealth <= 0)
            {
                alive = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {
                healthPercentage = (float)currentHealth / (float)startHealth;
                
                Color color = new Color(new Vector3(1 - healthPercentage,1 - healthPercentage, 1 - healthPercentage));
                
                base.Draw(spriteBatch, color);
            }
        }
    }
}
