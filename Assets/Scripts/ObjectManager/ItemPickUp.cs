using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public PlayerManagement player;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.itemName);
        item.ChangePlayerStats(player);
        InventoryDisplay.instance.Add(item, player);
        Destroy(gameObject);
    }


}

