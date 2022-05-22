using UnityEditor;
using UnityEngine;


public class CreateItem : MonoBehaviour
{
    public GameObject item;
    public ArmorItem armor;
    // Start is called before the first frame update
    void Awake()
    {
        armor = new ArmorItem();
        item = (GameObject)Resources.Load("Prefab/Gift", typeof(GameObject));
        item.AddComponent<ItemPickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
