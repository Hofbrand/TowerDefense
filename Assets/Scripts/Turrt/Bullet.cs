﻿using Assets.Scripts.Infrastructure.EnemyLogic;
using Assets.Scripts.Turrt;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        //what happens in this method?

        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        if(explosionRadius > 0f)
        {
            Explode();

        }else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
       Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        HP e = enemy.GetComponent<HP>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
