using UnityEditor;
using UnityEngine;


public class DropItem : MonoBehaviour
{

    private void Start()
    {

    }
    public void Create(Vector3 transform)
    {
        GameObject lootItem = new GameObject();
        int random = Random.Range(0, 100);
        if (random <= 20)
        {
            int randomItem = Random.Range(0, 100);
            if (randomItem <= 30)
            {
                lootItem = GameObject.Find("ArmorItem");
            }
            else if (randomItem > 30 && randomItem <= 60)
            {
                lootItem = GameObject.Find("DamageItem");
            }
            else if (randomItem > 60 && randomItem <= 80)
            {
                lootItem = GameObject.Find("AttackSpeedItem");
            }
            else if (randomItem > 80 && randomItem <= 90)
            {
                lootItem = GameObject.Find("LifeStealItem");
            }
            else if (randomItem > 90 && randomItem <= 100)
            {
                lootItem = GameObject.Find("LifeStealItem");
            }

            Instantiate(lootItem, transform, Quaternion.identity);
        }

    }
}
