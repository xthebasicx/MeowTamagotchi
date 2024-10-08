using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Status : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderFood;
    public Slider sliderShower;
    public Slider sliderMood;
    public Slider sliderStamina;
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject EvoButton;
    private Animator animator;
    private AudioManager audioManager;
    public SceneTransition sceneTransition;
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

    private bool canClick = true;

    public void Start()
    {
        LoadStatus();
        SetMaxStatus();
        SetStatus();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        Evolution();
    }

    public void ChangeHealth(int amount, bool isMedicine = false)
    {
        if (currentHealth <= 3 && amount > 0 && !isMedicine)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        SetStatus();
        UpdateHealthColor();
        if (currentHealth == 0)
        {
            Die();
        }
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
        if (Day >= 7 && !isButtonPressed)
        {
            if (currentHealth == maxHealth &&
                currentMood == maxMood &&
                currentFood == maxFood &&
                currentShower == maxShower)
            {
                EvoButton.SetActive(true);
            }
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
        UpdateHealthColor();
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            canClick = false;
            StartCoroutine(ClickCooldown());
            animator.SetTrigger("Unique");
            int Cat = PlayerPrefs.GetInt("Cat", 0);
            int Evo = PlayerPrefs.GetInt("Evo", 0);

            switch (Cat)
            {
                case 0:
                    switch (Evo)
                    {
                        case 0: audioManager.PlayVoice(audioManager.jojocat); break;
                        case 1: audioManager.PlayVoice(audioManager.musclecat); break;
                        case 2: audioManager.PlayVoice(audioManager.oiiacat); break;
                    }
                    break;
                case 1:
                    switch (Evo)
                    {
                        case 0: audioManager.PlayVoice(audioManager.happycat); break;
                        case 1: audioManager.PlayVoice(audioManager.huhcat); break;
                        case 2: audioManager.PlayVoice(audioManager.sadcat); break;
                    }
                    break;
            }
        }
    }
    private void UpdateHealthColor()
    {
        Image fill = sliderHealth.fillRect.GetComponent<Image>();

        if (currentHealth <= 3)
        {
            fill.color = Color.magenta;
        }
        else
        {
            fill.color = Color.white;
        }
    }

    private IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(2f);
        canClick = true;
    }
    private void Die()
    {
        StartCoroutine(sceneTransition.TransitionDie("Mainmenu Scene"));
    }
}
