using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tanker
{
    public class GridManager : MonoBehaviour
    {
        // Reference to the player tank
        public GameObject playerTank;

        // Reference to the grid's end position
        public Transform endOfGrid;

        // Reference to the starting position of the grid
        public Transform startOfGrid;

        void Update()
        {
            // Check if the player tank has reached the end of the grid
            if (playerTank != null && playerTank.transform.position.y >= endOfGrid.position.y)
            {
                // Relocate the player tank and camera to the start of the grid
                playerTank.transform.position = new Vector2 (playerTank.transform.position.x, startOfGrid.position.y);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, startOfGrid.position.y + 4, Camera.main.transform.position.z);
            }
        }
    }

}
