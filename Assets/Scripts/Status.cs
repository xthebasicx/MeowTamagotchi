using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderFood;
    public Slider sliderShower;
    public Slider sliderMood;
    public Slider sliderStamina;
    public TextMeshProUGUI textMeshProUGUI;

    public int maxHealth { get; private set; } = 10;
    public int maxFood { get; private set; } = 10;
    public int maxShower { get; private set; } = 10;
    public int maxMood { get; private set; } = 10;
    public int maxStamina { get; private set; } = 2;

    public int currentHealth { get; private set; } = 5;
    public int currentFood { get; private set; } = 5;
    public int currentShower { get; private set; } = 5;
    public int currentMood { get; private set; } = 5;
    public int currentStamina { get; private set; } = 2;

    public int Day { get; private set; } = 1;

    public void Start()
    {
        SetMaxStatus();
        SetStatus();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        SetStatus();
    }
    public void ChangeFood(int amount)
    {
        currentFood = Mathf.Clamp(currentFood + amount, 0, maxFood);
        SetStatus();
    }
    public void ChangeShower(int amount)
    {
        currentShower = Mathf.Clamp(currentShower + amount, 0, maxShower);
        SetStatus();
    }
    public void ChangeMood(int amount)
    {
        currentMood = Mathf.Clamp(currentMood + amount, 0, maxMood);
        SetStatus();
    }
    public void ChangeStamina(int amount)
    {
        currentStamina = Mathf.Clamp(currentStamina + amount, 0, maxStamina);
        SetStatus();
    }
    public void ChangeDay(int amount)
    {
        Day += amount;
    }
    public void SetMaxStatus()
    {
        sliderHealth.maxValue = maxHealth;
        sliderFood.maxValue = maxFood;
        sliderShower.maxValue = maxShower;
        sliderMood.maxValue = maxMood;
        sliderStamina.maxValue = maxStamina;
    }
    public void SetStatus()
    {
        sliderHealth.value = currentHealth;
        sliderFood.value = currentFood;
        sliderShower.value = currentShower;
        sliderMood.value = currentMood;
        sliderStamina.value = currentStamina;
        textMeshProUGUI.text = "Day " + Day;
    }
}
