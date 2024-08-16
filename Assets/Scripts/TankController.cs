using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class TankController : MonoBehaviour
    {
        public float moveSpeed = 3f; // Adjust this value to set the speed of movement

        private float cameraHalfWidth;
        private float objectHalfWidth;
        private float objectHeight;

        public float maxRotationAngle = 120.0f; // Maximum rotation angle
        public float minRotationAngle = 60.0f; // Minimum rotation angle
        private float currentRotationAngle = 90.0f; // Current rotation angle

        private int livesInt = 3;
        public GameObject Life1, Life2, Life3;
        GameObject[] lives;

        private EnemySpawner enemySpawner;

        void Start()
        {
            // Get the main camera and calculate its half width
            cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

            // Calculate the half width of the object
            objectHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f + 0.2f;


            //-----  Make the object not fall behind the camera  -----------//

            // Get the height of the object
            Renderer renderer = GetComponent<Renderer>();
            objectHeight = renderer.bounds.size.y;

            // Initiliaze the lives the player has

            lives = new GameObject[] { Life1, Life2, Life3 };

            //------------//



        }

        // Update is called once per frame
        void Update()
        {
            // Get the horizontal input (A and D keys or left and right arrow keys)
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            // Calculate the horizontal movement amount
            float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime;

            // Calculate the new X position
            float newXPos = Mathf.Clamp(transform.position.x + horizontalMovement, Camera.main.transform.position.x - cameraHalfWidth + objectHalfWidth, Camera.main.transform.position.x + cameraHalfWidth - objectHalfWidth);

            // Update the position of the GameObject
            transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);


            // Update target rotation angle based on input
            float targetRotationAngle = horizontalInput != 0 ?
                Mathf.Clamp(currentRotationAngle + (- horizontalInput * (maxRotationAngle - minRotationAngle)), minRotationAngle, maxRotationAngle) :
                90.0f;

            // Apply rotation around the z-axis
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, targetRotationAngle);


            // ------- Make the object not fall behind the camera ---------//

            // Get the boundaries of the camera's viewport
            float cameraMinY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + (objectHeight / 2);
            float cameraMaxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - (objectHeight / 2);

            // Clamp the object's position to stay within the camera's boundaries
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, cameraMinY + 1, cameraMaxY + 1);
            transform.position = clampedPosition;

            //------ Enemies go behind the player -------//

            enemySpawner = GetComponent<EnemySpawner>();
            List<GameObject> enemyTanksList = enemySpawner.enemyTanks;
            List<GameObject> enemyJeepsList = enemySpawner.enemyJeeps;


            if (enemyTanksList != null)
            {
                for (int i = 0; i < enemyTanksList.Count; i++)
                {
                    if (enemyTanksList[i] != null && enemyTanksList[i].transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
                    {
                        Destroy(enemyTanksList[i]);
                        Destroy(lives[livesInt - 1]);
                        livesInt -= 1;
                    }
                }
            }
            if (enemyJeepsList != null)
            {
                for (int i = 0; i < enemyJeepsList.Count; i++)
                {
                    if (enemyJeepsList[i] != null && enemyJeepsList[i].transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
                    {
                        Destroy(enemyJeepsList[i]);
                        Destroy(lives[livesInt - 1]);
                        livesInt -= 1;
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();

            if (enemyBullet != null)
            {
                livesInt -= 1;
                Destroy(enemyBullet.gameObject);
                Debug.Log("Hit");
                Destroy(lives[livesInt]);
            }
            if (livesInt <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
