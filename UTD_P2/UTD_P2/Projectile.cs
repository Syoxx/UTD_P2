﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    public class Projectile
    {
        private float speed, damage, damageRadius, rotationAngle;

        private Texture2D texture;

        private Vector2 position, direction, rotationCenter, drawPosition;

        public Enemys target;

        private Rectangle sourceRectangle;

        public bool hit;

        private bool canSlow;

        public Projectile(Texture2D texture, float speed, float damage, float damageRadius, Vector2 position, Enemys target, bool canSlow)
        {
            this.texture = texture;
            this.speed = speed;
            this.damage = damage;
            this.damageRadius = damageRadius;
            this.position = position;
            this.target = target;
            this.canSlow = canSlow;
            hit = false;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            direction = position - target.position;
            direction.Normalize();
            position += direction * speed;
            rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
            if (Vector2.Distance(position, target.position) <= texture.Width)
            {
                if (damageRadius > 0)
                    InitiateExplosion();
                target.life -= damage;
                //target.isSlowed = canSLow;
                hit = true;
            }
        }

        private void InitiateExplosion()
        {
            //TODO: implement Circle for Explosion collision
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            drawPosition = position - new Vector2(texture.Width / 2, texture.Height / 2);
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, drawPosition, sourceRectangle, Color.White, rotationAngle, rotationCenter, 1, SpriteEffects.None, 1);
        }
    }
}
