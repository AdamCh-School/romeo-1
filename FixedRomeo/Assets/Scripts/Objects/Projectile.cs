﻿using UnityEngine;
using System.Collections;

// code refactored by DW from a Unity asset store package

public class Projectile : MonoBehaviour
{
    public int damageModifier;
    public float bigBlastLifespan = .3f;
    public GameObject explosionPrefab;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damageModifier);
            OnExplode();
            if (damageModifier < 3) Destroy(gameObject);
            else Invoke("DestroyBigBlast", bigBlastLifespan);
        }
        else if (other.gameObject.tag != "Player")
        {
            OnExplode();
            if (damageModifier < 3) Destroy(gameObject);
            else Invoke("DestroyBigBlast", bigBlastLifespan);
        }
    }

    void DestroyBigBlast()
    {
        Destroy(gameObject);
    }

    void OnExplode()
    {
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        Instantiate(explosionPrefab, transform.position, randomRotation);
    }
}
