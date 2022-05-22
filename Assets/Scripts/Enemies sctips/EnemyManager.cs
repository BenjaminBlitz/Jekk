using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   
    
    [SerializeField] public float healthPoints;
    public GameObject player;
    public static int enemiesAlive = 0;
    int lvlMob = 1; 
    float damages = 20;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        lvlMob = player.GetComponent<PlayerManagement>().lvlPlayer;
        if (lvlMob > 1)
        {
            healthPoints = (lvlMob * (healthPoints / 2.5f));
            damages += (lvlMob * 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerManagement>().currentHealth -= damages;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        player = GameObject.FindWithTag("Player");

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerManagement>().TakeDamage(damages);
            //player.GetComponent<PlayerManagement>().currentHealth -= damages;
        }

    }

}
