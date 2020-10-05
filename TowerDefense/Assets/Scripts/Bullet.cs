using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    private float speed=7.8f;
    private GameObject enemyTargeted;

    public void seek(Transform _Target, GameObject EneTargeted)
    {
        target = _Target;
        enemyTargeted = EneTargeted;
    }

    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        Enemylive eneLive = enemyTargeted.GetComponent<Enemylive>();
        eneLive.GetDamage(3);
    }
}
