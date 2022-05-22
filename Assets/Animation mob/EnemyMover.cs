using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float Movespeed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform);
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        transform.position += transform.forward * Movespeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position,new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z),Movespeed);
        transform.Rotate(1, 270, 1);
    }
}
