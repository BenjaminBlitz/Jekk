using UnityEngine;

[CreateAssetMenu(fileName = "LifeStealItem", menuName = "Invetory/LifeStealItem")]
public class LifeStealItem : Item
{
    void Awake()
    {
        percentageValue = 1f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.lifeSteal += 1;
    }
}
