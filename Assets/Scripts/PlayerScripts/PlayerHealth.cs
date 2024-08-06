using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action<int> OnHealthChanged;
    private int _damageCooldownInSeconds = 2;
    private int _maxHealth = 5;
    private int _currentHealth;
    private bool _isInvincible;
    private bool _isDead;
    void Start()
    {
        _currentHealth = _maxHealth;
        _isDead = false;
        _isInvincible = false;
        ShowHp();
    }
    
    public void GetHeal(int healPoints)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healPoints, 0, _maxHealth);
        ShowHp();
        OnHealthChanged?.Invoke(_currentHealth);
    }
    public void TakeDamage(int healthPoints)
    {
        if (!_isInvincible && !_isDead)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - healthPoints, 0, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth);
            ShowHp();
            if (_currentHealth == 0)
            {
                GameOver();
            }
            else
            {
                _isInvincible = true;
                int damageCooldownInMilliseconds = _damageCooldownInSeconds * 1000;
                UseInvincibility(damageCooldownInMilliseconds);

            }
        }
    }
    public bool IsMaxHealth() => _currentHealth == _maxHealth;
    private async void UseInvincibility(int delay)
    {
        await Task.Delay(delay);
        _isInvincible = !_isInvincible;
    }
    private void GameOver()
    {
        _isDead = true;
        Debug.Log("You died! The game is over");
    }
    private void ShowHp()
    {
        Debug.Log($"Current health : {_currentHealth} hp");
    }
}
