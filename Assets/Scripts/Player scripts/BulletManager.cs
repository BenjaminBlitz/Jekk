using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    private DropItem itemDrop;
    [SerializeField] float m_BulletInnitSpeed;
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
        if (other.CompareTag("Mob"))
        {
            Destroy(other.gameObject);
            itemDrop.Create(transform.position);
        }
        Destroy(gameObject);
    }
}
