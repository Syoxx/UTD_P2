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

        Player player;

        private float speedModifier;

        private float modifierDuration;
        private float modifierCurrentTime;

        protected float startHealth;
        protected float currentHealth;
        float healthPercentage;

        protected bool alive = true;
        private bool enemyAtEnd;
        protected float speed = 10f;
        protected int bountyGiven;

        protected float rotationAngle;

        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public bool IsDead
        {
            get { return !alive; }
        }
        public int BountyGiven
        {
            get { return bountyGiven; }
        }
        
        // Check whether enemy has reached it's next waypoint
        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }


        /// <summary>
        /// Alters the speed of the enemy.
        /// </summary>
        public float SpeedModifier
        {
            get { return speedModifier; }
            set { speedModifier = value; }
        }

        /// <summary>
        /// Defines how long the speed modification will last.
        /// </summary>
        public float ModifierDuration
        {
            get { return modifierDuration; }
            set
            {
                modifierDuration = value;
                modifierCurrentTime = 0;
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="health"></param>
        /// <param name="bountyGiven"></param>
        /// <param name="speed"></param>
        /// <param name="graphicsDevice"></param>
        public Enemys(Player player, Texture2D texture, Vector2 position, float health, int bountyGiven, float speed, GraphicsDevice graphicsDevice) : base(texture, position)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;

            this.bountyGiven = bountyGiven;
            this.speed = speed;

            this.player = player;
        }
        
        /// <summary>
        /// Set given waypoint in queue.
        /// </summary>
        /// <param name="waypoints"></param>
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
                    rotationAngle = (float)Math.Atan2(direction.X, direction.Y);

                    // Store the original speed.
                    float temporarySpeed = speed;

                    // If the modifier has finished,
                    if(modifierCurrentTime > modifierDuration)
                    {
                        // reset the modifier.
                        speedModifier = 0;
                        modifierCurrentTime = 0;
                    }

                    if(speedModifier != 0 && modifierCurrentTime <= modifierDuration)
                    {
                        // Modify the speed of the enemy.
                        temporarySpeed *= speedModifier;
                        // Update the modifier timer.
                        modifierCurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                    velocity = Vector2.Multiply(direction, temporarySpeed);

                    position += velocity;
                }
            }
            else
            {
                alive = false;
                enemyAtEnd = true;
                //player.life -= 1;
            }

            if (currentHealth <= 0)
            {
                alive = false;
                //player.money += 5;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {
                healthPercentage = (float)currentHealth / (float)startHealth;
                
                Color color = new Color(new Vector3(100 - healthPercentage,100 - healthPercentage, 100 - healthPercentage));

                rotation = rotationAngle;

                base.Draw(spriteBatch, color);
            }
        }
    }
}
