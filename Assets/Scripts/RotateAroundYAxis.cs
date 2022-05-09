using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundYAxis : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 40);
            yield return null;
        }
    }
}
