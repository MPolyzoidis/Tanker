using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class EnemyGun : MonoBehaviour
    {

        public EnemyBullet enemyBullet;

        public void Shoot()
        {
            // Instantiate the bullet
            GameObject go = Instantiate(enemyBullet.gameObject, transform.position, Quaternion.Euler(0, 0, -90));
        }
    }
}
