using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   // public static event Action<int> OnHealthChanged;
    private int _maxHealth = 5;
    private int _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        ShowHp();
    }
    public void ChangeHealth(int healthPoints)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healthPoints,0, _maxHealth);
        ShowHp();
    }
    public bool IsMaxHealth() => _currentHealth == _maxHealth;
    private void ShowHp()
    {
        Debug.Log($"Current health : {_currentHealth} hp");
    }
}
