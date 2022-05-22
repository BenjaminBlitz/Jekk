using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    private void Awake()
    {
        bulletRigidbody= GetComponent<Rigidbody>();

    }
    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
