using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public float speed;
    public float price;
    public float health;

    private float maxHealth;
    private Weapon m_weapon;
    private ParticleSystem partSyst;
    private Image healthStatus;
    private float lastHealth;
    
    private float PlusPos;

    public Unit(float Speed, float Health, Weapon M_weapon)
    {
        speed = Speed;
        health = Health;
        m_weapon = M_weapon;
    }

    void Awake()
    {
        m_weapon = GetComponent<Weapon>();
        m_weapon.FirePoint = transform.GetChild(0);
        m_weapon.Range += (float)Random.Range(0, 200) / 100f;
        partSyst = GetComponent<ParticleSystem>();
        maxHealth = health;
        lastHealth = health;
        PlusPos = Random.Range(-1f , 1f);
        if(transform.tag== "Our")
            gameManager.Units += 1;
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.gameObject.name == "HealthBar")
                healthStatus = child.gameObject.GetComponent<Image>();
               
        }
    }

   
    void Start()
    {
        
    }

    void CheckWin()
    {
        if(transform.position.x > 14)
        {
            gameManager.score += price;
            Destroy(gameObject);
        }
        if(transform.position.x < -14)
        {
            gameManager.score -= price;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        HealthBarUpdate();
        state_check();
    }


    private void HealthBarUpdate()
    {
        if (lastHealth != health)
        {
            partSyst.Stop();
            partSyst.Clear();

            partSyst.Play();
            lastHealth = health;
        }
        healthStatus.fillAmount = health / maxHealth;
    }

    private void state_check()
    {
        if (health <= 0)
            Destroy(gameObject);
        if (enemy_finder() <= m_weapon.Range && m_weapon.IsRange)
        {
            if (nearestEnemy)
                Shoot(nearestEnemy);
        }
        else if (enemy_finder() <= m_weapon.Range && !m_weapon.IsRange)
        {
            if (nearestEnemy)
                Attack(nearestEnemy);
        }
        else move();

    }

    void OnDestroy()
    {
        if (transform.tag == "Our")

        {
            gameManager.Units -= 1;
        }
        
    }

    GameObject nearestEnemy = null;
    private float enemy_finder()
    {
        GameObject[] enemies = null;
        float distanceNear = Mathf.Infinity;
        if (this.tag == "Our")
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        else if (this.tag == "Enemy")
            enemies = GameObject.FindGameObjectsWithTag("Our");
        foreach (GameObject enemy in enemies)
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);
        
            if (currDistance < distanceNear && m_weapon.Range >= currDistance && enemy.GetComponent<Rigidbody2D>() == null)
            {
                nearestEnemy = enemy;
                distanceNear = currDistance;
            }
        }
        return distanceNear;
    }


    float time = 0;
    private void Shoot(GameObject enemy)
    {
   
        if (time <= m_weapon.AttackRate)
        {
            time += Time.deltaTime;
        }
        else
        {
            GameObject bulll = Instantiate(m_weapon.BulletPrefab, m_weapon.FirePoint.position, m_weapon.FirePoint.rotation);
            bulll.tag = this.tag;
            time = 0;
        }
    }

    private void Attack(GameObject enemy)
    {
        if(time <= m_weapon.AttackRate)
        {
            time += Time.deltaTime;
        }
        else
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(new Vector2(m_weapon.FirePoint.position.x, m_weapon.FirePoint.position.y), m_weapon.Range);
            foreach (Collider2D ene in enemiesToDamage)
            {
                if(ene)
                    ene.gameObject.GetComponent<Unit>().health -= m_weapon.Damage;
            }
            time = 0;
        }
    }
   

    private void move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
    }
}
