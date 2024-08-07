using UnityEngine;
using UnityEngine.UIElements;

public class MyUIHandler : MonoBehaviour
{
    private VisualElement _mHealthBar;
    private VisualElement _mNonPlayerDialogue;
    private float _displayTime = 4.0f;
    private float _mTimerDisplay;

    public static MyUIHandler instance{ get; private set; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();   
        _mHealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        _mNonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        _mNonPlayerDialogue.style.display = DisplayStyle.None;
        _mTimerDisplay = -1.0f;

        PlayerHealth.OnHealthChanged += ChangeHealth;
    }
    private void Update()
    {
        if(_mTimerDisplay > 0)
        {
            _mTimerDisplay -= Time.deltaTime;
            if (_mTimerDisplay < 0)
            {
                _mNonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }
    private void ChangeHealth(int health)
    {
        _mHealthBar.style.width = Length.Percent(health * 20.0f);
    }
    public void DisplayDialogue()
    {
        _mNonPlayerDialogue.style.display = DisplayStyle.Flex;
        _mTimerDisplay = _displayTime;
    }
}
