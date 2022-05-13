using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouger : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] float m_Speed;
    [SerializeField] float jumpSpeed;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            m_Rigidbody.velocity += jumpSpeed * Vector3.up;
            //m_Rigidbody.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
        }
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

        
    }
}

