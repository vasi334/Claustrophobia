using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of camera movement
    public float mouseSensitivity = 2f; // Sensitivity of mouse movement

    void Update()
    {
        // Calculate keyboard movement direction based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 keyboardMoveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Calculate mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera based on mouse movement
        transform.Rotate(Vector3.up, mouseX, Space.World); // Rotate around world up axis
        transform.Rotate(Vector3.left, mouseY, Space.Self); // Rotate around camera's local left axis

        // Move the camera based on keyboard input
        Vector3 moveDirection = transform.forward * keyboardMoveDirection.z + transform.right * keyboardMoveDirection.x;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World); // Move in world space
    }
}
