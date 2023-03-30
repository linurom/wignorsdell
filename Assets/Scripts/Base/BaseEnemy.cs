using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    [Header("base class")]
    public int money;
    public int XP;
    public Rigidbody2D rb;
    public Transform transformCashed;
    public bool isFlipped = false;
    public float power;
    public float health;
    public float damage;
    public float speed;
    public GameObject Effect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transformCashed = rb.GetComponent<Transform>();
        EventBus.OnEnemyGenerated?.Invoke(power);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BaseMoney.AddCoins(money);
            EventBus.OnEnemyKilled?.Invoke(XP);
            GenerateEnemys.enemysCount--;
            Instantiate(Effect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }

    public GameObject FindTarget(string tag)
    {
        GameObject target = GameObject.FindGameObjectWithTag(tag);
        transformCashed = rb.GetComponent<Transform>();
        return target;
    }

    public void Follow(Transform target)
    {
        transform.position = Vector2.MoveTowards(transformCashed.position, target.position, speed * Time.fixedDeltaTime);
        if (transformCashed.position.x - target.transform.position.x < 0 && isFlipped == true)
        {
            Flip();
        }
        else if (transformCashed.position.x - target.transform.position.x > 0 && isFlipped == false)
        {
            Flip();

        }
    }

    void Flip()
    {
        isFlipped = !isFlipped;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
