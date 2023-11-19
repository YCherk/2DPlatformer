using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Transform waypointA;
    public Transform waypointB;
    public float speed = 2.0f;
    public AudioSource boxsound;
    private Transform currentWaypoint;
    private bool movingTowardsA = true;

    private void Start()
    {
        // make currentwaypoint the starting waypoint
        currentWaypoint = waypointA;
    }

    private void Update()
    {
        // Move saw towards the current waypoint
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);

        // Checks if saw has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
        {
            boxsound.Play();
           
            if (movingTowardsA)
            {
                currentWaypoint = waypointB;
            }
            else
            {
                currentWaypoint = waypointA;
            }

           
            movingTowardsA = !movingTowardsA;
        }
    }
}
