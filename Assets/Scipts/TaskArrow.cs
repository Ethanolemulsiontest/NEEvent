using UnityEngine;

public class TaskArrow : MonoBehaviour
{
    [Header("References")]
    public PlayerTasks playerTasks;
    public Transform player;

    [Header("Arrow Settings")]
    public float distanceFromPlayer = 1.5f;

    private TaskLocation targetLocation;

    private void Update()
    {
        FindCurrentTarget();

        if (targetLocation == null)
        {
            gameObject.SetActive(false);
            return;
        }

        // Direction from player to task
        Vector2 direction =
            (targetLocation.transform.position - player.position).normalized;

        // Keep arrow near player
        transform.position =
            player.position + (Vector3)(direction * distanceFromPlayer);

        // Point arrow toward task
        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FindCurrentTarget()
    {
        if (playerTasks == null)
            return;

        // Go through tasks IN ORDER
        foreach (TaskData task in playerTasks.currentTasks)
        {
            // Skip completed tasks
            if (task.completed)
                continue;

            // Find the location belonging to this task
            foreach (TaskLocation location in TaskLocation.allLocations)
            {
                if (location.taskID == task.id)
                {
                    targetLocation = location;
                    return;
                }
            }
        }

        // No unfinished tasks
        targetLocation = null;
    }
}