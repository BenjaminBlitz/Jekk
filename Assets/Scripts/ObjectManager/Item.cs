using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Invetory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null; 
}
