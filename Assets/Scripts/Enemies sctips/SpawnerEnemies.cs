using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 pos;
    public static int enemmyCount;

    void Start()
    {
        pos = new Vector3(135, 6.4f, 10013);
        enemmyCount = 3;
        Spawning();
    }

    IEnumerator InstantiateEnemies()
    {
        for (int i = 0; i < enemmyCount; i++)
        {
            Instantiate(enemy, pos, Quaternion.identity);
            EnemyManager.enemiesAlive += 1;
            yield return new WaitForSeconds(3);
        }
    }

    public void Spawning()
    {
        StartCoroutine(InstantiateEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
