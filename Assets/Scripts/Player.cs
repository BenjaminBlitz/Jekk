using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Mvt Setup")]
    [Tooltip("unit: m/s")]
    [SerializeField] float m_TranslationSpeed;
    [Tooltip("units: °/s")]
    [SerializeField] float m_RotationSpeed;

    Rigidbody m_Rigidbody;

    [Header("Shoot Setup")]
    [SerializeField]GameObject m_BallPrefab;
    [SerializeField]float m_BallInnitSpeed;
    [SerializeField]Transform m_BallSpawnTransform;
    [SerializeField] float m_BallLifeDuration;

    //cooldown
    [SerializeField] float m_CoolDownDuration;
    float m_NextShootTime;



    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        m_NextShootTime = Time.time;
    }
    //comportement Cinématique vs Dynamique (moteur physique physX)

    // Cinematique: Update(), transform



    // Update is called once per frame
    void Update()
    {





        /*
        //les contrôles Axis(classique)     Input System(moderne)
        float vInput = Input.GetAxis("Vertical"); // entre -1 et 1
        float hInput = Input.GetAxis("Horizontal"); // entre -1 et 1

        Vector3 worldMoveVect = vInput * m_TranslationSpeed * Time.deltaTime * transform.forward;
        Vector3 localMoveVect = vInput * m_TranslationSpeed * Time.deltaTime * Vector3.forward;//new Vector3(0,0,1)
        //Vector3 hLocalMoveVect = hInput * m_TranslationSpeed * Time.deltaTime * Vector3.right;
        //transform.position += moveVect;
        transform.Translate(localMoveVect,Space.Self);
        //transform.Translate(localMoveVect,Space.Self);
        
        //ROTATION
        float deltaAngle = hInput * m_RotationSpeed * Time.deltaTime;
        Quaternion qRot = Quaternion.AngleAxis(deltaAngle, transform.up);
        transform.rotation = qRot * transform.rotation;
        //transform.Rotate(hLocalMoveVect,1, Space.World);
        // Hardware        Axis         Actions
        */

    }

    void ShootBall()
    {

        GameObject newBallGO=Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnTransform.position;
        Rigidbody rb = newBallGO.GetComponent<Rigidbody>();
        rb.velocity = m_BallSpawnTransform.forward * m_BallInnitSpeed;

        Destroy(newBallGO, m_BallLifeDuration);
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying)
        {
            return;
        }

        //Dynamique
        float vInput = Input.GetAxis("Vertical"); // entre -1 et 1
        float hInput = Input.GetAxisRaw("Horizontal"); // entre -1 et 1
        /*
        //MODE POSITIONNEL
        //pseudo dynamique (on se tp, comme en cinématique)     +     proche d'un cprtment cinématique
        //nous permet de prendre en compte les collisions
        //Moveposition et MoveRotation
        Vector3 worldMoveVect = vInput * m_TranslationSpeed * Time.fixedDeltaTime * Vector3.ProjectOnPlane(transform.forward,Vector3.up).normalized;
        m_Rigidbody.MovePosition(transform.position + worldMoveVect);

        Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation,qRotUpright * transform.rotation,Time.fixedDeltaTime * 4);

        float deltaAngle = hInput * m_RotationSpeed * Time.fixedDeltaTime;
        Quaternion qRot = Quaternion.AngleAxis(deltaAngle, transform.up);
        m_Rigidbody.MoveRotation(qRot*qOrientSlightlyUpright);

        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        */

        /* MODE VELOCITY */
        Vector3 targetVelocity = vInput * m_TranslationSpeed * Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Vector3 velocityChange = targetVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 targetAngularVelocity = hInput * m_RotationSpeed * transform.up;
        Vector3 angularVelocityChange = targetAngularVelocity - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);

        Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation, qRotUpright * transform.rotation, Time.fixedDeltaTime * 4);
        m_Rigidbody.MoveRotation(qOrientSlightlyUpright);

        /* MODE ACCELERATION 
        Vector3 acceleration = vInput * Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * 3;
        m_Rigidbody.AddForce(acceleration, ForceMode.Acceleration);
        Vector3 angularAcceleration = hInput * transform.up * 10;
        m_Rigidbody.AddTorque(angularAcceleration, ForceMode.Acceleration);

        Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation, qRotUpright * transform.rotation, Time.fixedDeltaTime * 4);
        m_Rigidbody.MoveRotation(qOrientSlightlyUpright); */

        /* MODE FORCE PURE 
        Vector3 force = vInput * Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * 10;
        m_Rigidbody.AddForce(force, ForceMode.Force);
        Vector3 torque = hInput * transform.up * 2;
        m_Rigidbody.AddTorque(torque, ForceMode.Force);

        Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation, qRotUpright * transform.rotation, Time.fixedDeltaTime * 6);
        m_Rigidbody.MoveRotation(qOrientSlightlyUpright);*/

        // SHOOT
        bool isFiring = Input.GetButton("Fire1");
        if (isFiring && Time.time > m_NextShootTime)
        {
            ShootBall();
            m_NextShootTime = Time.time + m_CoolDownDuration;
        }


    }


}
