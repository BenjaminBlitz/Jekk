using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    private DropItem itemDrop;
    [SerializeField] float m_BulletInnitSpeed;
    public GameObject player;
    public GameObject enemy;
    float bulletDamage;
    public static bool hasHit;

    private void Awake()
    {
        bulletRigidbody= GetComponent<Rigidbody>();
        itemDrop = new DropItem();

    }

    private void Start()
    {
        hasHit= false;
        float speed = m_BulletInnitSpeed;
        
        player = GameObject.FindWithTag("Player");
        this.transform.localScale *= player.transform.localScale.x / 5;
        if (player.GetComponent<PlayerManagement>().lvlPlayer>1) speed *= player.transform.localScale.x /5;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");
        hasHit= false;
        //enemy = GameObject.FindWithTag("Mob");
        enemy = other.gameObject;
        PlayerManagement playerManager = player.GetComponent<PlayerManagement>();
        bulletDamage = playerManager.damage * GoCrit(playerManager);

        if (other.CompareTag("Mob"))
        {
            hasHit = true;
            enemy.GetComponent<EnemyManager>().healthPoints -= bulletDamage;
            playerManager.Heal(playerManager.damage, playerManager.lifeSteal);
            if (enemy.GetComponent<EnemyManager>().healthPoints <= 0)
            {
                itemDrop.Create(transform.position);
                playerManager.score += 100;
                Destroy(other.gameObject);
                playerManager.GetExperience(50, playerManager.lvlPlayer);
                EnemyManager.enemiesAlive -= 1;
            }
        }
        if (other.CompareTag("Player")==false)
        {
            Destroy(gameObject);
        }
            
        //Destroy(gameObject);
    }

    private int GoCrit(PlayerManagement player)
    {
        int random = Random.Range(0, 100);
        if(random < player.critic)
        {
            return 2;
        }
        return 1;
    }
}
