using UnityEngine;

public class TaskLocation : MonoBehaviour
{
    public static System.Collections.Generic.List<TaskLocation> allLocations
        = new System.Collections.Generic.List<TaskLocation>();

    [Header("Task")]
    public TaskID taskID;

    [Header("Interaction UI")]
    public GameObject interactionCanvas;
    public UnityEngine.UI.Button interactButton;

    private PlayerTasks nearbyPlayer;

    private void Awake()
    {
        allLocations.Add(this);
    }

    private void Start()
    {
        interactionCanvas.SetActive(false);

        interactButton.onClick.AddListener(Interact);
    }

    private void OnDestroy()
    {
        allLocations.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerTasks playerTasks = other.GetComponent<PlayerTasks>();

        if (playerTasks != null && playerTasks.HasTask(taskID))
        {
            nearbyPlayer = playerTasks;
            interactionCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerTasks playerTasks = other.GetComponent<PlayerTasks>();

        if (playerTasks == nearbyPlayer)
        {
            nearbyPlayer = null;
            interactionCanvas.SetActive(false);
        }
    }

    public void Interact()
    {
        if (nearbyPlayer == null)
            return;

        if (nearbyPlayer.HasTask(taskID))
        {
            Debug.Log("Doing task: " + taskID);

            nearbyPlayer.CompleteTask(taskID);

            interactionCanvas.SetActive(false);
        }
    }
}