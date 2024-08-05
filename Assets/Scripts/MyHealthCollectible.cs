using UnityEngine;

public class MyHealthCollectible : MonoBehaviour
{
    [SerializeField] private int healthIncrease;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController controller))
        {
            if (!controller.GetComponent<PlayerHealth>().IsMaxHealth())
            {
                controller.GetComponent<PlayerHealth>().GetHeal(healthIncrease);
                Destroy(gameObject);
            }
        }
    }
}
