using UnityEngine;

namespace tanker
{
    public class EnemyTank: MonoBehaviour
    {
        private float timer = 0f;
        private float interval = 0.5f;
        public float moveSpeed = 5;

        EnemyGun[] enemyGuns;

        private void Start()
        {
            enemyGuns = transform.GetComponentsInChildren<EnemyGun>();
        }

        private void FixedUpdate()
        {
            Vector2 pos = transform.position;

            pos.y -= moveSpeed * Time.fixedDeltaTime;

            transform.position = pos;
        }

        private void Update()
        {
            //-----------Shooting----------------//

            // Increment the timer by the time passed since the last frame
            timer += Time.deltaTime;

            // Check if the timer exceeds the interval (0.5 seconds)
            if (timer >= interval)
            {
                foreach (EnemyGun enemyGun in enemyGuns) 
                {
                    enemyGun.Shoot();
                } 

                // Subtract the interval from the timer to keep it accurate
                timer -= interval;
            }
        }
    }
}
