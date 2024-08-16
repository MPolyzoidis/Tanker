using UnityEngine;

public class Crosshair : MonoBehaviour
{

    void Update()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f; // Ensure the mouse position is at the same z-coordinate as the object

        // Move the object to the mouse position
        transform.position = worldMousePosition;

        Cursor.visible = false;
    }
}
