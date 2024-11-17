using UnityEngine;

public class AttackerDroneController : MonoBehaviour
{
    public float speed = 5f; // Speed of the drone
    private Vector3 targetPosition; // Target position for the drone

    void Start()
    {
        // Set the initial position of the drone
        transform.position = new Vector3(500, 0, 5);

        // Define the target position where x = 35, maintaining the same y and z coordinates
        targetPosition = new Vector3(35, 15, 5);
    }

    void Update()
    {
        // Move the drone towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the drone reached the target position
        if (transform.position.x == 35)
        {
            Debug.Log("Drone has reached the target x position.");
        }
    }
}
