using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        BotController bot = other.GetComponent<BotController>();
        if (bot != null)
        {
            bot.CollectItem(healAmount);
            Destroy(gameObject);
        }
    }
}