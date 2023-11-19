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
       
        currentWaypoint = waypointA;
    }

    private void Update()
    {
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);

       
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
        {
            
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
