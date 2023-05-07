namespace AutonomousMovement
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AutonomousMovementWaypoint : MonoBehaviour
    {
        public Vector3 position { get => this.transform.position; }
        public float radius;


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            radius = .2f;
            // Draw a sphere at the waypoint position
            Gizmos.DrawWireSphere(this.position, this.radius);

        }
    }
}
