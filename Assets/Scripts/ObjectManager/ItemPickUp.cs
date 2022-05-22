using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public PlayerManagement player;
    /*private void Start()
    {
        GameObject gift = Resources.Load<GameObject>("Prefab/Gift");
        gift.transform.parent = transform;
        //gift.transform.parent = transform;

        GameObject test = new GameObject();
        test.transform.parent = transform;

    }*/

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

