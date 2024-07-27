using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDamageZone : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damageAmount);
        }
    }
}
