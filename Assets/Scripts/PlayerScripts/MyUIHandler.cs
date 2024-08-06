using UnityEngine;
using UnityEngine.UIElements;

public class MyUIHandler : MonoBehaviour
{
    private VisualElement _mHealthBar;
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();   
        _mHealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");

        PlayerHealth.OnHealthChanged += ChangeHealth;
    }
    private void ChangeHealth(int health)
    {
        _mHealthBar.style.width = Length.Percent(health * 20.0f);
    }
}
