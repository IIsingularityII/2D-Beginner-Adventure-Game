using UnityEngine;
using UnityEngine.UIElements;

public class MyUIHandler : MonoBehaviour
{
    public float CurrentHealth = 0.5f;
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();   
        VisualElement healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        healthBar.style.width = Length.Percent(CurrentHealth * 100.0f);
    }
}
