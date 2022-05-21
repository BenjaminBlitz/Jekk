using UnityEngine;
using TMPro;

public class StatsPlayer : MonoBehaviour
{
    public PlayerManagement player;

    public TextMeshProUGUI damage;
    public TextMeshProUGUI critic;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI attackSpeed;

    void Update()
    {
        int newPlayerDamage = (int)player.damage;
        int newPlayerArmor = (int)player.armor;
        int newPlayerCritic = (int)player.critic;
        int newPlayerAttackSpeed = (int)player.attackSpeed;
        damage.text = "Damage : " + newPlayerDamage.ToString();
        critic.text = "Critic : " + newPlayerCritic.ToString();
        armor.text = "Armor : " + newPlayerArmor.ToString();
        attackSpeed.text = "AttackSpeed : " + newPlayerAttackSpeed.ToString();
    }
}
