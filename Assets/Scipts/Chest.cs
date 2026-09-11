using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; }
    public string ChestID{ get; private set; }

    public GameObject itemPreFab;
    public Sprite openedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject); //UniqueID
    }

    public bool CanInteract()
    {
        return !IsOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        OpenChest();
    }

    private void OpenChest()
    {
        SetOpened(true);//SetOpened

        //DropItem
        if(itemPreFab)
        {
         
            GameObject droppedItem = Instantiate(itemPreFab, transform.position + Vector3.down, Quaternion.identity);
        }
    }
    
    public void SetOpened(bool opened)
    {
        IsOpened = opened;
        if (IsOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }    
    }
}
