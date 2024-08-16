using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class Destructable : MonoBehaviour
    {

        private bool canBeDestroyed = false;
        public bool isTank = false;
        private int bulletCollisionCount = 0;

        private void Update()
        {
            // Check if the object is within the camera's view
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
            canBeDestroyed = (viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (!canBeDestroyed)
            {
                return;
            }

            Bullet bullet = collision.GetComponent<Bullet>();

            if (bullet != null)
            {
                if (isTank)
                {

                    bulletCollisionCount++;
                    Destroy(bullet.gameObject);
                    Debug.Log("enemy hit");

                    if (bulletCollisionCount > 2)
                    {
                        Destroy(gameObject);
                        bulletCollisionCount = 0;
                    }

                }
                else if (!isTank)
                {
                    Destroy(gameObject);
                    Destroy(bullet.gameObject);
                }
            }
        }
    }
}
