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
        status.ChangeShower(2);
    }
    public void Exercise()
    {
        if (status.currentStamina > 0)
        {
            status.ChangeHealth(2);
            status.ChangeShower(-1);
            status.ChangeFood(-1);
            status.ChangeStamina(-1);
        }
    }
    public void MiniGame()
    {
        if (status.currentStamina > 0)
        {
            status.ChangeMood(3);
            status.ChangeFood(-2);
            status.ChangeStamina(-1);
        }
    }
    public void Sleep()
    {
        status.ChangeStamina(2);
        status.ChangeDay(1);
        RandomStatus();
    }
    private void RandomStatus(){

        int healthChange = Random.Range(-1, 1);
        int showerChange = Random.Range(-1, 1);
        int foodChange = Random.Range(-1, 1);
        int moodChange = Random.Range(-1, 1);

        int randomStatus = Random.Range(0, 4);

        switch (randomStatus)
        {
            case 0:
                healthChange = -2;
                break;
            case 1:
                showerChange = -2;
                break;
            case 2:
                foodChange = -2;
                break;
            case 3:
                moodChange = -2;
                break;
        }

        status.ChangeHealth(healthChange);
        status.ChangeShower(showerChange);
        status.ChangeFood(foodChange);
        status.ChangeMood(moodChange);
    }
}
