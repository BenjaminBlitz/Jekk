using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public int maxHealth = 1000;
    public float currentHealth;
    public int currentExp;
    public int damage;
    public float armor;
    public float critic;
    public float lifeSteal;
    public int score; 
    public static bool lvlUp;
    [SerializeField] public float attackSpeed;
    public int lvlUpExp = 400;
    private Vector3 scaleChange = new Vector3(2,2,2);

    public Inventory inventory;

    Dictionary<int, int> lvlManager = new Dictionary<int, int>();

    public int lvlPlayer = 1;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;
    public bool canShoot = true;
    public static bool hasFired;
    public GameObject player;

    [Header("Shoot Setup")]
    //[SerializeField] GameObject m_BulletPrefab;
    //[SerializeField] float m_BulletInnitSpeed;
    [SerializeField] Transform m_BulletSpawnTransform;
    [SerializeField] float m_BulletLifeDuration;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;

    //cooldown
    float m_NextShootTime;

    void Start()
    {
        lvlUp = false;
        hasFired = false;
        currentHealth = maxHealth;
        currentExp = 0;
        score = 0;
        

        CreateLvlManager();
        experienceBar.SetExp(currentExp);
        experienceBar.SetLvlText(lvlPlayer);
        

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealthText(maxHealth, maxHealth);
        attackSpeed = 1.5f;
        lifeSteal = 10;
        m_NextShootTime = Time.time;
        /*player = GameObject.FindWithTag("Player");
        pfBulletProjectile.localScale *= player.transform.localScale.x/5;*/
    }

   

    public void TakeDamage(float damage)
    {
        currentHealth -= damage * 1/(0.05f*armor + 1);
        healthBar.SetHealth(currentHealth);
        healthBar.SetHealthText(currentHealth, maxHealth);
    }

    public void Heal(float damage, float lifeSteal)
    {
        float healVar = currentHealth;
        healVar += damage * (lifeSteal/100);
        if (healVar >= maxHealth) return;
        currentHealth += damage * (lifeSteal / 100);
        healthBar.SetHealth(currentHealth);
        healthBar.SetHealthText(currentHealth, maxHealth);
    }

    public void GetExperience(int experience, int lvlplay)
    {
        currentExp += experience;
        experienceBar.SetMaxExp(lvlManager[lvlplay]);
        if (currentExp >= lvlManager[lvlplay])
        {
            currentExp = 0;
            lvlPlayer += 1;
            lvlUp = true;
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

    /*
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
    */
    void Growth()
    {
        if (lvlPlayer <= 20)
        {
            if (lvlPlayer % 5 == 0)
            {
                this.transform.localScale *= 5.8f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.7f));
            }
            else
            {
                this.transform.localScale *= 1.28f / (this.transform.localScale.x / Mathf.Pow(this.transform.localScale.x, 0.97f));
            }
        }
    }


    void Update()
    {
        hasFired = false;
        lvlUp = false;
        if (MenuPause.GamePaused)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }

        if (currentHealth < 0)
        {
            GameOverMenu.isDead = true;
        }

        if (lvlPlayer >= 25)
        {
            GameOverMenu.hasWon = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            GetExperience(200, lvlPlayer);
        }
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 10000f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }






        // SHOOT
        bool isFiring = Input.GetButton("Fire1");
        if (isFiring && Time.time > m_NextShootTime && canShoot)
        {
            //ShootBullet();
            Vector3 aimDir = (mouseWorldPosition - m_BulletSpawnTransform.position).normalized;
            Instantiate(pfBulletProjectile, m_BulletSpawnTransform.position, Quaternion.LookRotation(aimDir, Vector3.up));
            m_NextShootTime = Time.time + attackSpeed;
            hasFired = true;
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
