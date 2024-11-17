using UnityEngine;

public class DefenderMoves : MonoBehaviour
{
    public float speed = 2f; // Flight speed
    public float areaSize = 5f; // Surveilling area
    public float flyHeight = 15f; // Flight height
    private Vector3 targetPosition;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        SetRandomTargetPosition();
    }

    void Update()
    {
        if (!IsOverlappingWithOtherDefenders(targetPosition))
        {
            MoveTowardsTarget();

            if (Vector3.Distance(transform.position, targetPosition) < 1f)
            {
                SetRandomTargetPosition();
            }
        }
        else
        {
            SetRandomTargetPosition(); // Reset if overlap detected
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

    bool IsOverlappingWithOtherDefenders(Vector3 newPosition)
    {
        float minDistance = 1.5f; // Minimum allowed distance between objects
        GameObject[] defenders = GameObject.FindGameObjectsWithTag("Defender");

        foreach (GameObject defender in defenders)
        {
            if (defender != this.gameObject)
            {
                float distance = Vector3.Distance(defender.transform.position, newPosition);
                if (distance < minDistance)
                {
                    return true; // Overlap detected
                }
            }
        }
        return false; // No overlap
    }
}
