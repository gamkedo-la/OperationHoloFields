using System.Collections;

namespace AutonomousMovement
{
    public interface IAutonomousMovement
    {
        AutonomousMovementWaypoint[] Waypoints
        {
            get;
            set;
        }

        float speed
        {
            get;
            set;
        }
        AutonomousMovementWaypoint currentWaypoint
        {
            get;
            set;
        }
        void Move();
        void Stop();

    }
}