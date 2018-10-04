using System;
using System.Collections.Generic;
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

        #region Texture2D of tiles

        Texture2D
            background1, lvlWay1, lvlTile2, lvlTile3, lvlTile4, lvlTile5, lvlTile6, lvlTile7, lvlTile8, lvlTile9,
            background2, lvlWay2, lvlTile12, lvlTile13, lvlTile14, lvlTile15, lvlTile16, lvlTile17, lvlTile18, lvlTile19,
            background3, lvlWay3, lvlTile22, lvlTile23, lvlTile24, lvlTile25, lvlTile26, lvlTile27, lvlTile28, lvlTile29,
            horOutline1, verOutline1, botRightCor, botLeftCor, uppRightCor, uppLeftCor,
            start1, end1,
            uiLine,
            buildButtonTexture;

        #endregion

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
		private List<Explosion> explosionList;
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
        InRangeCheck inRangeCheck;
		Game1 game1;
        GraphicsDevice graphicsDevice;


        private Queue<Vector2> waypoints = new Queue<Vector2>();

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

        #endregion


        public Level(MapState mState, GraphicsDevice graphicsDevice, Game1 game1)
        {
			this.game1 = game1;
            this.graphicsDevice = graphicsDevice;
            // Create a list which contains the textures to load as map.
            tileTextures = new List<Texture2D>();

            // Create lists which contain the towers, enemys and projectiles.
            towerList = new List<Towers>();
            enemyList = new List<Enemys>();
            projectileList = new List<Projectile>();
            buildButtonList = new List<BuildButton>();
			explosionList = new List<Explosion>();

            player = new Player(graphicsDevice);
            ui = new UserInterface(graphicsDevice, player);
            inRangeCheck = new InRangeCheck();

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

            #region Switch for changing the map.

            this.mState = mState;

            // Which map to use
            switch (mState)
            {
                case MapState.map1:
                    mapToUse = map1;
                    buildButtonsToUse1(graphicsDevice);
                    break;

                case MapState.map2:
                    mapToUse = map2;
                    buildButtonsToUse2(graphicsDevice);
                    break;

                case MapState.map3:
                    mapToUse = map3;
                    buildButtonsToUse3(graphicsDevice);
                    break;

                default:
                    throw new Exception(String.Format("Unknown state: {0}", mState));

            #endregion
            }
            
            #region EnemyWaypoints

            if (mState == MapState.map1)
            {
                // Waypoints
                waypoints.Enqueue(new Vector2(1, 4) * 64);
                waypoints.Enqueue(new Vector2(26, 4) * 64);
                waypoints.Enqueue(new Vector2(26, 13) * 64);
                waypoints.Enqueue(new Vector2(1, 13) * 64);
            }
            else if (mState == MapState.map2)
            {
                // Waypoints
                waypoints.Enqueue(new Vector2(1, 4) * 64);
                waypoints.Enqueue(new Vector2(7, 4) * 64);
                waypoints.Enqueue(new Vector2(7, 14) * 64);
                waypoints.Enqueue(new Vector2(22, 14) * 64);
                waypoints.Enqueue(new Vector2(22, 4) * 64);
                waypoints.Enqueue(new Vector2(28, 4) * 64);
            }
            else if (mState == MapState.map3)
            {
                // Waypoints
                waypoints.Enqueue(new Vector2(1, 4) * 64);
                waypoints.Enqueue(new Vector2(7, 4) * 64);
                waypoints.Enqueue(new Vector2(7, 14) * 64);
                waypoints.Enqueue(new Vector2(14, 14) * 64);
                waypoints.Enqueue(new Vector2(14, 4) * 64);
                waypoints.Enqueue(new Vector2(21, 4) * 64);
                waypoints.Enqueue(new Vector2(21, 14) * 64);
                waypoints.Enqueue(new Vector2(28, 14) * 64);
            }

            enemyController = new EnemyController(15, 10, this, graphicsDevice, player, game1);

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
            {31, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 0,31,},
            {31,36, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0,31,},
            {31, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0,31,},
            {31, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 4, 0,31,},
            {31,37, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0,31,},
            {31, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 8, 0,31,},
            {31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,31,},
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

		public void AddExplosion(Explosion explo)
		{
			explosionList.Add(explo);
			foreach(Enemys enemy in enemyList)
			{
				explo.CheckIfInsideExplosion(enemy);
			}
		}

        #endregion


        #region BuildingButtonsPlacements

        /// <summary>
        /// BuildingButtons placement for map1
        /// </summary>
        /// <param name="graphicsDevice"></param>
        private void buildButtonsToUse1(GraphicsDevice graphicsDevice)
        {
            BuildButton buildButton = new BuildButton("buildButton", buildButtonTexture, 500, 150, graphicsDevice, player, this);
            BuildButton buildButton1 = new BuildButton("buildButton", buildButtonTexture, 750, 150, graphicsDevice, player, this);
            BuildButton buildButton2 = new BuildButton("buildButton", buildButtonTexture, 1000, 150, graphicsDevice, player, this);
            BuildButton buildButton3 = new BuildButton("buildButton", buildButtonTexture, 1250, 150, graphicsDevice, player, this);
            BuildButton buildButton4 = new BuildButton("buildButton", buildButtonTexture, 1500, 150, graphicsDevice, player, this);

            BuildButton buildButton5 = new BuildButton("buildButton", buildButtonTexture, 500, 360, graphicsDevice, player, this);
            BuildButton buildButton6 = new BuildButton("buildButton", buildButtonTexture, 750, 360, graphicsDevice, player, this);
            BuildButton buildButton7 = new BuildButton("buildButton", buildButtonTexture, 1000, 360, graphicsDevice, player, this);
            BuildButton buildButton8 = new BuildButton("buildButton", buildButtonTexture, 1250, 360, graphicsDevice, player, this);
            BuildButton buildButton9 = new BuildButton("buildButton", buildButtonTexture, 1500, 360, graphicsDevice, player, this);

            BuildButton buildButton10 = new BuildButton("buildButton", buildButtonTexture, 500, 725, graphicsDevice, player, this);
            BuildButton buildButton11 = new BuildButton("buildButton", buildButtonTexture, 750, 725, graphicsDevice, player, this);
            BuildButton buildButton12 = new BuildButton("buildButton", buildButtonTexture, 1000, 725, graphicsDevice, player, this);
            BuildButton buildButton13 = new BuildButton("buildButton", buildButtonTexture, 1250, 725, graphicsDevice, player, this);
            BuildButton buildButton14 = new BuildButton("buildButton", buildButtonTexture, 1500, 725, graphicsDevice, player, this);

            BuildButton buildButton15 = new BuildButton("buildButton", buildButtonTexture, 500, 925, graphicsDevice, player, this);
            BuildButton buildButton16 = new BuildButton("buildButton", buildButtonTexture, 750, 925, graphicsDevice, player, this);
            BuildButton buildButton17 = new BuildButton("buildButton", buildButtonTexture, 1000, 925, graphicsDevice, player, this);
            BuildButton buildButton18 = new BuildButton("buildButton", buildButtonTexture, 1250, 925, graphicsDevice, player, this);
            BuildButton buildButton19 = new BuildButton("buildButton", buildButtonTexture, 1500, 925, graphicsDevice, player, this);

            buildButtonList.Add(buildButton);
            buildButtonList.Add(buildButton1);
            buildButtonList.Add(buildButton2);
            buildButtonList.Add(buildButton3);
            buildButtonList.Add(buildButton4);

            buildButtonList.Add(buildButton5);
            buildButtonList.Add(buildButton6);
            buildButtonList.Add(buildButton7);
            buildButtonList.Add(buildButton8);
            buildButtonList.Add(buildButton9);

            buildButtonList.Add(buildButton10);
            buildButtonList.Add(buildButton11);
            buildButtonList.Add(buildButton12);
            buildButtonList.Add(buildButton13);
            buildButtonList.Add(buildButton14);

            buildButtonList.Add(buildButton15);
            buildButtonList.Add(buildButton16);
            buildButtonList.Add(buildButton17);
            buildButtonList.Add(buildButton18);
            buildButtonList.Add(buildButton19);
        }

        /// <summary>
        /// BuildingButtons placement for map2
        /// </summary>
        /// <param name="graphicsDevice"></param>
        private void buildButtonsToUse2(GraphicsDevice graphicsDevice)
        {
            BuildButton buildButton20 = new BuildButton("buildButton", buildButtonTexture, 350, 400, graphicsDevice, player, this);
            BuildButton buildButton21 = new BuildButton("buildButton", buildButtonTexture, 350, 600, graphicsDevice, player, this);
            BuildButton buildButton22 = new BuildButton("buildButton", buildButtonTexture, 350, 800, graphicsDevice, player, this);

            BuildButton buildButton23 = new BuildButton("buildButton", buildButtonTexture, 550, 400, graphicsDevice, player, this);
            BuildButton buildButton24 = new BuildButton("buildButton", buildButtonTexture, 550, 600, graphicsDevice, player, this);
            BuildButton buildButton25 = new BuildButton("buildButton", buildButtonTexture, 550, 800, graphicsDevice, player, this);

            BuildButton buildButton26 = new BuildButton("buildButton", buildButtonTexture, 790, 800, graphicsDevice, player, this);
            BuildButton buildButton27 = new BuildButton("buildButton", buildButtonTexture, 1030, 800, graphicsDevice, player, this);

            BuildButton buildButton28 = new BuildButton("buildButton", buildButtonTexture, 675, 1000, graphicsDevice, player, this);
            BuildButton buildButton29 = new BuildButton("buildButton", buildButtonTexture, 900, 1000, graphicsDevice, player, this);
            BuildButton buildButton30 = new BuildButton("buildButton", buildButtonTexture, 1175, 1000, graphicsDevice, player, this);

            BuildButton buildButton31 = new BuildButton("buildButton", buildButtonTexture, 1300, 400, graphicsDevice, player, this);
            BuildButton buildButton32 = new BuildButton("buildButton", buildButtonTexture, 1300, 600, graphicsDevice, player, this);
            BuildButton buildButton33 = new BuildButton("buildButton", buildButtonTexture, 1300, 800, graphicsDevice, player, this);

            BuildButton buildButton34 = new BuildButton("buildButton", buildButtonTexture, 1500, 400, graphicsDevice, player, this);
            BuildButton buildButton35 = new BuildButton("buildButton", buildButtonTexture, 1500, 600, graphicsDevice, player, this);
            BuildButton buildButton36 = new BuildButton("buildButton", buildButtonTexture, 1500, 800, graphicsDevice, player, this);


            buildButtonList.Add(buildButton20);
            buildButtonList.Add(buildButton21);
            buildButtonList.Add(buildButton22);

            buildButtonList.Add(buildButton23);
            buildButtonList.Add(buildButton24);
            buildButtonList.Add(buildButton25);

            buildButtonList.Add(buildButton26);
            buildButtonList.Add(buildButton27);

            buildButtonList.Add(buildButton28);
            buildButtonList.Add(buildButton29);
            buildButtonList.Add(buildButton30);

            buildButtonList.Add(buildButton31);
            buildButtonList.Add(buildButton32);
            buildButtonList.Add(buildButton33);

            buildButtonList.Add(buildButton34);
            buildButtonList.Add(buildButton35);
            buildButtonList.Add(buildButton36);
        }

        /// <summary>
        /// BuildingButtons placement for map3
        /// </summary>
        /// <param name="graphicsDevice"></param>
        private void buildButtonsToUse3(GraphicsDevice graphicsDevice)
        {
            BuildButton buildButton40 = new BuildButton("buildButton", buildButtonTexture, 350, 400, graphicsDevice, player, this);
            BuildButton buildButton41 = new BuildButton("buildButton", buildButtonTexture, 350, 600, graphicsDevice, player, this);
            BuildButton buildButton42 = new BuildButton("buildButton", buildButtonTexture, 350, 800, graphicsDevice, player, this);

            BuildButton buildButton43 = new BuildButton("buildButton", buildButtonTexture, 550, 400, graphicsDevice, player, this);
            BuildButton buildButton44 = new BuildButton("buildButton", buildButtonTexture, 550, 600, graphicsDevice, player, this);
            BuildButton buildButton45 = new BuildButton("buildButton", buildButtonTexture, 550, 800, graphicsDevice, player, this);

            BuildButton buildButton46 = new BuildButton("buildButton", buildButtonTexture, 675, 1000, graphicsDevice, player, this);

            BuildButton buildButton47 = new BuildButton("buildButton", buildButtonTexture, 800, 400, graphicsDevice, player, this);
            BuildButton buildButton48 = new BuildButton("buildButton", buildButtonTexture, 800, 600, graphicsDevice, player, this);
            BuildButton buildButton49 = new BuildButton("buildButton", buildButtonTexture, 800, 800, graphicsDevice, player, this);

            BuildButton buildButton50 = new BuildButton("buildButton", buildButtonTexture, 1000, 400, graphicsDevice, player, this);
            BuildButton buildButton51 = new BuildButton("buildButton", buildButtonTexture, 1000, 600, graphicsDevice, player, this);
            BuildButton buildButton52 = new BuildButton("buildButton", buildButtonTexture, 1000, 800, graphicsDevice, player, this);

            BuildButton buildButton53 = new BuildButton("buildButton", buildButtonTexture, 1125, 150, graphicsDevice, player, this);

            BuildButton buildButton54 = new BuildButton("buildButton", buildButtonTexture, 1250, 400, graphicsDevice, player, this);
            BuildButton buildButton55 = new BuildButton("buildButton", buildButtonTexture, 1250, 600, graphicsDevice, player, this);
            BuildButton buildButton56 = new BuildButton("buildButton", buildButtonTexture, 1250, 800, graphicsDevice, player, this);

            BuildButton buildButton57 = new BuildButton("buildButton", buildButtonTexture, 1450, 400, graphicsDevice, player, this);
            BuildButton buildButton58 = new BuildButton("buildButton", buildButtonTexture, 1450, 600, graphicsDevice, player, this);
            BuildButton buildButton59 = new BuildButton("buildButton", buildButtonTexture, 1450, 800, graphicsDevice, player, this);



            buildButtonList.Add(buildButton40);
            buildButtonList.Add(buildButton41);
            buildButtonList.Add(buildButton42);

            buildButtonList.Add(buildButton43);
            buildButtonList.Add(buildButton44);
            buildButtonList.Add(buildButton45);

            buildButtonList.Add(buildButton46);

            buildButtonList.Add(buildButton47);
            buildButtonList.Add(buildButton48);
            buildButtonList.Add(buildButton49);

            buildButtonList.Add(buildButton50);
            buildButtonList.Add(buildButton51);
            buildButtonList.Add(buildButton52);

            buildButtonList.Add(buildButton53);

            buildButtonList.Add(buildButton54);
            buildButtonList.Add(buildButton55);
            buildButtonList.Add(buildButton56);

            buildButtonList.Add(buildButton57);
            buildButtonList.Add(buildButton58);
            buildButtonList.Add(buildButton59);
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
            currentKBState = Keyboard.GetState();

            inRangeCheck.CheckRange(towerList, enemyList);

            foreach(Towers tower in towerList)
            {
                tower.Update(gameTime, this);
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                if (!enemyList[i].alive)
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

			for (int i = 0; i < explosionList.Count; i++)
			{
				if (explosionList[i].done)
					explosionList[i] = null;
				else
					explosionList[i].Update(gameTime);

				if (explosionList[i] == null)
					explosionList.Remove(explosionList[i]);
			}

            foreach (BuildButton button in buildButtonList)
                button.Update(gameTime);

            if(uiButton != null)
                uiButton.Update(gameTime);

            ui.Update(gameTime);

            player.Update(gameTime);

            enemyController.Update(gameTime);

            if (enemyList.Count == 0)
                enemyController.InitiateSpawn = true;

            oldKBState = currentKBState;

            if(player.life <= 0)
            {
                game1.playerIsDead = true;
            }
        }
        

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
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

            foreach (Projectile proj in projectileList)
            {
                if (proj != null)
                    proj.Draw(batch);
            }

            foreach (Towers tower in towerList)
                tower.Draw(batch);

            foreach (Enemys enemy in enemyList)
            {
                if (enemy != null)
                    enemy.Draw(batch);
            }

			foreach (Explosion explo in explosionList)
			{
				if (explo != null)
					explo.Draw(batch, graphicsDevice);
			}

            ui.Draw(batch);

            if(uiButton != null)
                uiButton.Draw(batch);

            player.Draw(batch);
        }
    }
}
