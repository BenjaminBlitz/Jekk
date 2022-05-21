using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItem", menuName = "Invetory/ArmorItem")]
public class ArmorItem : Item
{
    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.currentHealth += 50;
    }
}
