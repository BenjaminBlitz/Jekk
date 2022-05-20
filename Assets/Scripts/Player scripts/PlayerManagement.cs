using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManagement : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int currentExp;
    public int lvlUpExp = 400;
    private Vector3 scaleChange = new Vector3(2,2,2);

    public Inventory inventory;

    Dictionary<int, int> lvlManager = new Dictionary<int, int>();

    public int lvlPlayer = 1;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;
    public bool canShoot = true;


    [Header("Shoot Setup")]
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] float m_BulletInnitSpeed;
    [SerializeField] Transform m_BulletSpawnTransform;
    [SerializeField] float m_BulletLifeDuration;

    //cooldown
    [SerializeField] float m_CoolDownDuration;
    float m_NextShootTime;

    void Start()
    {
        currentHealth = maxHealth;
        currentExp = 0;

        CreateLvlManager();
        experienceBar.SetExp(currentExp);
        experienceBar.SetLvlText(lvlPlayer);
        

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealthText(maxHealth, maxHealth);
        m_NextShootTime = Time.time;
    }

   

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBar.SetHealthText(currentHealth, maxHealth);
    }

    void GetExperience(int experience, int lvlplay)
    {
        currentExp += experience;
        experienceBar.SetMaxExp(lvlManager[lvlplay]);
        if (currentExp >= lvlManager[lvlplay])
        {
            currentExp = 0;
            lvlPlayer += 1;
            Growth();
        }
        experienceBar.SetExp(currentExp);
        experienceBar.SetLvlText(lvlPlayer);
    }

    void CreateLvlManager()
    {
        for (int i = 0; i <= 50; i++)
        {
            lvlUpExp = lvlUpExp + 100;
            lvlManager.Add(i, lvlUpExp);
        }
    }

    void ShootBullet()
    {
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        GameObject newBulletGO = Instantiate(m_BulletPrefab);
        newBulletGO.transform.position = m_BulletSpawnTransform.position;
        Rigidbody rb = newBulletGO.GetComponent<Rigidbody>();
        rb.velocity = m_BulletSpawnTransform.forward * m_BulletInnitSpeed;

        Destroy(newBulletGO, m_BulletLifeDuration);
    }
    void Shoot()
    {
        Vector3 aimPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPos.z = 0;

        //Creating the bullet and shooting it
        var pel = Instantiate(m_BulletPrefab, m_BulletSpawnTransform.position, m_BulletSpawnTransform.rotation);
        pel.GetComponent<Rigidbody2D>().AddForce(aimPos.normalized * 8000f);
        //Playing the bullet noise
        //Shot.Play();
        //shooting and reloading
        //usingBulletPerMag -= 1;

        

    }

    void Growth()
    {
        this.transform.localScale += scaleChange;
    }


    void Update()
    {
        if (MenuPause.GamePaused)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            GetExperience(20, lvlPlayer);
        }
        // SHOOT
        bool isFiring = Input.GetButton("Fire1");
        if (isFiring && Time.time > m_NextShootTime && canShoot)
        {
            ShootBullet();
            m_NextShootTime = Time.time + m_CoolDownDuration;
        }
        // SHOOT2
        /*
        if (isFiring && Time.time > m_NextShootTime)
        {

            GameObject shot = GameObject.Instantiate(m_BulletPrefab, transform.position, transform.rotation);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //shootingAudio.PlayOneShot(shootingSound, 1.0f);
            Vector3 dir;

            if (Physics.Raycast(ray, out RaycastHit hit, 30f))
            {
                dir = hit.point - transform.position;
                shot.GetComponent<Rigidbody>().AddForce(dir * m_BulletInnitSpeed, ForceMode.Impulse);
            }

        }*/
    }

}