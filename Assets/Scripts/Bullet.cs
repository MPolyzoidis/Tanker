using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class Bullet : MonoBehaviour
    {

        public Vector2 direction;
        public float speed = 2;

        public Vector2 velocity;

        public void SetDirection(Vector2 newDirection)
        {
            direction = newDirection.normalized; // Normalize the direction to ensure consistent speed
        }

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
