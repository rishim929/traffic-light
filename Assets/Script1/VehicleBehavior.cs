using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    public float speed = 5f; // Speed of the vehicle
    public Transform[] waypoints; // Waypoints defining the road lane
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool canMove = true; // Whether the vehicle can move

    private void Update()
    {
        if (canMove && waypoints.Length > 0)
        {
            // Move towards the current waypoint
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

            // Check if the vehicle has reached the waypoint
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0; // Reset to the first waypoint
                }
            }
        }
    }

    // Stops the vehicle
    public void StopVehicle()
    {
        canMove = false;
        
    }

    public void ResumeVehicle()
    {
        canMove = true;
    }

}