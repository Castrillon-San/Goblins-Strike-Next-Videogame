using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    public Transform target;
    public float range = 2.5f;
    public Transform canon;

    private float fireRate = 1f;
    private float fireCountdown = 0f;
    public Transform FirePoint;
    public GameObject ballPrefab;
    private GameObject enemyNear;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemie");
        float shortDist = Mathf.Infinity;
        enemyNear = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distToEnemy<shortDist)
            {
                shortDist = distToEnemy;
                enemyNear = enemy;
            }
        }

        if(enemyNear!= null && shortDist<=range)
        {
            target = enemyNear.transform;
        }
        else
        {
            target = null;
        }

    }


    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(canon.rotation, lookRotation, Time.deltaTime * 20f).eulerAngles;
         canon.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if (fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO =(GameObject)Instantiate(ballPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet!=null)
        {

            bullet.seek(target,enemyNear);
        }
        Debug.Log("SHOOT!");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
