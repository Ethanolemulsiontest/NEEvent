using TMPro;
using UnityEngine;

public class PlayerTaskUI : MonoBehaviour
{
    [Header("Player")]
    public PlayerRole playerRole;
    public PlayerTasks playerTasks;

    [Header("UI")]
    public TMP_Text roleText;
    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public TMP_Text task3Text;

    private void Start()
    {
        // Wait until the end of Start before displaying
        Invoke(nameof(UpdateUI), 0.1f);
    }

    public void UpdateUI()
    {
        if (playerRole == null || playerTasks == null)
        {
            Debug.LogError("PlayerRole or PlayerTasks is not assigned!");
            return;
        }

        if (roleText == null || task1Text == null ||
            task2Text == null || task3Text == null)
        {
            Debug.LogError("One or more UI Text objects are not assigned!");
            return;
        }

        roleText.text = GetRoleDisplayName();

        if (playerTasks.currentTasks.Count >= 3)
        {
            task1Text.text = "- " + playerTasks.currentTasks[0];
            task2Text.text = "- " + playerTasks.currentTasks[1];
            task3Text.text = "- " + playerTasks.currentTasks[2];

            Debug.Log("Task UI updated successfully!");
        }
        else
        {
            Debug.LogError(
                "UI cannot display tasks. Current task count: " +
                playerTasks.currentTasks.Count
            );
        }
    }

    private string GetRoleDisplayName()
    {
        switch (playerRole.currentRole)
        {
            case PlayerRole.Role.FoodGatherer:
                return "FOOD GATHERER";

            case PlayerRole.Role.Craftsman:
                return "CRAFTSMAN";

            case PlayerRole.Role.Medic:
                return "MEDIC";

            default:
                return "UNKNOWN";
        }
    }
}