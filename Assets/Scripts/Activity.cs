using UnityEngine;

public class Activity : MonoBehaviour
{
    public Status status;
    public void Snack()
    {
        status.ChangeFood(1);
        status.ChangeHealth(-1);
        status.ChangeMood(1);
    }
    public void HealthyFood()
    {
        status.ChangeFood(2);
        status.ChangeHealth(1);
    }
    public void Medicine()
    {
        if (status.currentHealth <= 3)
        {
            status.ChangeHealth(1);
            status.ChangeMood(-1);
        }
    }
    public void Shower()
    {
        status.ChangeMood(-2);
        status.ChangeShower(1);
    }
    public void Exercise()
    {
        if (status.currentStamina > 0)
        {
            status.ChangeHealth(1);
            status.ChangeFood(-1);
            status.ChangeStamina(-1);
        }
    }
    public void Sleep()
    {
        status.ChangeStamina(2);
    }
}
