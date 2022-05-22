using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Vector3 pos;
    public int lvl;
    int enemmyCount;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lvl = player.GetComponent<PlayerManagement>().lvlPlayer;
        pos = new Vector3(135, 6.4f, 10013);
        enemmyCount = 2;
        Spawning();
    }

    IEnumerator InstantiateEnemies()
    {
        enemmyCount += 1;
        for (int i = 0; i < enemmyCount; i++)
        {
            Instantiate(enemy, pos, Quaternion.identity);
            EnemyManager.enemiesAlive += 1;
            yield return new WaitForSeconds(3);
        }
    }

    public void Spawning()
    {
        print("coucou");
        StartCoroutine(InstantiateEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
