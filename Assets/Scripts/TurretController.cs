using UnityEngine;

namespace tanker
{
    public class TurretController : MonoBehaviour
    {
        private float timer = 0f;
        private float interval = 0.5f;
        public float turretAngle;

        Gun[] guns;

        private void Start()
        {
            guns = transform.GetComponentsInChildren<Gun>();

            // Pass the reference to the TurretController instance to each Gun instance
            foreach (Gun gun in guns)
            {
                gun.SetTurretController(this);
            }
        }


        // Update is called once per frame
        void Update()
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the object to the mouse position
            Vector3 direction = mousePosition - transform.position;

            // Calculate the angle between the object's forward direction and the direction to the mouse
            turretAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the rotation only on the z-axis to follow the mouse
            transform.rotation = Quaternion.Euler(0f, 0f, turretAngle);


            //-----------Shooting----------------//

            // Increment the timer by the time passed since the last frame
            timer += Time.deltaTime;

            // Check if the timer exceeds the interval (0.5 seconds)
            if (timer >= interval)
            {

                foreach (Gun gun in guns)
                {
                    gun.Shoot();
                }

                // Subtract the interval from the timer to keep it accurate
                timer -= interval;
            }

        }
    }
}
