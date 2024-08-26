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
    public GameObject EvoButton;
    public static bool isButtonPressed = false;

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
        LoadStatus();
        SetMaxStatus();
        SetStatus();
    }
    void Update()
    {
        Evolution();
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
    public void Evolution()
    {
        if (Day >= 10 && !isButtonPressed)
        {
            EvoButton.SetActive(true);
        }
    }
    public void CloseButton()
    {
        EvoButton.SetActive(false);
        isButtonPressed = true;
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
    public void SaveStatus()
    {
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.SetInt("Food", currentFood);
        PlayerPrefs.SetInt("Shower", currentShower);
        PlayerPrefs.SetInt("Mood", currentMood);
        PlayerPrefs.SetInt("Stamina", currentStamina);
        PlayerPrefs.SetInt("Day", Day);
        PlayerPrefs.Save();
    }
    public void LoadStatus()
    {
        currentHealth = PlayerPrefs.GetInt("Health", 5);
        currentFood = PlayerPrefs.GetInt("Food", 5);
        currentShower = PlayerPrefs.GetInt("Shower", 5);
        currentMood = PlayerPrefs.GetInt("Mood", 5);
        currentStamina = PlayerPrefs.GetInt("Stamina", 2);
        Day = PlayerPrefs.GetInt("Day", 1);
        SetStatus();
    }

}