using UnityEngine;

[CreateAssetMenu(fileName = "ArmorItem", menuName = "Invetory/ArmorItem")]
public class ArmorItem : Item
{
    void Start()
    {
        percentageValue = 30f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.armor += player.armor * percentageValue/100;
    }
}
