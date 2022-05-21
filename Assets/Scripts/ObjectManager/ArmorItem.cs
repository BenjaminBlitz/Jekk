using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItem", menuName = "Invetory/ArmorItem")]
public class ArmorItem : Item
{
    void Awake()
    {
        percentageValue = 1f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.armor += 1;
    }
}
