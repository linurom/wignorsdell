using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BaseEnemy
{
    GameObject target;
    public int coolDown;
    private bool isStopped;

    private void Start()
    {
        target = FindTarget("Player");
    }


    private void FixedUpdate()
    {
        if (target != null)
        {
            if (isStopped == false)
            {
                Follow(target.transform);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isStopped = true;
            StartCoroutine("Timer");
            collision.gameObject.GetComponent<BasePlayer>().TakeDamage(damage);
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(coolDown);
        isStopped = false;
    }
}
