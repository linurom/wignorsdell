using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public abstract class BaseWeapon : MonoBehaviour, IAtackable
{
    [SerializeField] private BaseBullets Bullet;
    [SerializeField] private float offset;
    public float damage;
    [SerializeField] private GameObject weaponController;
    [SerializeField] private float timeBTWShots;
    [SerializeField] private float radius;
    public Collider2D[] col;
    public Collider2D target;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject muzzle;

    private void Start()
    {
        StartCoroutine("DetectTarget");
    }


    public IEnumerator DetectTarget()
    {
        while (true)
        {
            col = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (Collider2D go in col)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    target = go;
                    distance = curDistance;
                }
            }
            if (target != null)
            {
                Atack();
            }
            yield return new WaitForSeconds(timeBTWShots);
        }
    }

    private void Update()
    {
        FaceToTarget();
    }

    public void FaceToTarget()
    {
        if (target != null)
        {
            weaponController.transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        }
    }

    public virtual void Atack()
    {
        var obj = Instantiate(Bullet, muzzle.transform.position, muzzle.transform.rotation);
        obj.damage += damage;
    }
}
