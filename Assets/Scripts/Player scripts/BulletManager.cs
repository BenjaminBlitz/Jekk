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
                Destroy(other.gameObject);
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
