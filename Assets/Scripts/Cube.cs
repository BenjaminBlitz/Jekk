using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour , IColorize
{
    Rigidbody m_RigidBody;
    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //m_RigidBody.MoveRotation(Quaternion.AngleAxis(10 * Time.fixedDeltaTime, Vector3.up) * transform.rotation);
    }

    public void RecolorizeRandom()
    {
        Tools.SetRandomColor(gameObject);
    }
}
