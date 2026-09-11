using UnityEngine;

public class NPCMessage : MonoBehaviour
{
    public GameObject messageBox;

    public void ShowMessage()
    {
        messageBox.SetActive(true);
    }

    public void HideMessage()
    {
        messageBox.SetActive(false);
    }
}