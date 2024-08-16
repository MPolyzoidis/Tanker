using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class EnemyBullet : MonoBehaviour
    {
        public Vector2 direction = new Vector2(0,-1);
        public float speed = 2;

        public Vector2 velocity;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 1);
        }

        // Update is called once per frame
        void Update()
        {
            velocity = direction * speed;
        }

        public void FixedUpdate()
        {
            Vector2 pos = transform.position;

            pos += velocity * Time.fixedDeltaTime;

            transform.position = pos;
        }
    }
}
