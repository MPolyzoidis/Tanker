using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class EnemySpawner : MonoBehaviour
    {

        public GameObject EnemyTank, EnemyJeep;

        private GameObject EnemyTankInstance, EnemyJeepInstance;

        public List<GameObject> enemyTanks = new List<GameObject>();
        public List<GameObject> enemyJeeps = new List<GameObject>(); 


        private Vector2 vicinityCenter;
        private Vector2 vicinitySize;

        public void SpawnEnemy()
        {
            Vector2 spawnPosition = GetRandomPosition();
            int randomNumber = Mathf.RoundToInt(Random.Range(1, 3));
            if (randomNumber == 1)
            {
                EnemyTankInstance = Instantiate(EnemyTank, spawnPosition, Quaternion.Euler(0,0,-90));
                enemyTanks.Add(EnemyTankInstance);
            }
            else
            {
                EnemyJeepInstance = Instantiate(EnemyJeep, spawnPosition, Quaternion.identity);
                enemyJeeps.Add(EnemyJeepInstance);
            }
        }

        private Vector2 GetRandomPosition()
        {
            float randomX = Random.Range(vicinityCenter.x - (vicinitySize.x / 2), vicinityCenter.x + (vicinitySize.x / 2));
            float randomY = Random.Range(vicinityCenter.y - (vicinitySize.y / 2), vicinityCenter.y + (vicinitySize.y / 2));

            return new Vector2(randomX, randomY);
        }

        private void Update()
        {
            vicinityCenter = new Vector2(0, Camera.main.transform.position.y + 18);
            vicinitySize = new Vector2(6, 5);
        }

        void Start()
        {

            int randomNumber = Mathf.RoundToInt(Random.Range(4, 10));
            for (int i = 0; i < randomNumber; i++)
            {
                InvokeRepeating("SpawnEnemy", 5f, 12f);
            }
        }
    }
}
