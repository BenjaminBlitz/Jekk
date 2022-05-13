using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class Playermove : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    Rigidbody m_Rigidbody;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Cursor.visible = false;
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            


            Vector3 targetVelocity = curSpeedX* Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
            Vector3 velocityChange = targetVelocity - m_Rigidbody.velocity;
            m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            /*Vector3 targetAngularVelocity = m_RotationSpeed * transform.up;
            Vector3 angularVelocityChange = targetAngularVelocity - m_Rigidbody.angularVelocity;
            m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);*/

            Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
            Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation, qRotUpright * transform.rotation, Time.fixedDeltaTime * 4);
            m_Rigidbody.MoveRotation(qOrientSlightlyUpright);

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}