using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public float healthPoints;
    public GameObject player;
    public float damages;
    // Start is called before the first frame update
    void Start()
    {
        damages = 20;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
    private void OnTriggerEnter(Collider other)
    {

        player = GameObject.FindWithTag("Player");
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
