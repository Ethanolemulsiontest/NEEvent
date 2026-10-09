using System.Collections.Generic;
using UnityEngine;

public class PlayerTasks : MonoBehaviour
{
    private PlayerRole playerRole;

    [Header("Player's 3 Tasks")]
    public List<string> currentTasks = new List<string>();

    private void Awake()
    {
        playerRole = GetComponent<PlayerRole>();
    }

    public void AssignThreeTasks()
    {
        List<string> taskPool = GetTaskPool();

        currentTasks.Clear();

        // Pick 3 unique random tasks
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, taskPool.Count);

            currentTasks.Add(taskPool[randomIndex]);
            taskPool.RemoveAt(randomIndex);
        }

        Debug.Log("Role: " + playerRole.currentRole);

        foreach (string task in currentTasks)
        {
            Debug.Log("Task: " + task);
        }
    }

    private List<string> GetTaskPool()
    {
        List<string> tasks = new List<string>();

        switch (playerRole.currentRole)
        {
            // =====================
            // FOOD GATHERER
            // =====================
            case PlayerRole.Role.FoodGatherer:

                tasks.Add("Harvest Crops");
                tasks.Add("Plant New Crops");
                tasks.Add("Collect Eggs");
                tasks.Add("Feed the Chickens");
                tasks.Add("Draw Water");
                tasks.Add("Search for Food");
                tasks.Add("Gather Firewood");
                tasks.Add("Deliver Food");
                tasks.Add("Prepare Rations");

                break;


            // =====================
            // CRAFTSMAN
            // =====================
            case PlayerRole.Role.Craftsman:

                // Add your 9 Craftsman tasks here
                tasks.Add("Gather Wood");
                tasks.Add("Gather Scrap");
                tasks.Add("Craft Tools");
                tasks.Add("Build Storage Crate");
                tasks.Add("Make Farming Tools");
                tasks.Add("Craft Water Bucket");
                tasks.Add("Prepare Building Materials");
                tasks.Add("Craft Medical Supplies");
                tasks.Add("Deliver Supplies");

                break;


            // =====================
            // MEDIC
            // =====================
            case PlayerRole.Role.Medic:

                tasks.Add("Gather Medicinal Herbs");
                tasks.Add("Collect Clean Water");
                tasks.Add("Prepare Medicine");
                tasks.Add("Prepare Bandages");
                tasks.Add("Treat a Patient");
                tasks.Add("Deliver Medicine");
                tasks.Add("Check Villagers");
                tasks.Add("Restock Clinic");
                tasks.Add("Prepare Emergency Kit");

                break;
        }

        return tasks;
    }
}