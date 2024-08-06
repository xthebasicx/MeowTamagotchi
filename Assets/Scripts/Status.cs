using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxMood = 10;
    public int maxFood = 10;
    public int maxStamina = 2;

    public int currentHealth = 5;
    public int currentMood = 5;
    public int currentFood = 5;
    public int currentStamina = 5;

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
    public void ChangeMood(int amount)
    {
        currentMood = Mathf.Clamp(currentMood + amount, 0, maxMood);
    }
    public void ChangeFood(int amount)
    {
        currentFood = Mathf.Clamp(currentFood + amount, 0, maxFood);
    }
    public void ChangeStamina(int amount)
    {
        currentStamina = Mathf.Clamp(currentStamina + amount, 0, maxStamina);
    }
}
