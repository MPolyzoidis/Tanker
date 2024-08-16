using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class Gun : MonoBehaviour
    {
        public Bullet bullet;

        private TurretController turretController; // Reference to the TurretController instance

        // Setter for the TurretController reference
        public void SetTurretController(TurretController controller)
        {
            turretController = controller;
        }

        public void Shoot()
        {
            // Check if the TurretController reference is valid
            if (turretController != null)
            {
                // Get the direction based on the turret's rotation
                Vector2 direction = transform.right;

                // Instantiate the bullet
                GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.Euler(0, 0, turretController.turretAngle));
                // Get the bullet component
                Bullet newBullet = go.GetComponent<Bullet>();
                // Set the direction of the bullet
                if (newBullet != null)
                {
                    newBullet.SetDirection(direction);
                }
            }
            else
            {
                Debug.LogError("TurretController reference is null.");
            }
        }
    }
}
