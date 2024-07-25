using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDamageZone : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    private float _damageCooldown = 2.0f;
    private bool _shouldTakeDamage = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            StartCoroutine(DamageDealing(playerHealth));
        }
    }
    private IEnumerator DamageDealing(PlayerHealth playerHealth)
    {
        if (_shouldTakeDamage)
        {
            playerHealth.ChangeHealth(-_damageAmount);
            _shouldTakeDamage = !_shouldTakeDamage;
            yield return new WaitForSeconds(_damageCooldown);
            _shouldTakeDamage = !_shouldTakeDamage;
        }
    }
}
