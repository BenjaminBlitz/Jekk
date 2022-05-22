using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   
    
    [SerializeField] public float healthPoints;
    public GameObject player;
    public GameObject enemySpawner;
    public static int enemiesAlive = 0;
    int lvlMob = 1; 
    float damages = 20;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        lvlMob = player.GetComponent<PlayerManagement>().lvlPlayer;
        enemySpawner = GetComponent<SpawnerEnemies>();

        if (lvlMob > 1)
        {
            healthPoints = (lvlMob * (healthPoints / 2.5f));
            damages += (lvlMob * 10);
        }
        for (int i = 0; i < lvlMob+1; i++)
        {
            Growth();
        }
    }
    void Growth()
    {
        if (lvlMob == 5)
        {
            this.transform.localScale *= 5.8f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.7f))*2;
        }
        if (lvlMob == 10)
        {
            this.transform.localScale *= 5.8f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.7f))*3;
        }
        if (lvlMob == 15)
        {
            this.transform.localScale *= 5.8f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.7f))*4;
        }
        if (lvlMob == 20)
        {
            this.transform.localScale *= 5.8f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.7f))*5;
        }
        this.GetComponent<EnemyMover>().Movespeed *= this.transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(enemiesAlive == 0)
        {
            SpawnerEnemies.enemmyCount += 1;
            enemySpawner.Spawning();
        }

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
