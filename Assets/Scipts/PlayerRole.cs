using UnityEngine;

public class PlayerRole : MonoBehaviour
{
    public enum Role
    {
        FoodGatherer,
        Craftsman,
        Medic
    }

    [Header("Assigned Role")]
    public Role currentRole;

    private void Start()
    {
        AssignRandomRole();
        GetComponent<PlayerTasks>().AssignThreeTasks();
    }

    private void AssignRandomRole()
    {
        currentRole = (Role)Random.Range(0, 3);

        Debug.Log("Assigned Role: " + currentRole);
    }
}