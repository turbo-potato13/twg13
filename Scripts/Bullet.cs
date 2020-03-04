using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float damage = 25f;
    private float time = 0f;
    private ParticleSystem part;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        part = GetComponent<ParticleSystem>();
    }

    void Start ()
    {
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5f)
            time += Time.deltaTime;
        else
        {
            
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Unit enemy = col.gameObject.GetComponent<Unit>();
        if (enemy != null && enemy.tag != this.tag)
        {
            enemy.health -= damage;
            //part.Play();
            Destroy(gameObject);
           
        }
    }

}
