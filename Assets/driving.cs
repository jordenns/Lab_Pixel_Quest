using UnityEngine;

public class CarController2D : MonoBehaviour
{
    // Vehicle properties
    public float acceleration = 5f;
    public float maxSpeed = 10f;
    public float turnSpeed = 200f;
    public float driftFactor = 0.95f; // How much the car drifts
    public float driftMultiplier = 2f; // Increased turn during drift

    private Rigidbody2D rb;
    private float moveInput;
    private float turnInput;
    private bool isDrifting;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component missing from this game object");
        }
    }

    void Update()
    {
        // Get input
        moveInput = 0f;
        if (Input.GetKey(KeyCode.W))
            moveInput += 1f;
        if (Input.GetKey(KeyCode.S))
            moveInput -= 1f;

        turnInput = 0f;
        if (Input.GetKey(KeyCode.A))
            turnInput -= 1f;
        if (Input.GetKey(KeyCode.D))
            turnInput += 1f;

        isDrifting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    void FixedUpdate()
    {
        // Apply forward/backward force
        Vector2 forward = transform.up;
        rb.AddForce(forward * moveInput * acceleration);

        // Limit max speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Handle steering
        float currentTurnSpeed = turnSpeed;

        if (isDrifting)
        {
            currentTurnSpeed *= driftMultiplier;
        }

        if (Mathf.Abs(rb.velocity.magnitude) > 0.1f)
        {
            float steerAmount = turnInput * currentTurnSpeed * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation + steerAmount);
        }

        // Apply drift (simulate by reducing lateral velocity)
        Vector2 forwardVelocity = Vector2.Dot(rb.velocity, transform.up) * transform.up;
        Vector2 lateralVelocity = rb.velocity - forwardVelocity;
        rb.velocity = forwardVelocity + lateralVelocity * driftFactor;
    }
}