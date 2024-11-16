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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Prevent Rigidbody from rotating automatically (we will handle rotation manually)
        audioSearch = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        // Get the direction from the player to the mouse
        Vector3 direction = (mousePos - transform.position).normalized;

        // Only rotate around the Z-axis
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;  // Calculate angle for rotation
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle); // Only rotate on the Z-axis
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
