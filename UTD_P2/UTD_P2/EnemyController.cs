using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace UTD_P2
{
    /// <summary>
    /// EnemyController checkt in der Update wenn das Leben der Enemys <=0 ist, wenn ja -> Destroy (null setzen) und dem Player Coins gutschreiben
    /// Timer wird gestartet wenn Enemys <= 0 ist.
    /// Wenn Timer = 0, Enemys nach Anzahl spawnen.
    /// 
    /// EnemyWaypoints nach Map (Lvl) -> switch abfrage nach lvl string
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
        private int mapChangeIndicator = 1;

        string contentPath = "Content/Assets/Enemys/";
        private bool doneSpawning;

        public bool InitiateSpawn
        {
            get { return initiateSpawn; }
            set { initiateSpawn = value; }
        }

        public EnemyController(int nrToSpawn, int nrOfWaves, Level level, GraphicsDevice graphicsDevice, Player player, Game1 game1)
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
            //CHANGE BACK TO 1 AFTER TESTING
            countWaves = 9;
            countEnemys = 0;
            enemyBounty = 1;
            enemySpeed = 2;
            enemyLife = 10;
            enemySpawnTime = 1f;
            timerEnemys = 1;
            enemy1 = ContentConverter.Convert(contentPath + "enemy1.png", graphicsDevice);
            enemy2 = ContentConverter.Convert(contentPath + "enemy2.png", graphicsDevice);
            enemy3 = ContentConverter.Convert(contentPath + "enemy3.png", graphicsDevice);
            enemy4 = ContentConverter.Convert(contentPath + "enemy4.png", graphicsDevice);
            enemyTexture = enemy1;
            spawnPosition = level.Waypoints.ElementAt<Vector2>(0);
        }

        public void Update(GameTime gameTime)
        {
            if (!stopTimer)
                timerWaves = timerWaves + (float)gameTime.ElapsedGameTime.TotalSeconds;

            Console.WriteLine(timerWaves);

            timerEnemys += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timerWaves >= startFirstWave && isFirstWave && initiateSpawn)
                SpawnFirstWave();

            if (timerWaves >= timerAfterFirstWave && !isFirstWave && initiateSpawn)
                SpawnWave();

            if (timerEnemys >= enemySpawnTime && countEnemys <= nrToSpawn && spawnNewEnemys)
                SpawnEnemy(enemyTexture);
            
        }

        private void SpawnWave()
        {
            stopTimer = true;
            initiateSpawn = false;
            spawnNewEnemys = true;
            if (countWaves <= 4 && countWaves > 1)
            {
                enemyTexture = enemy2;
                enemyBounty = 2;
                enemySpeed = 3;
                enemyLife = 15;
            }
            if (countWaves <= 7 && countWaves > 4)
            {
                enemyBounty = 3;
                enemySpeed = 4;
                enemyTexture = enemy3;
                enemyLife = 20;
            }
            if (countWaves >= 8)
            {
                enemyBounty = 4;
                enemySpeed = 6;
                enemyTexture = enemy4;
                enemyLife = 30;
            }
            countWaves++;

            // Level switch
            if (countWaves > nrOfWaves)
            {
                mapChangeIndicator++;
                game1.LoadLevel(mapChangeIndicator);
                Console.WriteLine(mapChangeIndicator);
            }
        }

        private void SpawnFirstWave()
        {
            initiateSpawn = false;
            spawnNewEnemys = true;
            enemyTexture = enemy1;
            isFirstWave = false;
            countWaves++;
        }

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
