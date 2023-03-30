using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BaseBullets : MonoBehaviour
{
    public GameObject SpellExplode;
    public float speed;
    public float damage;
    [SerializeField] private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeDamage(this.damage);
            Instantiate(SpellExplode, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine("TimerBeforeDestroy");
    }


    private void Update()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = transform.right * speed;
    }

    public IEnumerator TimerBeforeDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
