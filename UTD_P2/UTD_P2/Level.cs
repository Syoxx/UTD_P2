using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    /// <summary>
    /// Load and unload what we need in a level
    /// </summary>
    public class Level
    {
        #region Variables

        Texture2D backgroundGreen, lvlTile1, lvlTile2, lvlTile3, lvlTile4, lvlTile5, lvlTile6, buildButtonTexture;

        #region TilesToPath

        // Level 1
        private string lvl1Background = "Content/Assets/Level1/tileBackground-Green.png";
        private string enemyWayLvl1 = "Content/Assets/Level1/tileEnemyWay.png";

        // Level 2
        private string lvl2Background = "";
        private string enemyWayLvl2 = "";

        // Level 3
        private string lvl3Background = "";
        private string enemyWayLvl3 = "";

        // Level 4
        private string lvl4Background = "";
        private string enemyWayLvl4 = "";


        #endregion

        private List<Texture2D> tileTextures;
        private List<Towers> towerList;
        private List<Enemys> enemyList;
        private List<Projectile> projectileList;
        private List<BuildButton> buildButtonList;
        private UIButton uiButton;

        private Player player;
        private UserInterface ui;

        public bool isActive;

        public enum MapState { map1, map2, map3, };

        MapState mState;

        int[,] mapToUse;

        #endregion


        public Level(MapState mState, GraphicsDevice graphicsDevice)
        {
            // Create a list which contains the textures to load as map.
            tileTextures = new List<Texture2D>();

            // Create lists which contain the towers, enemys and projectiles.
            towerList = new List<Towers>();
            enemyList = new List<Enemys>();
            projectileList = new List<Projectile>();
            buildButtonList = new List<BuildButton>();

            player = new Player();
            ui = new UserInterface(graphicsDevice, player);

            isActive = true;

            // Level 1
            backgroundGreen = ContentConverter.Convert(lvl1Background, graphicsDevice);
            lvlTile1 = ContentConverter.Convert(enemyWayLvl1, graphicsDevice);
            buildButtonTexture = ContentConverter.Convert("Content/Assets/TD/UI/buildTower.png", graphicsDevice);


            //NOTE: Array-Index 0
            AddTexture(backgroundGreen);
            //NOTE: Array-Index 1
            AddTexture(lvlTile1);
            
            
            this.mState = mState;
            
            switch (mState)
            {
                case MapState.map1:
                    mapToUse = map1;
                    BuildButton buildButton = new BuildButton("buildButton", buildButtonTexture, 220, 64, graphicsDevice, player, this);
                    buildButtonList.Add(buildButton);
                    break;
                case MapState.map2:
                    mapToUse = map2;
                    break;
                case MapState.map3:
                    mapToUse = map3;
                    break;

                default:
                    throw new Exception(String.Format("Unknown state: {0}", mState));
            }
        }
        
        #region Map Arrays

        /// <summary>
        /// This arrays are going to be used to map out our level. Each one of these numbers is a texture.
        /// </summary>

        // Level 1
        int[,] map1 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        };

        // Level 2
        int[,] map2 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        };

        // Level 3
        int[,] map3 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        };

        #endregion
        
        
        #region LoadMapTextures

        /// <summary>
        /// Get the widht of our level by retreiving our array's row lenght.
        /// </summary>
        public int Width
        {
            get { return mapToUse.GetLength(1); }
        }

        /// <summary>
        /// Get the height of our level by retreiving our array's column lenght.
        /// </summary>
        public int Height
        {
            get { return mapToUse.GetLength(0); }
        }

        
        /// <summary>
        /// Add a texture to the tileTexture list.
        /// </summary>
        /// <param name="texture"></param>
        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }
        #endregion


        #region TowerList

        /// <summary>
        /// Add tower to the towerList.
        /// </summary>
        /// <param name="tower"></param>
        public void AddTower(Towers tower, UIButton button)
        {
            towerList.Add(tower);
            uiButton = null;
        }
 
        #endregion

        #region EnemyList

        /// <summary>
        /// Add enemy to the list enemyList.
        /// </summary>
        /// <param name="enemys"></param>
        public void AddEnemy(Enemys enemys)
        {
            enemyList.Add(enemys);
        }

        #endregion

        #region ProjectileList

        /// <summary>
        /// Add projectile to the list projectileList.
        /// </summary>
        /// <param name="projectile"></param>
        public void AddProjectile(Projectile projectile)
        {
            projectileList.Add(projectile);
        }

        #endregion

        #region UIButtonList

        /// <summary>
        /// Add UIButton to the List uIButtonList
        /// </summary>
        /// <param name="button"></param>
        public void SetUIButton(UIButton button)
        {
            uiButton = button;
        }

        #endregion

        public void Update(GameTime gameTime)
        {
            foreach(Towers tower in towerList)
            {
                tower.Update(gameTime, this);
            }

            foreach(Enemys enemy in enemyList)
            {
                enemy.Update(gameTime);
            }

            foreach(Projectile proj in projectileList)
            {
                proj.Update(gameTime);
            }

            foreach (BuildButton button in buildButtonList)
                button.Update(gameTime);

            if(uiButton != null)
                uiButton.Update(gameTime);

            ui.Update(gameTime);
        }

        /// <param name="batch"></param>
        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    //int textureIndex = map[y, x];
                    int textureIndex = mapToUse[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(texture, new Rectangle(
                        x * 64, y * 64, 64, 64), Color.White);
                }
            }

            foreach (BuildButton button in buildButtonList)
                button.Draw(batch);

            foreach (Towers tower in towerList)
                tower.Draw(batch);

            foreach (Enemys enemy in enemyList)
                enemy.Draw(batch);

            foreach (Projectile proj in projectileList)
                proj.Draw(batch);

            ui.Draw(batch);

            if(uiButton != null)
                uiButton.Draw(batch);
        }

    }
}
