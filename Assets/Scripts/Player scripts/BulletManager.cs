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
    public float bulletDamage;
    private void Awake()
    {
        bulletRigidbody= GetComponent<Rigidbody>();
        itemDrop = new DropItem();

    }

    private void Start()
    {
        float speed = m_BulletInnitSpeed;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Mob");
        bulletDamage = player.GetComponent<PlayerManagement>().damage;
        if (other.CompareTag("Mob"))
        {
            enemy.GetComponent<EnemyManager>().healthPoints -= bulletDamage;
            if (enemy.GetComponent<EnemyManager>().healthPoints <= 0)
            {
                Destroy(other.gameObject);
                itemDrop.Create(transform.position);
            }
        }
        Destroy(gameObject);
    }
}
