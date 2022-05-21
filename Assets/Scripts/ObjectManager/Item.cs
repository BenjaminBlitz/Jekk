using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Invetory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public int baseValue;
    public int percentageValue;
    public Sprite icon = null; 

    public virtual void ChangePlayerStats(PlayerManagement player)
    {
        return;
    }
}
