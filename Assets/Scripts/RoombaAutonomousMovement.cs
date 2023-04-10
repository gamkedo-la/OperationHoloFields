using System.Collections;
using UnityEngine;

namespace AutonomousMovement
{
    public class RoombaAutonomousMovement : MonoBehaviour, IAutonomousMovement
    {

        public AutonomousMovementWaypoint[] Waypoints
        {
            get => waypoints;
            set => waypoints = value;
        }
        float IAutonomousMovement.speed { get => speed; set => speed = value; }
        AutonomousMovementWaypoint IAutonomousMovement.currentWaypoint { get => currentWaypoint; set => currentWaypoint = value; }
        [SerializeField]
        public float speed = 5f;
        [SerializeField]
        public AutonomousMovementWaypoint currentWaypoint;
        private float lookDirection;

        [SerializeField]
        public AutonomousMovementWaypoint[] waypoints;

        [SerializeField]
        public int currentWaypointIndex;

        [SerializeField]
        public float pauseTime = 2f;

        public float timeWaited = 0f;

        [SerializeField] int nextWaypoint;
        [SerializeField] int lookAheadWaypoint;

        [SerializeField] AutonomousMovementWaypoint nextWaypointObject { get => waypoints[nextWaypoint]; }
        public void Move()
        {
            // Check the distance from the current waypoint to the next waypoint, and move the object towards the next waypoint
            float waypointDistance = Vector3.Distance(this.transform.position, this.Waypoints[currentWaypointIndex].position);
            float currentWaypointRadius = this.Waypoints[currentWaypointIndex].radius;
            if (waypointDistance > currentWaypointRadius)
            {
                // Move the object to the next waypoint
                this.transform.position = Vector3.MoveTowards(this.transform.position, this.Waypoints[currentWaypointIndex].position, this.speed * Time.deltaTime);
            }
            // If the object has reached the next waypoint, set the current waypoint to the next waypoint
            else
            {
                // The step size is equal to speed times frame time.
                float singleStep = speed * Time.deltaTime;
                Vector3 targetDirection = this.Waypoints[(currentWaypointIndex + 1) % (this.Waypoints.Length)].position - transform.position;
                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                if (transform.rotation != Quaternion.LookRotation(newDirection))
                {
                    timeWaited += Time.deltaTime;
                    transform.rotation = Quaternion.LookRotation(newDirection);
                }
                else
                {
                    timeWaited = 0f;
                    currentWaypointIndex += 1;
                    currentWaypointIndex = currentWaypointIndex % (this.Waypoints.Length);
                    this.currentWaypoint = this.Waypoints[currentWaypointIndex];
                }
            }
        }
        public void Stop()
        {
            // Stop the object

            // Throw not implemented
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            Move();
        }

        public void Start()
        {
            // Set the current waypoint to the first waypoint in the array
            this.currentWaypoint = this.Waypoints[0];
            currentWaypointIndex = System.Array.IndexOf(this.Waypoints, this.currentWaypoint);
        }
    }
}