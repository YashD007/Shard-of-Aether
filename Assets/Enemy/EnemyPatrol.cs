using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   public Transform[] waypoints;
   public float speed = 2f;
   private int currentWayPointIndex = 0;

   private void Update()
   {
      if(waypoints.Length == 0) return;

      Transform targetWaypoint = waypoints[currentWayPointIndex];
      transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

      if(Vector2.Distance(transform.position, targetWaypoint.position)<0.01f);
      {
         currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
      }
   }
}
