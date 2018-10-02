using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
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

        Texture2D
            background1, lvlWay1, lvlTile2, lvlTile3, lvlTile4, lvlTile5, lvlTile6, lvlTile7, lvlTile8, lvlTile9,
            background2, lvlWay2, lvlTile12, lvlTile13, lvlTile14, lvlTile15, lvlTile16, lvlTile17, lvlTile18, lvlTile19,
            background3, lvlWay3, lvlTile22, lvlTile23, lvlTile24, lvlTile25, lvlTile26, lvlTile27, lvlTile28, lvlTile29,
            horOutline1, verOutline1, botRightCor, botLeftCor, uppRightCor, uppLeftCor,
            start1, end1,
            uiLine,
            buildButtonTexture;

        #region TilesToPath
        
        // Level 1
        private string pathToLvl1Background = "Content/Assets/Level1/tileBackground.png";
        private string pathToLvl1Way = "Content/Assets/Level1/tileEnemyWay.png";
        private string pathToLvlTile2 = "Content/Assets/Level1/tileWayLower.png";
        private string pathToLvlTile3 = "Content/Assets/Level1/tileWayUpper.png";
        private string pathToLvlTile4 = "Content/Assets/Level1/tileWayLeft.png";
        private string pathToLvlTile5 = "Content/Assets/Level1/tileWayRight.png";
        private string pathToLvlTile6 = "Content/Assets/Level1/tileCornerBottomLeft.png";
        private string pathToLvlTile7 = "Content/Assets/Level1/tileCornerBottomRight.png";
        private string pathToLvlTile8 = "Content/Assets/Level1/tileCornerUpperLeft.png";
        private string pathToLvlTile9 = "Content/Assets/Level1/tileCornerUpperRight.png";

        // Level 2
        private string pathToLvl2Background = "Content/Assets/Level2/tileBackground.png";
        private string pathToLvl2Way = "Content/Assets/Level2/tileEnemyWay.png";
        private string pathToLvlTile12 = "Content/Assets/Level2/tileWayLower.png";
        private string pathToLvlTile13 = "Content/Assets/Level2/tileWayUpper.png";
        private string pathToLvlTile14 = "Content/Assets/Level2/tileWayLeft.png";
        private string pathToLvlTile15 = "Content/Assets/Level2/tileWayRight.png";
        private string pathToLvlTile16 = "Content/Assets/Level2/tileCornerBottomLeft.png";
        private string pathToLvlTile17 = "Content/Assets/Level2/tileCornerBottomRight.png";
        private string pathToLvlTile18 = "Content/Assets/Level2/tileCornerUpperLeft.png";
        private string pathToLvlTile19 = "Content/Assets/Level2/tileCornerUpperRight.png";

        // Level 3
        private string pathToLvl3Background = "Content/Assets/Level3/tileBackground.png";
        private string pathToLvl3Way = "Content/Assets/Level3/tileEnemyWay.png";
        private string pathToLvlTile22 = "Content/Assets/Level3/tileWayLower.png";
        private string pathToLvlTile23 = "Content/Assets/Level3/tileWayUpper.png";
        private string pathToLvlTile24 = "Content/Assets/Level3/tileWayLeft.png";
        private string pathToLvlTile25 = "Content/Assets/Level3/tileWayRight.png";
        private string pathToLvlTile26 = "Content/Assets/Level3/tileCornerBottomLeft.png";
        private string pathToLvlTile27 = "Content/Assets/Level3/tileCornerBottomRight.png";
        private string pathToLvlTile28 = "Content/Assets/Level3/tileCornerUpperLeft.png";
        private string pathToLvlTile29 = "Content/Assets/Level3/tileCornerUpperRight.png";

        // Outlines
        private string pathToHorOutline = "Content/Assets/Outlines/horOutline.png";
        private string pathToVerOutline = "Content/Assets/Outlines/verOutline.png";
        private string pathToBottomRightCornerOutline = "Content/Assets/Outlines/bottomRightCornerOutline.png";
        private string pathToBottomLeftCornerOutline = "Content/Assets/Outlines/bottomLeftCornerOutline.png";
        private string pathToUpperRightCornerOutline = "Content/Assets/Outlines/upperRightCornerOutline.png";
        private string pathToUpperLeftCornerOutline = "Content/Assets/Outlines/upperRightCornerOutline.png";

        // Start-End
        private string pathToStart = "Content/Assets/StartEnd/start.png";
        private string pathToEnd = "Content/Assets/StartEnd/end.png";

        // UI Line
        private string pathToUiLine = "Content/Assets/LevelUI/uiLine.png";

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

        Enemys enemy1;
        Texture2D enemy1Texture;
        EnemyController enemyController;

        private Queue<Vector2> waypoints = new Queue<Vector2>();

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

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

            player = new Player(graphicsDevice);
            ui = new UserInterface(graphicsDevice, player);
            enemyController = new EnemyController(15, 10, this, graphicsDevice, player);

            isActive = true;

            buildButtonTexture = ContentConverter.Convert("Content/Assets/TD/UI/buildTower.png", graphicsDevice);

            #region Convert and load level textures

            // Level 1
            background1 = ContentConverter.Convert(pathToLvl1Background, graphicsDevice);
            lvlWay1 = ContentConverter.Convert(pathToLvl1Way, graphicsDevice);
            lvlTile2 = ContentConverter.Convert(pathToLvlTile2, graphicsDevice);
            lvlTile3 = ContentConverter.Convert(pathToLvlTile3, graphicsDevice);
            lvlTile4 = ContentConverter.Convert(pathToLvlTile4, graphicsDevice);
            lvlTile5 = ContentConverter.Convert(pathToLvlTile5, graphicsDevice);
            lvlTile6 = ContentConverter.Convert(pathToLvlTile6, graphicsDevice);
            lvlTile7 = ContentConverter.Convert(pathToLvlTile7, graphicsDevice);
            lvlTile8 = ContentConverter.Convert(pathToLvlTile8, graphicsDevice);
            lvlTile9 = ContentConverter.Convert(pathToLvlTile9, graphicsDevice);

            // Level 2
            background2 = ContentConverter.Convert(pathToLvl2Background, graphicsDevice);
            lvlWay2 = ContentConverter.Convert(pathToLvl2Way, graphicsDevice);
            lvlTile12 = ContentConverter.Convert(pathToLvlTile12, graphicsDevice);
            lvlTile13 = ContentConverter.Convert(pathToLvlTile13, graphicsDevice);
            lvlTile14 = ContentConverter.Convert(pathToLvlTile14, graphicsDevice);
            lvlTile15 = ContentConverter.Convert(pathToLvlTile15, graphicsDevice);
            lvlTile16 = ContentConverter.Convert(pathToLvlTile16, graphicsDevice);
            lvlTile17 = ContentConverter.Convert(pathToLvlTile17, graphicsDevice);
            lvlTile18 = ContentConverter.Convert(pathToLvlTile18, graphicsDevice);
            lvlTile19 = ContentConverter.Convert(pathToLvlTile19, graphicsDevice);

            // Level 3
            background3 = ContentConverter.Convert(pathToLvl3Background, graphicsDevice);
            lvlWay3 = ContentConverter.Convert(pathToLvl3Way, graphicsDevice);
            lvlTile22 = ContentConverter.Convert(pathToLvlTile22, graphicsDevice);
            lvlTile23 = ContentConverter.Convert(pathToLvlTile23, graphicsDevice);
            lvlTile24 = ContentConverter.Convert(pathToLvlTile24, graphicsDevice);
            lvlTile25 = ContentConverter.Convert(pathToLvlTile25, graphicsDevice);
            lvlTile26 = ContentConverter.Convert(pathToLvlTile26, graphicsDevice);
            lvlTile27 = ContentConverter.Convert(pathToLvlTile27, graphicsDevice);
            lvlTile28 = ContentConverter.Convert(pathToLvlTile28, graphicsDevice);
            lvlTile29 = ContentConverter.Convert(pathToLvlTile29, graphicsDevice);

            // Oulines
            horOutline1 = ContentConverter.Convert(pathToHorOutline, graphicsDevice);
            verOutline1 = ContentConverter.Convert(pathToVerOutline, graphicsDevice);
            botRightCor = ContentConverter.Convert(pathToBottomRightCornerOutline, graphicsDevice);
            botLeftCor = ContentConverter.Convert(pathToBottomLeftCornerOutline, graphicsDevice);
            uppRightCor = ContentConverter.Convert(pathToUpperRightCornerOutline, graphicsDevice);
            uppLeftCor = ContentConverter.Convert(pathToUpperLeftCornerOutline, graphicsDevice);

            // Start-End
            start1 = ContentConverter.Convert(pathToStart, graphicsDevice);
            end1 = ContentConverter.Convert(pathToEnd, graphicsDevice);

            // UI Line
            uiLine = ContentConverter.Convert(pathToUiLine, graphicsDevice);
            
            #endregion


            #region Add loaded textures to textures list

            AddTexture(background1);
            AddTexture(lvlWay1);
            AddTexture(lvlTile2);
            AddTexture(lvlTile3);
            AddTexture(lvlTile4);
            AddTexture(lvlTile5);
            AddTexture(lvlTile6);
            AddTexture(lvlTile7);
            AddTexture(lvlTile8);
            AddTexture(lvlTile9);

            AddTexture(background2);
            AddTexture(lvlWay2);
            AddTexture(lvlTile12);
            AddTexture(lvlTile13);
            AddTexture(lvlTile14);
            AddTexture(lvlTile15);
            AddTexture(lvlTile16);
            AddTexture(lvlTile17);
            AddTexture(lvlTile18);
            AddTexture(lvlTile19);

            AddTexture(background3);
            AddTexture(lvlWay3);
            AddTexture(lvlTile22);
            AddTexture(lvlTile23);
            AddTexture(lvlTile24);
            AddTexture(lvlTile25);
            AddTexture(lvlTile26);
            AddTexture(lvlTile27);
            AddTexture(lvlTile28);
            AddTexture(lvlTile29);

            AddTexture(horOutline1);
            AddTexture(verOutline1);
            AddTexture(botRightCor);
            AddTexture(botLeftCor);
            AddTexture(uppRightCor);
            AddTexture(uppLeftCor);

            AddTexture(start1);
            AddTexture(end1);

            AddTexture(uiLine);

            #endregion


            this.mState = mState;
            
            switch (mState)
            {
                case MapState.map1:
                    mapToUse = map1;
                    BuildButton buildButton = new BuildButton("buildButton", buildButtonTexture, 500, 64, graphicsDevice, player, this);
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


            #region Enemy
            // Waypoints
            waypoints.Enqueue(new Vector2(2, 0) * 64);
            waypoints.Enqueue(new Vector2(2, 1) * 64);
            waypoints.Enqueue(new Vector2(3, 1) * 64);
            waypoints.Enqueue(new Vector2(3, 2) * 64);
            waypoints.Enqueue(new Vector2(4, 2) * 64);
            waypoints.Enqueue(new Vector2(4, 4) * 64);
            waypoints.Enqueue(new Vector2(3, 4) * 64);
            waypoints.Enqueue(new Vector2(3, 5) * 64);
            waypoints.Enqueue(new Vector2(2, 5) * 64);
            waypoints.Enqueue(new Vector2(2, 7) * 64);
            waypoints.Enqueue(new Vector2(7, 7) * 64);


            // Load enemy 
            LoadEnemy(graphicsDevice);
            

            #endregion
        }

        #region Map Arrays

        /// <summary>
        /// This arrays are going to be used to map out our level. Each one of these numbers is a texture.
        /// </summary>

        // Level 1
        int[,] map1 = new int[,]
        {
            {38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,},
            {32,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,31,},
            {31, 0, 2, 2, 2, 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6,0,31,},
            {31,36, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,0,31,},
            {31, 0, 3, 3, 3, 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,4,0,31,},
            {31, 0, 2, 2, 2, 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,4,0,31,},
            {31,37, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,0,31,},
            {31, 0, 3, 3, 3, 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,8,0,31,},
            {31, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,31,},
            {34,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
        };

        // Level 2

        int[,] map2 = new int[,]
        {
            {38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,},
            {32,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
            {31,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,31,},
            {31,22,22,22,22,22,22,22,26,20,20,20,20,20,20,20,20,20,20,20,20,27,22,22,22,22,22,22,22,31,},
            {31,36,21,21,21,21,21,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,21,21,21,21,21,37,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,24,20,20,20,20,20,20,20,20,20,20,20,20,25,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,25,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,24,20,20,20,20,20,31,},
            {31,20,20,20,20,20,29,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,28,20,20,20,20,20,31,},
            {31,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,31,},
            {34,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
        };

        // Level 3

        int[,] map3 = new int[,]
        {
            {38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,38,},
            {32,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
            {31,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,31,},
            {31,12,12,12,12,12,12,12,16,10,10,10,10,17,12,12,12,12,12,12,12,12,16,10,10,10,10,10,10,31,},
            {31,36,11,11,11,11,11,11,14,10,10,10,10,15,11,11,11,11,11,11,11,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,15,11,14,10,10,10,10,10,10,31,},
            {31,10,10,10,10,10,15,11,11,11,11,11,11,11,11,14,10,10,10,10,15,11,11,11,11,11,11,11,37,31,},
            {31,10,10,10,10,10,19,13,13,13,13,13,13,13,13,18,10,10,10,10,19,13,13,13,13,13,13,13,13,31,},
            {31,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,31,},
            {34,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,33,},
        };
        private KeyboardState currentKBState;
        private KeyboardState oldKBState;
        
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

        public void LoadEnemy(GraphicsDevice graphicsDevice)
        {
            enemy1Texture = ContentConverter.Convert("Content/Assets/Enemys/enemy1.png", graphicsDevice);
            // Creates enemy in the top left corner (0,0) with 100 health, 10 gold
            enemy1 = new Enemys(enemy1Texture, Vector2.Zero, 100, 10, 0.5f);

            enemy1.SetWaypoints(waypoints);
        }

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
            enemy1.CurrentHealth -= 1;
            enemy1.Update(gameTime);
            
            currentKBState = Keyboard.GetState();

            if (currentKBState.IsKeyDown(Keys.Z))
                player.position.Y -= 2;
            if (currentKBState.IsKeyDown(Keys.H))
                player.position.Y += 2;
            if (currentKBState.IsKeyDown(Keys.G))
                player.position.X -= 2;
            if (currentKBState.IsKeyDown(Keys.J))
                player.position.X += 2;

            foreach(Towers tower in towerList)
            {
                tower.Update(gameTime, this);
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].CurrentHealth <= 0)
                    enemyList[i] = null;
                else
                    enemyList[i].Update(gameTime);

                if (enemyList[i] == null)
                    enemyList.Remove(enemyList[i]);
            }

            for (int i = 0; i < projectileList.Count; i++)
            {
                if (projectileList[i].hit)
                    projectileList[i] = null;
                else
                    projectileList[i].Update(gameTime);

                if (projectileList[i] == null)
                    projectileList.Remove(projectileList[i]);
            }

            foreach (BuildButton button in buildButtonList)
                button.Update(gameTime);

            if(uiButton != null)
                uiButton.Update(gameTime);

            ui.Update(gameTime);

            player.Update(gameTime);

            oldKBState = currentKBState;
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
            enemy1.Draw(batch);
            foreach (BuildButton button in buildButtonList)
                button.Draw(batch);

            foreach (Towers tower in towerList)
                tower.Draw(batch);

            foreach (Enemys enemy in enemyList)
            {
                if (enemy != null)
                    enemy.Draw(batch);
            }

            foreach (Projectile proj in projectileList)
            {
                if (proj != null)
                    proj.Draw(batch);
            }

            ui.Draw(batch);

            if(uiButton != null)
                uiButton.Draw(batch);

            player.Draw(batch);
        }

    }
}
