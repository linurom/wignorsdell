using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine.Animations;
using UnityEngine;


public abstract class BasePlayer : MonoBehaviour, IControllable
{
    public float power;
    public float beginPower;
    public int level;
    public float maxHealth;
    public float health;
    public float XP;
    public float speed;
    public Vector2 direction;
    public float maxXP;
    public Joystick joystick;
    private bool isFlipped;
    private SpriteRenderer SR;
    private Rigidbody2D rb;
    private Animator anim;
    public BaseWeapon[] weapons;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (SystemInfo.deviceType != DeviceType.Handheld)
        {
            joystick.gameObject.SetActive(false);
        }
        power = beginPower;
        health = maxHealth;
    }

    private void OnEnable()
    {
        EventBus.OnEnemyGenerated += RemovePower;
        EventBus.OnEnemyKilled += AddXP;
    }

    private void OnDisable()
    {
        EventBus.OnEnemyGenerated -= RemovePower;
        EventBus.OnEnemyKilled -= AddXP;
    }

    private void RemovePower(float power)
    {
        this.power -= power;
    }

    public void Move()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        else
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }
        rb.velocity = direction * (speed * 10) * Time.fixedDeltaTime;
        if (direction.x == 0 && direction.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
        if (direction.x < 0 && isFlipped == false)
        {
            Flip();
        }
        if (direction.x > 0 && isFlipped == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        if (isFlipped == false)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
        isFlipped = !isFlipped;

    }

    public void ResetPlayerPower()
    {
        power = beginPower;
    }

    public void AddXP(float amount)
    {
        XP += amount;
    }

    public void RemoveXP(float amount)
    {
        XP -= amount;
    }

    public void CalculatePower()
    {
        power = level * (power + speed) / 2;
    }

    public virtual void UpdateLevel()
    {
        if (XP >= maxXP)
        {
            level++;
            weapons[0].damage *= 1.5f;
            speed *= 1.5f;
            maxXP *= 2;
            CalculatePower();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        EventBus.OnPlayerTackesDamage(health);
        if (health <= 0)
        {
            EventBus.OnPlayerDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}