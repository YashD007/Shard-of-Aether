using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Starting point
    public Transform pointB; // Ending point
    public float speed = 2f; // Speed of the platform

    private Vector3 target;

    void Start()
    {
        // Start moving towards point B
        target = pointB.position;
    }

    void Update()
    {
        // Move the platform towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // If the platform reaches the target, switch the target
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

  
}