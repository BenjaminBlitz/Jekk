using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_TPSController : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 2.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public static bool isMoving;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;



    Vector3 velocity;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        isMoving = false;
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        isMoving = false;
        if (MenuPause.GamePaused)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }


        /*

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? speed * transform.localScale.x * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * transform.localScale.x * Input.GetAxis("Horizontal") : 0;
        Vector3 targetVelocity = curSpeedX * Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Vector3 targetVelocity2 = curSpeedY * Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized;
        //moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        */
        //jump


        if (characterController.isGrounded)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -1 * gravity);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCameraParent.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * transform.localScale.x * speed * Time.deltaTime);
            isMoving = true;
        }

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed * Mathf.Pow(transform.localScale.x, 0.88f) * 1.05f;
        }


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * transform.localScale.x * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            //playerCameraParent.localPosition = new Vector3(-(Mathf.Atan(transform.localScale.x)*Mathf.Rad2Deg - Mathf.Atan(2.1134f) * Mathf.Rad2Deg) /110, playerCameraParent.localPosition.y, -(Mathf.Atan(transform.localScale.x) * Mathf.Rad2Deg - Mathf.Atan(2.1134f) * Mathf.Rad2Deg) / 17);
            playerCameraParent.localPosition = new Vector3(playerCameraParent.localPosition.x, (Mathf.Atan(transform.localScale.x) * Mathf.Rad2Deg + 150) / 151.6f, -(Mathf.Atan(transform.localScale.x) * Mathf.Rad2Deg - Mathf.Atan(2.113485f) * Mathf.Rad2Deg) / 17);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}