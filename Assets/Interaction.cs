using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool playerNearby = false;

    private void Start()
    {
        Debug.Log("Interaction script is working!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Player is near the object!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            Debug.Log("Player left the object!");
        }
    }
}