using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{

    public Image LifeSteal;
    public TextMeshProUGUI LifeStealTxt;
    public int stackLife;
    public Image Armor;
    public TextMeshProUGUI ArmorTxt;
    public int stackArmor;
    public Image Damage;
    public TextMeshProUGUI DamageTxt;
    public int stackDamage;
    public Image AttackSpeed;
    public TextMeshProUGUI AttackSpTxt;
    public int stackAttackSpeed;
    public Image Critic;
    public TextMeshProUGUI CriticTxt;
    public int stackCritic;

    #region Singleton
    public static InventoryDisplay instance;

    void Awake()
    {
        LifeSteal.enabled = false;
        LifeStealTxt.text = "x"+ stackLife.ToString();
        LifeStealTxt.enabled = false;
        Armor.enabled = false;
        ArmorTxt.enabled = false;
        ArmorTxt.text = "x" + stackArmor.ToString();
        ArmorTxt.enabled = false;
        Damage.enabled = false;
        DamageTxt.text = "x" + stackDamage.ToString();
        DamageTxt.enabled = false;
        AttackSpeed.enabled = false;
        AttackSpTxt.text = "x" + stackAttackSpeed.ToString();
        AttackSpTxt.enabled = false;
        Critic.enabled = false;
        CriticTxt.text = "x" + stackCritic.ToString();
        CriticTxt.enabled = false;

        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        switch (item.itemName)
        {
            case "LifeStealItem":
                stackLife += 1;
                ShowLifeItem();
                break;
            case "ArmorItem":
                stackArmor += 1;
                ShowArmorItem();
                break;
            case "DamageItem":
                stackDamage += 1;
                ShowDamageItem();
                break;
            case "AttackSpeedItem":
                stackAttackSpeed += 1;
                ShowAttackSpeedItem();
                break;
            case "CriticItem":
                stackCritic += 1;
                ShowCriticItem();
                break;

        }
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    void Update()
    {
        LifeStealTxt.text = "x" + stackLife.ToString();
        ArmorTxt.text = "x" + stackArmor.ToString();
        DamageTxt.text = "x" + stackDamage.ToString();
        AttackSpTxt.text = "x" + stackAttackSpeed.ToString();
        CriticTxt.text = "x" + stackCritic.ToString();
    }

    public void ShowLifeItem()
    {
        LifeSteal.enabled = true;
        LifeStealTxt.enabled = true;
    }

    public void ShowArmorItem()
    {
        Armor.enabled = true;
        ArmorTxt.enabled = true;
    }

    public void ShowDamageItem()
    {
        Damage.enabled = true;
        DamageTxt.enabled = true;
    }

    public void ShowAttackSpeedItem()
    {
        AttackSpeed.enabled = true;
        AttackSpTxt.enabled = true;
    }

    public void ShowCriticItem()
    {
        Critic.enabled = true;
        CriticTxt.enabled = true;
    }
}
