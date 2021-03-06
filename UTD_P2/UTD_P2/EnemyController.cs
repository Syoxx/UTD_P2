﻿using System;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    /// <summary>
    /// Used to spawn Enemys and handles timers for enemy spawning and wave initiation
    /// </summary>
    class EnemyController
    {
        private float timerWaves, timerEnemys, startFirstWave, timerAfterFirstWave, enemySpeed, enemySpawnTime;
        private int nrToSpawn, nrOfWaves, enemyLife, countEnemys, countWaves;
        private bool isFirstWave, spawnNewEnemys, initiateSpawn, stopTimer;
        Vector2 spawnPosition;
        private int enemyBounty;


        Texture2D enemy1, enemy2, enemy3, enemy4, enemyTexture;

        
        Level level;
        Player player;
        Enemys enemys;
        GraphicsDevice graphicsDevice;

        // Level switch
        Game1 game1;
        private int mapChangeIndicator;

        string contentPath = "Content/Assets/Enemys/";
        private bool doneSpawning;

        public bool InitiateSpawn
        {
            get { return initiateSpawn; }
            set { initiateSpawn = value; }
        }

        /// <summary>
        /// Constructs the Enemy controller with the appropriate values
        /// </summary>
        /// <param name="nrToSpawn"></param>
        /// <param name="nrOfWaves"></param>
        /// <param name="level"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="player"></param>
        /// <param name="game1"></param>
        /// <param name="mapInUse"></param>
        public EnemyController(int nrToSpawn, int nrOfWaves, Level level, GraphicsDevice graphicsDevice, Player player, Game1 game1, int mapInUse)
        {
            this.nrOfWaves = nrOfWaves;
            this.nrToSpawn = nrToSpawn;
            isFirstWave = true;
            timerWaves = 0;
            timerEnemys = 0;
            this.level = level;
            this.player = player;
            this.graphicsDevice = graphicsDevice;
			this.game1 = game1;
            startFirstWave = 5;
            timerAfterFirstWave = 15;
            spawnNewEnemys = false;
            countWaves = 1;
            countEnemys = 0;
            enemyBounty = 1;
            enemySpeed = 2;
            enemyLife = 15;
            enemySpawnTime = 1f;
            timerEnemys = 1;
            enemy1 = ContentConverter.Convert(contentPath + "enemy1.png", graphicsDevice);
            enemy2 = ContentConverter.Convert(contentPath + "enemy2.png", graphicsDevice);
            enemy3 = ContentConverter.Convert(contentPath + "enemy3.png", graphicsDevice);
            enemy4 = ContentConverter.Convert(contentPath + "enemy4.png", graphicsDevice);
            enemyTexture = enemy1;
            spawnPosition = level.Waypoints.ElementAt<Vector2>(0);
            mapChangeIndicator = mapInUse;
        }

        /// <summary>
        /// Updates Timers and initiates Waves and Enemys
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (!stopTimer)
                timerWaves = timerWaves + (float)gameTime.ElapsedGameTime.TotalSeconds;

            timerEnemys += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timerWaves >= startFirstWave && isFirstWave && initiateSpawn)
                SpawnFirstWave();

            if (timerWaves >= timerAfterFirstWave && !isFirstWave && initiateSpawn)
                SpawnWave();

            if (timerEnemys >= enemySpawnTime && countEnemys <= nrToSpawn && spawnNewEnemys)
                SpawnEnemy(enemyTexture);
        }

        /// <summary>
        /// Initiates a Wave and sets the values for the Enemys
        /// </summary>
        private void SpawnWave()
        {
            stopTimer = true;
            initiateSpawn = false;
            spawnNewEnemys = true;

            switch (countWaves)
            {
                case 1:
                    enemyBounty = 1;
                    enemySpeed = 2;
                    enemyTexture = enemy1;
                    enemyLife = 15;
                    break;
                case 2:
                    enemyBounty = 2;
                    enemySpeed = 3;
                    enemyTexture = enemy2;
                    enemyLife = 20;
                    break;
                case 3:
                    enemyBounty = 2;
                    enemySpeed = 3;
                    enemyTexture = enemy2;
                    enemyLife = 31;
                    break;
                case 4:
                    enemyBounty = 2;
                    enemySpeed = 3;
                    enemyTexture = enemy2;
                    enemyLife = 36;
                    break;
                case 5:
                    enemyBounty = 3;
                    enemySpeed = 5;
                    enemyTexture = enemy3;
                    enemyLife = 66;
                    break;
                case 6:
                    enemyBounty = 3;
                    enemySpeed = 4;
                    enemyTexture = enemy3;
                    enemyLife = 76;
                    break;
                case 7:
                    enemyBounty = 3;
                    enemySpeed = 4;
                    enemyTexture = enemy3;
                    enemyLife = 86;
                    break;
                case 8:
                    enemyBounty = 4;
                    enemySpeed = 4;
                    enemyTexture = enemy4;
                    enemyLife = 106;
                    break;
                case 9:
                    enemyBounty = 4;
                    enemySpeed = 4;
                    enemyTexture = enemy4;
                    enemyLife = 136;
                    break;
                case 10:
                    enemyBounty = 4;
                    enemySpeed = 5;
                    enemyTexture = enemy4;
                    enemyLife = 155;
                    break;

            }


            countWaves++;

            //loads next level after last wave
            if (countWaves > nrOfWaves)
            {
                mapChangeIndicator++;
                game1.LoadLevel(mapChangeIndicator);
            }
        }

        /// <summary>
        /// Initiates the first Wave
        /// </summary>
        private void SpawnFirstWave()
        {
            initiateSpawn = false;
            spawnNewEnemys = true;
            enemyTexture = enemy1;
            isFirstWave = false;
            countWaves++;
        }

        /// <summary>
        /// Spawns enemys until the desired number of enemys is spawned
        /// </summary>
        /// <param name="texture"></param>
        private void SpawnEnemy(Texture2D texture)
        {
            Enemys enemy = new Enemys(player, texture, spawnPosition, enemyLife, enemyBounty, enemySpeed, graphicsDevice);
            enemy.SetWaypoints(level.Waypoints);
            level.AddEnemy(enemy);
            countEnemys++;
            timerEnemys = 0;
            if (countEnemys >= nrToSpawn)
            {
                countEnemys = 0;
                spawnNewEnemys = false;
                timerWaves = 0;
                stopTimer = false;
            }
        }
    }
}
