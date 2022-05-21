using UnityEngine;

[CreateAssetMenu(fileName = "CriticItem", menuName = "Invetory/Critic")]
public class CriticItem : Item
{
    void Awake()
    {
        percentageValue = 2f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.critic += 1;
    }
}
