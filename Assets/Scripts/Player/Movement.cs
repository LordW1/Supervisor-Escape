using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private AudioManager audioSearch;

    [Header("MOVEMENT VALUES")]
    [Space]
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;


    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevent Rigidbody from rotating automatically (we will handle rotation manually)
        audioSearch = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayerToMouse();
    }

    void MovePlayer()
    {
        // Get player input for movement along the X and Y axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Apply movement to the Rigidbody
        if (movement.magnitude >= 0.1f)
        {
            // Move the player in the XY plane (top-down)
            Vector3 moveDirection = movement * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDirection);
        }
    }

    void RotatePlayerToMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure we're working in the 2D plane (z-axis should be 0)

        // Calculate the direction vector from the player to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees between the player and the mouse position
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        // Debugging logs to check mouse position and angle
        Debug.Log("Mouse Position: " + mousePosition);
        Debug.Log("Calculated Angle: " + angle);

        // Create a target rotation using Quaternion.Euler
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Smoothly rotate towards the target angle
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
