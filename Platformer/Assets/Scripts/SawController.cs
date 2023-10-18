using UnityEngine;

public class SawController : MonoBehaviour
{
    public Transform waypointA;
    public Transform waypointB;
    public float speed = 2.0f;

    private Transform currentWaypoint;
    private bool movingTowardsA = true;

    private void Start()
    {
        // Initialize currentWaypoint to the starting point (waypointA)
        currentWaypoint = waypointA;
    }

    private void Update()
    {
        // Move the saw towards the current waypoint
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);

        // Check if the saw has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
        {
            // Switch to the other waypoint
            if (movingTowardsA)
            {
                currentWaypoint = waypointB;
            }
            else
            {
                currentWaypoint = waypointA;
            }

            // Toggle the direction
            movingTowardsA = !movingTowardsA;
        }
    }
}
