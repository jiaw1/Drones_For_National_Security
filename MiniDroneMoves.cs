using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject dronePrefab;    // Reference to the drone prefab
    public int numberOfDrones = 12;   // Number of drones
    public float circleRadius = 10f;  // Radius of the circle path
    public float height = 12f;        // Height of the drones
    public float rotationSpeed = 30f; // Speed at which the drones rotate around the circle

    private GameObject[] drones;      // Array to store all the drone instances
    private float angleOffset;        // Angle offset for each drone

    // Ensure there is only one Start method
    void Start()
    {
        drones = new GameObject[numberOfDrones];
        angleOffset = 360f / numberOfDrones;

        // Instantiate drones and position them in a circle
        for (int i = 0; i < numberOfDrones; i++)
        {
            // Calculate the angle for each drone
            float angle = i * angleOffset * Mathf.Deg2Rad;
            Vector3 position = new Vector3(Mathf.Cos(angle) * circleRadius, height, Mathf.Sin(angle) * circleRadius);

            // Instantiate the drone and set its position
            drones[i] = Instantiate(dronePrefab, position, Quaternion.identity);
            drones[i].transform.parent = transform; // Optional: parent to this object
        }
    }

    void Update()
    {
        // Rotate each drone around the circle center
        for (int i = 0; i < numberOfDrones; i++)
        {
            float angle = (i * angleOffset + Time.time * rotationSpeed) * Mathf.Deg2Rad;
            Vector3 position = new Vector3(Mathf.Cos(angle) * circleRadius, height, Mathf.Sin(angle) * circleRadius);

            // Update drone position
            drones[i].transform.position = position;
        }
    }
}
