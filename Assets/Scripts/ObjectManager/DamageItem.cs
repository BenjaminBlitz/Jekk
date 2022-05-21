using UnityEngine;

[CreateAssetMenu(fileName = "DamageItem", menuName = "Invetory/Damage")]
public class DamageItem : Item
{
    void Awake()
    {
        percentageValue = 2f;
    }

    public override void ChangePlayerStats(PlayerManagement player)
    {
        player.damage += (int)(player.damage * percentageValue / 100);
    }
}
