using UnityEngine;

public class MiniDroneController04 : MonoBehaviour
{
    public float speed = 5f; // Flight speed
    public float flyHeight = 20f; // Flight height
    private Vector3[] edgePoints; // Array to hold points along the perimeter
    private int currentPointIndex = 0; // Index to track the current target point
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Adjust the initial position of the drone to be at the specified fly height
        Vector3 initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 startPosition = new Vector3(transform.position.x, flyHeight, transform.position.z);
        transform.position = Vector3.MoveTowards(initialPosition, startPosition, speed * Time.deltaTime); // Set the initial position at the fly height

        // Define the corners of the perimeter (plane) manually
        edgePoints = new Vector3[]
        {
            new Vector3(40, flyHeight, -40), // Bottom right
            new Vector3(-40, flyHeight, -40), // Bottom left
            new Vector3(-40, flyHeight, 40),  // Top left
            new Vector3(40, flyHeight, transform.position.z),
            new Vector3(40, flyHeight, 40)    // Top right
        };

        // Force the drone to start by flying towards the fourth point (40, 0, 40)
        currentPointIndex = 3; // Index of (40, 0, 40) in the edgePoints array
    }

    void Update()
    {
        // Move towards the current target point
        MoveTowardsTarget();

        // Check if the drone reached the current target point
        if (Vector3.Distance(transform.position, edgePoints[currentPointIndex]) < 0.1f)
        {
            // Move to the next target point, looping back to the start when necessary
            currentPointIndex = (currentPointIndex + 1) % edgePoints.Length;
        }
    }

    void MoveTowardsTarget()
    {
        // Smoothly move the drone towards the current edge point
        transform.position = Vector3.MoveTowards(transform.position, edgePoints[currentPointIndex], speed * Time.deltaTime);
    }
}
