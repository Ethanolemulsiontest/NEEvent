using System.Collections.Generic;
using UnityEngine;

public class PlayerTasks : MonoBehaviour
{
    private PlayerRole playerRole;

    [Header("Player's 3 Tasks")]
    public List<TaskData> currentTasks = new List<TaskData>();

    private void Awake()
    {
        playerRole = GetComponent<PlayerRole>();
    }

    public void AssignThreeTasks()
    {
        List<TaskData> taskPool = GetTaskPool();

        currentTasks.Clear();

        int amount = Mathf.Min(3, taskPool.Count);

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, taskPool.Count);

            currentTasks.Add(taskPool[randomIndex]);
            taskPool.RemoveAt(randomIndex);
        }

        Debug.Log("Role: " + playerRole.currentRole);

        foreach (TaskData task in currentTasks)
        {
            Debug.Log("Task: " + task.taskName);
        }
    }

    private List<TaskData> GetTaskPool()
    {
        List<TaskData> tasks = new List<TaskData>();

        switch (playerRole.currentRole)
        {
            case PlayerRole.Role.FoodGatherer:

                tasks.Add(new TaskData(TaskID.HarvestCrops, "Harvest Crops"));
                tasks.Add(new TaskData(TaskID.PlantCrops, "Plant New Crops"));
                tasks.Add(new TaskData(TaskID.CollectEggs, "Collect Eggs"));
                tasks.Add(new TaskData(TaskID.FeedChickens, "Feed the Chickens"));
                tasks.Add(new TaskData(TaskID.DrawWater, "Draw Water"));
                tasks.Add(new TaskData(TaskID.SearchForFood, "Search for Food"));
                tasks.Add(new TaskData(TaskID.GatherFirewood, "Gather Firewood"));
                tasks.Add(new TaskData(TaskID.DeliverFood, "Deliver Food"));
                tasks.Add(new TaskData(TaskID.PrepareRations, "Prepare Rations"));

                break;

            case PlayerRole.Role.Craftsman:

                tasks.Add(new TaskData(TaskID.GatherWood, "Gather Wood"));
                tasks.Add(new TaskData(TaskID.GatherScrap, "Gather Scrap"));
                tasks.Add(new TaskData(TaskID.CraftTools, "Craft Tools"));
                tasks.Add(new TaskData(TaskID.BuildStorageCrate, "Build Storage Crate"));
                tasks.Add(new TaskData(TaskID.MakeFarmingTools, "Make Farming Tools"));
                tasks.Add(new TaskData(TaskID.CraftWaterBucket, "Craft Water Bucket"));
                tasks.Add(new TaskData(TaskID.PrepareBuildingMaterials, "Prepare Building Materials"));
                tasks.Add(new TaskData(TaskID.CraftMedicalSupplies, "Craft Medical Supplies"));
                tasks.Add(new TaskData(TaskID.DeliverSupplies, "Deliver Supplies"));

                break;

            case PlayerRole.Role.Medic:

                tasks.Add(new TaskData(TaskID.GatherMedicinalHerbs, "Gather Medicinal Herbs"));
                tasks.Add(new TaskData(TaskID.CollectCleanWater, "Collect Clean Water"));
                tasks.Add(new TaskData(TaskID.PrepareMedicine, "Prepare Medicine"));
                tasks.Add(new TaskData(TaskID.PrepareBandages, "Prepare Bandages"));
                tasks.Add(new TaskData(TaskID.TreatPatient, "Treat a Patient"));
                tasks.Add(new TaskData(TaskID.DeliverMedicine, "Deliver Medicine"));
                tasks.Add(new TaskData(TaskID.CheckVillagers, "Check Villagers"));
                tasks.Add(new TaskData(TaskID.RestockClinic, "Restock Clinic"));
                tasks.Add(new TaskData(TaskID.PrepareEmergencyKit, "Prepare Emergency Kit"));

                break;
        }

        return tasks;
    }

    // Called by locations when the player performs a task
    public void CompleteTask(TaskID taskID)
    {
        foreach (TaskData task in currentTasks)
        {
            if (task.id == taskID && !task.completed)
            {
                task.completed = true;

                Debug.Log("Completed: " + task.taskName);
                return;
            }
        }

        Debug.Log("Player does not have this task.");
    }

    // Check if player currently has a task
    public bool HasTask(TaskID taskID)
    {
        foreach (TaskData task in currentTasks)
        {
            if (task.id == taskID && !task.completed)
                return true;
        }

        return false;
    }
}