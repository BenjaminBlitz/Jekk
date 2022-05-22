using UnityEngine;

[CreateAssetMenu(fileName = "AttackSpeedItem", menuName = "Invetory/AttackSpeedItem")]
public class AttackSpeedItem : Item
{
    void Awake()
    {
        percentageValue = 1f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.attackSpeed -= 0.05f;
    }
}

