using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float speed = 2f; // Flight speed
    public float areaSize = 5f; // Surveilling area
    public float flyHeight = 15f; // Flight height
    private Vector3 targetPosition;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        // Set initial random position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards target position
        MoveTowardsTarget();

        // Check if reached target position
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        float x = Random.Range(-areaSize / 2, areaSize / 2);
        float z = Random.Range(-areaSize / 2, areaSize / 2);
        targetPosition = new Vector3(x, flyHeight, z);
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
