using UnityEngine;

// This script allows the player to move like in a First-Person Shooter (FPS) game
public class FPSController : MonoBehaviour
{
    // Speed at which the player moves
    public float moveSpeed = 5f;

    // Sensitivity of mouse input for rotation
    public float mouseSensitivity = 2f;

    // Stores current vertical rotation
    float rotationX = 0f;

    void Update()
    {
        // ---- Movement Input ----

        // Get horizontal input (A/D keys)
        float h = Input.GetAxis("Horizontal");

        // Get vertical input (W/S keys)
        float v = Input.GetAxis("Vertical");

        // Calculate movement direction based on forward and right vectors
        Vector3 move = transform.forward * v + transform.right * h;

        // Apply movement over time
        transform.position += move * moveSpeed * Time.deltaTime;

        // ---- Mouse Rotation ----

        // Get horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Rotate the player horizontally (Y-axis) based on mouse input
        transform.Rotate(0f, mouseX, 0f);
    }
}
