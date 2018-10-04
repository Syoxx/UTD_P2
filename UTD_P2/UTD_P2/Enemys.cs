using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    public class Enemys : Sprite
	{
        #region Variables

        private Queue<Vector2> waypoints = new Queue<Vector2>();

        public Vector2 projTargetPosition;

        Player player;

        private float speedModifier;

        private float modifierDuration;
        private float modifierCurrentTime;

        protected float startHealth;
        protected float currentHealth;
        float healthPercentage;

        public bool alive = true;
        public bool enemyAtEnd;
        protected float speed = 10f;
        protected int bountyGiven;

        protected float rotationAngle;
        private bool executed = false;
        private bool moneyExecuted = false;

        #endregion

        #region Properties

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

        #endregion


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

            // If there are waypoints ...
            if (waypoints.Count > 0)
            {
                // and if npc distance to waypoint is smaller then speed
                if (Vector2.Distance(position, waypoints.Peek()) < speed)
                {
                    // drop npc on waypoint to not walk over the waypoint. It's just for smoothing if npc reaches a waypoint.
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }
                // walk towards the waypoint.
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
            // If there aren't waypoints left -> NPC is at the end but still have life...
            else
            {
                // reduce the life of the player and delete NC.
                ReducePlayerLife();
                alive = false;
            }
            // If npc's health is 0 -> NPC is death because no more life..
            if (currentHealth <= 0)
            {
                // Add money to the player and delete NPC.
                AddMoneyToPlayer();
                alive = false;
            }

            projTargetPosition = position + new Vector2(32, 32);
        }

        /// <summary>
        /// Reduce life of the player with amount of 1.
        /// </summary>
        private void ReducePlayerLife()
        {
            if (!executed)
            {
                player.life -= 1;
                executed = true;
            }
        }

        /// <summary>
        /// Add money to the player with the amount of given bounty from enemy.
        /// </summary>
        private void AddMoneyToPlayer()
        {
            if (!moneyExecuted)
            {
                player.money += bountyGiven;
                moneyExecuted = true;
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
