using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class EnemyJeep : MonoBehaviour
    {
        public float moveSpeed = 5;

        private void FixedUpdate()
        {
            Vector2 pos = transform.position;

            pos.y -= moveSpeed * Time.fixedDeltaTime;

            transform.position = pos;
        }
    }
}
